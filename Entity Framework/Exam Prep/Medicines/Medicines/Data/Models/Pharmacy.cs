using System.ComponentModel.DataAnnotations;

namespace Medicines.Data.Models
{
    public class Pharmacy
    {
        public Pharmacy()
        {
            this.Medicines = new HashSet<Medicine>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(14)]
        public string PhoneNumber { get; set; }

        [Required]
        public bool IsNonStop { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
