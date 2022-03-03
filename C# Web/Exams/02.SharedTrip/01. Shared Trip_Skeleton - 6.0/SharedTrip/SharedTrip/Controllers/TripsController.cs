using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Interfaces;
using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(Request request, ITripService _tripService) : base(request)
        {
            tripService = _tripService;
        }

        [Authorize]
        public Response All()
        {
            var trips = tripService.GetAllTrips();

            return View(new { Trips = trips });
        }

        [Authorize]
        public Response Add()
        {
            return View(new {IsAuthenticated = true});
        }

        [Authorize]
        [HttpPost]
        public Response Add(CreateTripViewModel model)
        {
            var (isValid, errors) = tripService.AddTrip(model);

            if (!isValid)
            {
                return View(new { Errors = errors }, "/Error");
            }

            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response Details(string tripId)
        {
            var trip = tripService.GetTripById(tripId);

            if (trip == null)
            {
                var error = new ErrorViewModel { ErrorMessage = "Trip was not found" };

                return View(new { Errors = new List<ErrorViewModel>() { error } });
            }

            return View(trip);
        }

        public Response AddUserToTrip(string tripId)
        {
            var (isAssigned, isSuccessfullyAdded) = tripService.AddUserToTrip(tripId, User.Id);

            if (isAssigned)
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            if (isSuccessfullyAdded)
            {
                return Redirect("/Trips/All");
            }

            return View();
        }
    }
}
