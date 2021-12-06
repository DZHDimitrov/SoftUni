using System;
using System.Collections.Generic;
using System.Text;

namespace Theatre.DataProcessor.ExportDto
{
    public class ExportTheatresDtoJSON
    {
        public string Name { get; set; }

        public sbyte Halls { get; set; }

        public decimal TotalIncome { get; set; }

        public ExportTicketDtoJSON[] Tickets { get; set; }
    }
}
