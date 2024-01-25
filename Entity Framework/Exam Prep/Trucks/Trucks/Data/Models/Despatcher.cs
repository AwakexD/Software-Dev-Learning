using System.ComponentModel.DataAnnotations;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        public Despatcher()
        {
            this.Trucks = new HashSet<Truck>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}
