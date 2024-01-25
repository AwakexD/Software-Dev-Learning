namespace Medicines.DataProcessor.ImportDtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {
        [Required]
        [XmlElement("Name")]
        [MaxLength(50)]
        [MinLength(2)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("PhoneNumber")]
        [RegularExpression(@" ^\(\d{3}\) \d{3}-\d{4}$")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [XmlAttribute("non-stop")]
        [RegularExpression(@"^(true|false)$")]
        public string IsNonStop { get; set; } = null!;

        [XmlArray("Medicines")]
        [XmlArrayItem("Medicine")]
        public ImportMedicineDto[] Medicines { get; set; }
    }
}
