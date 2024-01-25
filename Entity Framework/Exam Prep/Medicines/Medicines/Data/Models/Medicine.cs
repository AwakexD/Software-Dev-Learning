using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace Medicines.Data.Models
{
    public class Medicine
    {
        public Medicine()
        {
            this.PatientMedicines = new HashSet<PatientMedicine>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 1000.00)]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Producer { get; set; }

        public int PharmacyId { get; set; }

        public virtual Pharmacy Pharmacy{ get; set; }

        public virtual ICollection<PatientMedicine> PatientMedicines { get; set;}
    }
}
