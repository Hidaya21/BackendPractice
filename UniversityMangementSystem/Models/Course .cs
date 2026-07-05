using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int courseId { get; set; } // system generated
        [Required, MaxLength(10)]
        public string courseCode { get; set; } // user input
        [Required, MaxLength(150)]
        public string courseTitle { get; set; }// user input
        [Required, Range(1, 6)]
        public int creditHours { get; set; }// user input                                         
        [ForeignKey("Department")]
        public int departmentId { get; set; }   // Foreign Key
        public  Department Department { get; set; }
        // Nullable Foreign Key for Instructor 
        // A course may or may not have an instructor assigned
        [ForeignKey("Instructor")]
        public int? instructorId { get; set; }   // Foreign Key
        public Instructor Instructor { get; set; } // Navigation Property
        [Required, MaxLength(20)]
        public string semesterOffered { get; set; }// user input
        // Navigation Property 
        // One course can have many enrollments
        public ICollection<Enrollment>? enrollments { get; set; }//navigation property 
    }
}