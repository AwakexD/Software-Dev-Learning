using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models 
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "NVARCHAR")]
        public string Name { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegistredOn { get; set; }

        public DateTime Birthday { get; set; }
    }
}
