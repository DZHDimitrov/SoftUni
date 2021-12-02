namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using VaporStore.Dtos.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var games = context.Genres.ToArray()
				.Where(g => genreNames.Contains(g.Name))
				.Select(g => new ExportGamesByGenresDTO
				{
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games.Select(game => new ExportGameDTO
					{
						Id = game.Id,
						Title = game.Name,
						Developer = game.Developer.Name,
						Tags = string.Join(", ", game.GameTags.Select(gt => gt.Tag.Name)),
						Players = game.Purchases.Count
					})
					 .Where(g => g.Players > 0)
					 .OrderByDescending(g => g.Players)
					 .ThenBy(g => g.Id)
					 .ToArray(),
					TotalPlayers = g.Games.Sum(game => game.Purchases.Count)
				})
				.OrderByDescending(g => g.TotalPlayers)
				.ThenBy(g => g.Id);

			var json = JsonConvert.SerializeObject(games);
			return json;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var users = context.Users
				.ToArray()
				.Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
				.Select(u => new ExportUserDtoXML
				{
					Username = u.Username,
					Purchases = u.Cards
					.SelectMany(c => c.Purchases)
					.Where(p => p.Type.ToString() == storeType)
					.OrderBy(x=> x.Date)
					.Select(p => new ExportPurchaseDtoXML
					{
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new ExportGameDtoXML
						{
							Title = p.Game.Name,
							Price = p.Game.Price,
							Genre = p.Game.Genre.Name
						}
					})
					.ToArray(),
					TotalSpent = u.Cards.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price)),
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x=> x.Username)
				.ToArray();

			var serializer = new XmlSerializer(typeof(ExportUserDtoXML[]), new XmlRootAttribute("Users"));

			var sb = new StringBuilder();
			var namespaces = new XmlSerializerNamespaces();
			namespaces.Add("", "");

			serializer.Serialize(new StringWriter(sb), users, namespaces);

			return sb.ToString().TrimEnd();
		}
	}
}