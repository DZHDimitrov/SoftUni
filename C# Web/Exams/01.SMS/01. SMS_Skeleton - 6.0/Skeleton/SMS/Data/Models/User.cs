using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class User
    {
        [Key]
        [StringLength(36)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [StringLength(20)]
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(56)]
        [Required]
        public string Password { get; set; }

        [ForeignKey(nameof(Cart))]
        [Required]
        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
