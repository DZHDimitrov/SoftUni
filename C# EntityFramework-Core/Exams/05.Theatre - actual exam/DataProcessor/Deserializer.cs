namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var plays = XmlConvert.Deserialize<ImportPlayDtoXML[]>(xmlString, "Plays");

            var dbPlays = new List<Play>();


            var sb = new StringBuilder();

            foreach (var play in plays)
            {
                if (!IsValid(play))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan playDuration;

                bool isValidDuration = TimeSpan.TryParseExact(play.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out playDuration);
                if (!isValidDuration)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (playDuration.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                object genre = null;
                bool isValidGenre = Enum.TryParse(typeof(Genre), play.Genre, out genre);

                if (!isValidGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var dbPlay = new Play
                {
                    Rating = play.Rating,
                    Title = play.Title,
                    Description = play.Description,
                    Screenwriter = play.Screenwriter,
                    Duration = playDuration,
                    Genre = (Genre)genre
                };

                dbPlays.Add(dbPlay);
                sb.AppendLine(string.Format(SuccessfulImportPlay, dbPlay.Title, dbPlay.Genre.ToString(), dbPlay.Rating));
            }
            context.Plays.AddRange(dbPlays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var casts = XmlConvert.Deserialize<ImportCastDtoXML[]>(xmlString, "Casts");

            var dbCasts = new List<Cast>();

            var sb = new StringBuilder();

            foreach (var cast in casts)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentPlay = context.Plays.FirstOrDefault(p => p.Id == cast.PlayId);

                var dbCast = new Cast()
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    Play = currentPlay,
                };

                var textCharacter = dbCast.IsMainCharacter == true ? "main" : "lesser";
                dbCasts.Add(dbCast);
                sb.AppendLine(string.Format(SuccessfulImportActor, dbCast.FullName, textCharacter));
            }
            context.Casts.AddRange(dbCasts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var theatres = JsonConvert.DeserializeObject<ImportProjectionDtoJSON[]>(jsonString);

            var dbTheatres = new List<Theatre>();

            var sb = new StringBuilder();

            foreach (var theatre in theatres)
            {
                if (!IsValid(theatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var dbTheatre = new Theatre()
                {
                    Name = theatre.Name,
                    Director = theatre.Director,
                    NumberOfHalls = theatre.NumberOfHalls,
                };

                foreach (var ticket in theatre.Tickets)
                {
                    var currentPlay = context.Plays.FirstOrDefault(p => p.Id == ticket.PlayId);

                    if (!IsValid(ticket) || ticket.Price < 1 || ticket.Price > 100)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var currentTicket = new Ticket()
                    {
                        Price = (decimal)ticket.Price,
                        RowNumber = (sbyte)ticket.RowNumber,
                        PlayId = currentPlay.Id,
                        Theatre = dbTheatre
                    };

                    dbTheatre.Tickets.Add(currentTicket);
                }

                dbTheatres.Add(dbTheatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre, dbTheatre.Name, dbTheatre.Tickets.Count));
            }
            context.Theatres.AddRange(dbTheatres);
            ;
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
