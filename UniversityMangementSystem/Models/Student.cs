using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UniversityManagementSystem.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentId { get; set; } // system generated
        [Required, StringLength(100)]
        public string fullName { get; set; } // user input 
        [Required, StringLength(150)]
        public string email { get; set; }// user input
        [StringLength(20)]
        public string? phoneNumber { get; set; }// user input
        [Required]
        public DateTime dateOfBirth { get; set; }// user input
        [Required, Range(2000, 2030)]
        public int enrollmentYear { get; set; } // user input
        [Range(0.0, 4.0)]
        public decimal gpa { get; set; } = 0.0m; //default value
        public ICollection<Enrollment> enrollments { get; set; } // navigation property

    }
}
