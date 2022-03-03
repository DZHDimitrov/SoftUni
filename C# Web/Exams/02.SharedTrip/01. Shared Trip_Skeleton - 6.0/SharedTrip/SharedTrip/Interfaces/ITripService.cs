using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Interfaces
{
    public interface ITripService
    {
        public IEnumerable<TripViewModel> GetAllTrips();

        public (bool isCreated, IEnumerable<ErrorViewModel> errors) AddTrip(CreateTripViewModel model);

        public TripDetailsViewModel GetTripById(string tripId);

        (bool isAssigned, bool isSuccessful) AddUserToTrip(string tripId, string userId);
    }
}
