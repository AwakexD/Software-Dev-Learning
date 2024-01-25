using System.ComponentModel.DataAnnotations;

namespace Trucks.DataProcessor.ImportDto
{
    public class ClientImportDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        public string Type { get; set; }


        public ICollection<int> Trucks { get; set; }
    }
}
