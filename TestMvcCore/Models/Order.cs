using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestMvcCore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(255)]
        public string UserEmail { get; set; }

        [StringLength(50)]
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public decimal SubTotal { get; set; }
        
        public decimal Vat { get; set; }
        
        public decimal Total { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
