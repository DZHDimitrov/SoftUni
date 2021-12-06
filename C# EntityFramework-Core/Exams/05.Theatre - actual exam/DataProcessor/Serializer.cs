namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
              .ToArray()
              .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count > 20)
              .Select(t => new ExportTheatresDtoJSON
              {
                  Name = t.Name,
                  TotalIncome = t.Tickets.ToArray().Where(ticket => ticket.RowNumber >= 1 && ticket.RowNumber <= 5).Sum(ticket => ticket.Price),
                  Halls = t.NumberOfHalls,
                  Tickets = t.Tickets
                  .ToArray()
                  .Where(ticket => ticket.RowNumber >= 1 && ticket.RowNumber <= 5)
                  .Select(ticket => new ExportTicketDtoJSON
                  {
                      RowNumber = ticket.RowNumber,
                      Price = ticket.Price
                  })
                  .OrderByDescending(ticket => ticket.Price)
                  .ToArray()
              })
              .OrderByDescending(t => t.Halls)
              .ThenBy(t=>t.Name)
              .ToArray();

            var json = JsonConvert.SerializeObject(theatres);
            return json;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayDtoXML
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.ToArray()
                    .Where(c=> c.IsMainCharacter == true)
                    .Select(c => new ExportActorDtoXML
                    {
                        FullName = c.FullName,
                        MainCharacter = $"Plays main character in '{c.Play.Title}'."
                    })
                     .OrderByDescending(a => a.FullName)
                     .ToArray()

                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            var xml = XmlConvert.Serialize(plays, "Plays");

            return xml;
        }
    }
}
