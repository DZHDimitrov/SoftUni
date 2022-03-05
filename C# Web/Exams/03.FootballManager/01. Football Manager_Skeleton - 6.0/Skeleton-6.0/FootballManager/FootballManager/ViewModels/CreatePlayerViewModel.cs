namespace FootballManager.ViewModels
{

    using System.ComponentModel.DataAnnotations;

    public class CreatePlayerViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 5)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [StringLength(20, MinimumLength = 5)]
        public string Position { get; set; }

        public string Speed { get; set; }

        public string Endurance { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
