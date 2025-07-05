using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawary_Internship_Challange1.Models
{
    public class ShippableCartItem : IShippingItem
    {
        private readonly Product _product;
        private readonly int _quantity;

        public ShippableCartItem(Product product, int quantity)
        {
            _product = product;
            _quantity = quantity;
        }

        public string GetName() => $"{_quantity}x {_product.Name}";
        public double GetWeight() => _product.GetWeight() * _quantity;
    }


}
