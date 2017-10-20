using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppersSquare_proto.Models
{
    public class CartItem
    {

        public const byte MaxQuantity = 200;

        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        [Range(1, MaxQuantity)]
        public byte Quantity { get; set; }
    }
}