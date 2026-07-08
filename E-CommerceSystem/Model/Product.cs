using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.Model
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }                // system generated
        [Required]
        [MaxLength(150)]
        public string productName { get; set; }            // user input
        [MaxLength(1000)]
        public string description { get; set; }            // user input
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0.01, double.MaxValue)]
        public decimal price { get; set; }                 // user input
        [Required]
        [Range(0, int.MaxValue)]
        public int stockQuantity { get; set; } = 0;        // default value 
        [MaxLength(300)]
        public string imageUrl { get; set; }               // user input
        [Required]
        public DateTime createdAt { get; set; }            // system generated 
        public bool isAvailable { get; set; } = true;      // default value
        // foreign key 
        [Required]
        [ForeignKey("category")]
        public int categoryId { get; set; }                // from list 
        public Category category { get; set; }             // navigation property
        public List<Review> Reviews { get; set; } = new List<Review>(); // reverse navigation
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();// reverse navigation 
    }
}
