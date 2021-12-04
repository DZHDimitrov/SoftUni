using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Dtos.Export
{
    public class ExportAuthorsDtoJSON
    {
        public string AuthorName { get; set; }

        public ExportBookDtoJSON[] Books { get; set; }
    }
}
