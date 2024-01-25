using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data 
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
            
        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<StudentCourse> StudentsCourses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=true;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(key => new
                {
                    key.StudentId,
                    key.CourseId,
                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
