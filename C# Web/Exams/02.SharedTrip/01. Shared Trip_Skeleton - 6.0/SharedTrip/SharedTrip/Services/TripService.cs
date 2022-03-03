using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Interfaces;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private IRepository repo;
        private readonly IValidationService validationService;

        public TripService(IRepository _repo,IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool isCreated, IEnumerable<ErrorViewModel> errors) AddTrip(CreateTripViewModel model)
        {
            var (isValid,errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (false,errors);
            }

            DateTime departureTime;

            if(!DateTime.TryParseExact(model.DepartureTime,"dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture,DateTimeStyles.None,out departureTime))
            {
                var error = new ErrorViewModel() { ErrorMessage = "Incorrect format of departure time" };

                return (false, new List<ErrorViewModel>() { error });
            }

            var trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = departureTime,
                Description = model.Description,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
            };

            try
            {
                repo.Add(trip);
                repo.SaveChanges();
            }
            catch (Exception)
            {
                var error = new ErrorViewModel() { ErrorMessage = "Could not save trip in database" };

                return (false, new List<ErrorViewModel>() { error });
            }

            return (true, new List<ErrorViewModel>());
        }

        public IEnumerable<TripViewModel> GetAllTrips()
        {
            return repo
                .All<Trip>()
                .Select(t => new TripViewModel 
                { 
                    TripId = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats })
                .ToList();
        }

        public TripDetailsViewModel GetTripById(string tripId)
        {
            return repo
                .All<Trip>()
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel
                {
                    TripId = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                    Description = t.Description,
                    ImagePath = t.ImagePath,
                })
                .FirstOrDefault();
        }

        public (bool isAssigned,bool isSuccessful) AddUserToTrip(string tripId,string userId)
        {
            var isSuccessfull = true;
            var isAssigned = false;

            var trip = repo.All<Trip>().Where(t => t.Id == tripId).FirstOrDefault();

            if (repo.All<UserTrip>().Any(t => t.TripId == tripId && t.UserId == userId))
            {
                return (true, false);
            }

            var userTrip = new UserTrip
            {
                TripId = trip.Id,
                UserId = userId,
            };

            try
            {
                repo.Add(userTrip);
                repo.SaveChanges();
            }
            catch (Exception)
            {
                isSuccessfull = false;
            }

            return (isAssigned,isSuccessfull);
        }
    }
}
