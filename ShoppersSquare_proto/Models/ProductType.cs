using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppersSquare_proto.Models
{
    public class ProductType
    {
        public byte Id { get; set; }

        public String Name { get; set; }

        public String ImageUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}