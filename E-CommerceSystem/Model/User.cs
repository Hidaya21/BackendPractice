using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.Model
{
    public class User
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }                    // system generated
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }                   // user input
        [Required]
        [MaxLength(150)]
        public string email { get; set; }                 // user input
        [Required]
        [MaxLength(256)]
        public string passwordHash { get; set; }          // system generated — hashed from user input
        [Required]
        [MaxLength(100)]
        public string fullName { get; set; }              // user input
        [MaxLength(20)]
        public string phoneNumber { get; set; }           // user input
        [MaxLength(300)]
        public string? address { get; set; }              // user input
        public DateTime? registrationDate { get; set; }  // system generated — set to today's date
        public bool isActive { get; set; } = true;      // default value    
        public List<Review> Reviews { get; set; } // reverse navigation — one User writes many Reviews
        public List<Order> Orders { get; set; }  // reverse navigation — one User places many Orders
    }
}