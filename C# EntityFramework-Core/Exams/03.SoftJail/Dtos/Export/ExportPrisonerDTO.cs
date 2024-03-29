﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.Dtos.Export
{
    public class ExportPrisonerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CellNumber { get; set; }

        public ExportOfficerDTO[] Officers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }
}
