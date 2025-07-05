using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawary_Internship_Challange1.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new();

        public void AddProduct(Product product, int quantity)
        {
            if (quantity > product.Quantity)
                throw new InvalidOperationException("Requested quantity exceeds stock.");

            Items.Add(new CartItem { Product = product, Quantity = quantity });
        }

        public bool IsEmpty() => !Items.Any();
    }
}
