using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityManagementSystem;

namespace UniversityManagementSystem.Models
{
    // Create a unique index for courseCode 
    // Prevents duplicate course codes in the database
    [Index(nameof(courseCode), IsUnique = true)]
    public class Course
    {
        // Primary Key 
        // Identity means SQL Server auto-generates the value
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int courseId { get; set; }

        [Required, MaxLength(10)]
        public string courseCode { get; set; }

        [Required, MaxLength(150)]
        public string courseTitle { get; set; }

        [Required, Range(1, 6)]
        public int creditHours { get; set; }
        // Foreign Key for Department table
        public int departmentId { get; set; }
        // Navigation Property 
        // Each course belongs to one department
        [ForeignKey("departmentId")]
        public Department department { get; set; }
        // Nullable Foreign Key for Instructor 
        // A course may or may not have an instructor assigned
        public int? instructorId { get; set; }
        // Navigation Property 
        // Links course to instructor
        [ForeignKey("instructorId")]
        public Instructor? instructor { get; set; }

        [Required, MaxLength(20)]
        public string semesterOffered { get; set; }
        // Navigation Property 
        // One course can have many enrollments
        public ICollection<Enrollment>? enrollments { get; set; }
    }
}