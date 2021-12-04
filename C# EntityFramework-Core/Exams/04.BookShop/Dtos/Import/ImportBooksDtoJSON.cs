using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookShop.Dtos.Import
{
    public class ImportBooksDtoJSON
    {
        [Required]
        public int? Id { get; set; }
    }
}
