using System.Collections.Generic;
using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Import
{
    [XmlType("Car")]
    public class ImportCarsDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TravelledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public CarPartsInputDTO[] Parts { get; set; }
    }
}
