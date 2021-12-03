using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.Dtos.Export
{
    [XmlType("Message")]
    public class ExportMessageDtoXML
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
