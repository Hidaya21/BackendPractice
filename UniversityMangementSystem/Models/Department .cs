using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UniversityManagementSystem.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int departmentId { get; set; }// system generated
        [Required, MaxLength(100)]
        public string departmentName { get; set; }// user input
        [MaxLength(50)]
        public string? building { get; set; }// user input
        [Required, Range(0, double.MaxValue)]
        public decimal budget { get; set; }// user input
        public int? headInstructorId { get; set; }// foreign key
        [ForeignKey("headInstructorId")]
        public Instructor? headInstructor { get; set; }//navigation property 
        public ICollection<Course>? courses { get; set; }//navigation property 

    }
}