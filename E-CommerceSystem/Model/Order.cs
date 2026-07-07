using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.Model
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId { get; set; }                  // system generated
        [Required]
        public DateTime orderDate { get; set; }            // system generated 
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Range(0, double.MaxValue)]
        public decimal totalAmount { get; set; }           // calculated 
        [Required]
        [MaxLength(30)]
        public string status { get; set; } = "Pending";   // default value 
        [Required]
        [MaxLength(300)]
        public string shippingAddress { get; set; }        // user input
        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; }          // from list 
        // foreign key
        [Required]
        [ForeignKey("user")]
        public int userId { get; set; }                   // from list 
        public User user { get; set; }                    // navigation property
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();// reverse navigation 
    }
}
