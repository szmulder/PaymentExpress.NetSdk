using System.ComponentModel.DataAnnotations;

namespace TestMvcCore.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public double Quantity { get; set; }
        
        [Required]
        [StringLength(500)]
        public string ProductDesc { get; set; }        
        
        public decimal UnitPrice { get; set; }
        
        public decimal TotalPrice { get; set; }
    }
}
