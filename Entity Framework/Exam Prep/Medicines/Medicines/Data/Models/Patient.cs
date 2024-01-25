using System.ComponentModel.DataAnnotations;
using Medicines.Data.Models.Enums;

namespace Medicines.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            this.PatientMedicines = new HashSet<PatientMedicine>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public AgeGroup AgeGroup { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public virtual ICollection<PatientMedicine> PatientMedicines { get; set; }
    }
}
