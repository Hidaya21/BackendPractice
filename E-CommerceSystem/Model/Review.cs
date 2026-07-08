using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.Model
{
    [Table("Reviews")]
    public class Review
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int reviewId { get; set; }                 // system generated
            [Required]
            [Range(1, 5)]
            public int rating { get; set; }                   // user input — 1 to 5 stars
            [MaxLength(1000)]
            public string comment { get; set; }               // user input
            [Required]
            public DateTime reviewDate { get; set; }           // system generated 
            // foreign key 
            [Required]
            [ForeignKey("User")]
            public int userId { get; set; }                   // from list 
            public User User { get; set; }                    // navigation property
            // foreign key
            [Required]
            [ForeignKey("product")]
            public int productId { get; set; }                // from list 
            public Product product { get; set; }
        }
}
