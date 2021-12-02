using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.Dtos.Export
{
    public class ExportGamesByGenresDTO
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public ExportGameDTO[] Games { get; set; }

        public int TotalPlayers { get; set; }
    }
}
