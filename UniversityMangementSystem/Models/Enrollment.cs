using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UniversityManagementSystem.Models
{
    public class Enrollment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int enrollmentId { get; set; }// system generated

        [Required]
        public int studentId { get; set; }// foreign key

        [ForeignKey("studentId"), Required]
        public Student student { get; set; }//navigation property 

        [Required]
        public int courseId { get; set; }// foreign key

        [ForeignKey("courseId"), Required]
        public Course course { get; set; }//navigation property 

        [Required]
        public DateTime enrollmentDate { get; set; }// user Input

        [MaxLength(2)]
        public string finalGrade { get; set; }// user input

        [Required, MaxLength(20)]
        public string status { get; set; } = "In Progress"; // default value
    }
}
