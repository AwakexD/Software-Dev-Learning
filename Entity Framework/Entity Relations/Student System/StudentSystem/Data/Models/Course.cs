using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models 
{
    public class Course
    {
        public int CourseId { get; set; }

        [MaxLength(80)]
        [Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        public string Description { get; set; }
        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<Resource> Resources { get; set; }

        public Course()
        {
            this.Resources = new HashSet<Resource>();  
        }
    }
}
