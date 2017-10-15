using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppersSquare_proto.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public String Address { get; set; }

        [Required]
        public virtual ICollection<Product> Products { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        
        public byte OrderStatusId { get; set; }
        public virtual OrderState OrderStatus { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}