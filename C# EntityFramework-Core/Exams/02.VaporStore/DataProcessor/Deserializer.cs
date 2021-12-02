namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.Dtos.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var games = (ImportGamesDTO[])JsonConvert.DeserializeObject<ImportGamesDTO[]>(jsonString);
			var devs = context.Developers.ToList();
			var initGenres = context.Genres.ToList();
			var initTags = context.Tags.ToList();

			var dbGames = new List<Game>();

			var sb = new StringBuilder();
			foreach (var game in games)
			{
				if (!IsValid(game) || !game.Tags.Any())
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				if (!DateTime.TryParse(game.ReleaseDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate))
				{
					sb.AppendLine("Invalid Data");
					continue;
				}

				var dbGame = new Game()
				{
					Name = game.Name,
					Price = game.Price,
					ReleaseDate = releaseDate
				};

				var dev = devs.FirstOrDefault(d => d.Name == game.Developer);
                if (dev == null)
                {
					dev = new Developer { Name = game.Developer };
					devs.Add(dev);
                }
				dbGame.Developer = dev;

				var genre = initGenres.FirstOrDefault(g => g.Name == game.Genre);
                if (genre == null)
                {
					genre = new Genre { Name = game.Genre };
					initGenres.Add(genre);
                }
				dbGame.Genre = genre;

                foreach (var tag in game.Tags)
                {
					var dbTag = initTags.FirstOrDefault(t => t.Name == tag);
                    if (dbTag == null)
                    {
						dbTag = new Tag { Name = tag };
						initTags.Add(dbTag);

                    }
					dbGame.GameTags.Add(new GameTag { Tag = dbTag });
                }
				dbGames.Add(dbGame);
				sb.AppendLine($"Added {game.Name} ({game.Genre}) with {game.Tags.Length} tags");
			}

			context.AddRange(dbGames);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}
		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var users = JsonConvert.DeserializeObject<ImportUsersDTO[]>(jsonString);

			var dbUsers = new List<User>();

			var sb = new StringBuilder();

            foreach (var user in users)
            {
                if (!IsValid(user))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var dbUser = new User
				{
					Username = user.Username,
					Email = user.Email,
					Age = user.Age,
					FullName = user.FullName
				};

				bool isValidType = true;

                foreach (var card in user.Cards)
                {
					object type;
                    if (!Enum.TryParse(typeof(CardType), card.Type, out type))
                    {
						isValidType = false;
						break;
                    }
					var dbCard = new Card
					{
						Cvc = card.Cvc,
						Number = card.Number,
						Type = (CardType)Enum.Parse(typeof(CardType), card.Type),
					};
					context.Cards.Add(dbCard);
					dbUser.Cards.Add(dbCard);
                }
                if (!isValidType)
                {
					sb.AppendLine("Invalid Data");
					break;
                }
				dbUsers.Add(dbUser);
				sb.AppendLine($"Imported {dbUser.Username} with {dbUser.Cards.Count} cards");
            }
			context.Users.AddRange(dbUsers);
			context.SaveChanges();
			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var serializer = new XmlSerializer(typeof(ImportPurchaseDTO[]),new XmlRootAttribute("Purchases"));
			var purchases = serializer.Deserialize(new StringReader(xmlString)) as ImportPurchaseDTO[];

			var dbPurchases = new List<Purchase>();

			var sb = new StringBuilder();

            foreach (var purchase in purchases)
            {
                if (!IsValid(purchase))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var dbPurchase = new Purchase
				{
					ProductKey = purchase.Key,
					Date = DateTime.ParseExact(purchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
				};
				object type;

                if (!Enum.TryParse(typeof(PurchaseType),purchase.Type,out type))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }
				dbPurchase.Type = (PurchaseType)type;

				var card = context.Cards.FirstOrDefault(c => c.Number == purchase.Card);

				dbPurchase.Card = card;

				var game = context.Games.FirstOrDefault(g => g.Name == purchase.Title);

				dbPurchase.Game = game;

				var username = context.Users.FirstOrDefault(u => u.Id == dbPurchase.Card.UserId).Username;

				dbPurchases.Add(dbPurchase);
				sb.AppendLine($"Imported {purchase.Title} for { username}");
            }

			context.Purchases.AddRange(dbPurchases);
			context.SaveChanges();

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}