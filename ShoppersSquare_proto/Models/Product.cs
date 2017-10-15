using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShoppersSquare_proto.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [StringLength(50)]
        public String Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public String ImageUrl { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(1.0, Double.MaxValue, ErrorMessage = "Price should be greater than zero")]
        public Decimal Price { get; set; }

        public byte ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }

        public DateTime DateAdded { get; set; }

        public int Ratings { get; set; }

        public short Sold { get; set; }

        public String Tags { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}