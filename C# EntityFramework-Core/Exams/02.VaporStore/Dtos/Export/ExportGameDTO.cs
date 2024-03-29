﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.Dtos.Export
{
    public class ExportGameDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Developer { get; set; }

        public string Tags { get; set; }

        public int Players { get; set; }
    }
}
