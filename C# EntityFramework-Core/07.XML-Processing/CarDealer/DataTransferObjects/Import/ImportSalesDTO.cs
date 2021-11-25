using System.Xml.Serialization;

namespace CarDealer.DataTransferObjects.Import
{
    [XmlType("Sale")]
    public class ImportSalesDTO
    {
        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("carId")]
        public int? CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }
    }
}
