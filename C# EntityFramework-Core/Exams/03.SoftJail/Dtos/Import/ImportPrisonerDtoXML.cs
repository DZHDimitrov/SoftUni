using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.Dtos.Import
{
    [XmlType("Prisoner")]
    public class ImportPrisonerDtoXML
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
