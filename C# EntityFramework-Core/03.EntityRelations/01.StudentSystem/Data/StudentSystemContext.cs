using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=StudentSystem;Trusted_Connection=True;MultipleActiveResultSets=true");

            }
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>((e) =>
            {
                e.HasKey(x => x.StudentId);
                e.Property(x => x.Name).HasMaxLength(100).IsUnicode(true);
                e.Property(x => x.PhoneNumber).HasDefaultValueSql("CHAR(10)").IsRequired(false).IsUnicode(false);
                e.Property(x => x.Birthday).IsRequired(false);
                e.HasMany<Homework>(x => x.HomeworkSubmissions).WithOne(x => x.Student).HasForeignKey(x => x.StudentId);
            });

            modelBuilder.Entity<Course>((e) =>
            {
                e.HasKey(x => x.CourseId);
                e.Property(x => x.Name).HasMaxLength(80).IsUnicode(true);
                e.Property(x => x.Description).IsUnicode(true).IsRequired();
                e.HasMany<Resource>(x => x.Resources).WithOne(x => x.Course).HasForeignKey(x => x.CourseId);
                e.HasMany<Homework>(x => x.HomeworkSubmissions).WithOne(x => x.Course).HasForeignKey(x => x.CourseId);
            });

            modelBuilder.Entity<Resource>((e) =>
            {
                e.HasKey(x => x.ResourceId);
                e.Property(x => x.Name).HasMaxLength(50).IsUnicode(true);
                e.Property(x => x.Url).IsUnicode(false);
            });

            modelBuilder.Entity<Homework>((e) =>
            {
                e.HasKey(x => x.HomeworkId);
                e.Property(x => x.Content).IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>((e) =>
            {
                e.HasKey(x => new { x.StudentId, x.CourseId });
                e.HasOne(x => x.Student).WithMany(x => x.CourseEnrollments).HasForeignKey(x => x.StudentId);
                e.HasOne(x => x.Course).WithMany(x => x.StudentsEnrolled).HasForeignKey(x => x.CourseId);
            });
        }
    }
}
