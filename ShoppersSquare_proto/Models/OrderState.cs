using System.Collections.Generic;

namespace ShoppersSquare_proto.Models
{
    public class OrderState
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}