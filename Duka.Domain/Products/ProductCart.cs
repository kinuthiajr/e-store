using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Duka.Domain.Users;

namespace Duka.Domain.Products
{
    public class ProductCart
    {
        public Guid Id { get; set; }
    
        public int Quantity { get; set; }

        public List<ProductCartItem> CartItems { get; set; } = [];

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}