﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3),MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }

        public ICollection<AuthorBook> AuthorsBooks { get; set; }

        public Author()
        {
            this.AuthorsBooks = new HashSet<AuthorBook>();
        }
    }
}


//•	FirstName - text with length[3, 30]. (required)
//•	LastName - text with length[3, 30]. (required)
//•	Email - text(required).Validate it! There is attribute for this job.
//•	Phone - text.Consists only of three groups(separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required)
//•	AuthorsBooks - collection of type AuthorBook
