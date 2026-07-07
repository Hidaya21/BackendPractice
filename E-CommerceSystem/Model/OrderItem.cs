using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_CommerceSystem.Model
{
    [Table("OrderItems")]
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderItemId { get; set; }              // system generated
        // relationship attribute 
        [Required]
        [Range(1, 999)]
        public int quantity { get; set; }                 // user input
        // foreign key 
        [Required]
        [ForeignKey("Order")]
        public int orderId { get; set; }                  // system generated
        public Order Order { get; set; }                  // navigation property
        // foreign key 
        [Required]
        [ForeignKey("Product")]
        public int productId { get; set; }                // from list 
        public Product Product { get; set; }              // navigation property
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal unitPrice { get; set; }
    }
}
