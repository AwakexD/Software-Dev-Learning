using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Data.Models;
using P01_StudentSystem.Data.Enums;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "NVARCHAR")]
        public string? Name { get; set; }

        public string? Url { get; set; }

        public ResourceType ResourceType { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
