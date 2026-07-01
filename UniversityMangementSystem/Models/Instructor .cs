using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UniversityManagementSystem.Models
{
    public class Instructor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int instructorId { get; set; }   // system generated

        [Required, MaxLength(100)]
        public string fullName { get; set; } // user input

        [Required, MaxLength(150)]
        public string email { get; set; }// user input

        [MaxLength(20)]
        public string? officeNumber { get; set; }// user input

        [Required]
        public DateTime hireDate { get; set; } // user input

        [Required, Range(0.1, double.MaxValue)]
        public decimal salary { get; set; }// user input

        [Required, MaxLength(50)]
        public string academicTitle { get; set; } // from list

        public ICollection<Course>? courses {get; set; }// navigation property
    }
}