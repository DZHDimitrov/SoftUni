using System.ComponentModel.DataAnnotations;

namespace SharedTrip.ViewModels
{
    public class CreateTripViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string StartPoint { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string EndPoint { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string DepartureTime { get; set; }

        public string ImagePath { get; set; }

        [Range(2,6,ErrorMessage = "{0} must be between {1} and {2}")]
        public int Seats { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(80,MinimumLength = 1,ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Description { get; set; }
    }
}
