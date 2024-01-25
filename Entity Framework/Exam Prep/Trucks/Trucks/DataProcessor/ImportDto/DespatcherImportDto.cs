using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class DespatcherImportDto
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [XmlArray("Trucks")]
        [XmlArrayItem("Truck")]
        public DespatcherTruckImportDto[] Trucks { get; set; } = null;

    }
}
