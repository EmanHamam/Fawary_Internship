using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fawary_Internship_Challange1.Models;

namespace Fawary_Internship_Challange1.Services
{
    public class CheckoutService
    {
        private const double ShippingFee = 30;

        public void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
                throw new InvalidOperationException("Cart is empty.");

            double subtotal = 0;
            List<IShippingItem> shippingItems = new();

            foreach (var item in cart.Items)
            {
                if (item.Product.IsExpired())
                    throw new InvalidOperationException($"{item.Product.Name} is expired.");
                if (item.Quantity > item.Product.Quantity)
                    throw new InvalidOperationException($"{item.Product.Name} is out of stock.");

                subtotal += item.Product.Price * item.Quantity;

                if (item.Product.RequiresShipping())
                    shippingItems.Add(new ShippableCartItem(item.Product, item.Quantity));
            }

            double total = subtotal + ShippingFee;
            if (!customer.CanAfford(total))
                throw new InvalidOperationException("Customer has insufficient balance.");

            new ShippingService().Ship(shippingItems);

            customer.Pay(total);

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.Items)
                Console.WriteLine($"{item.Quantity}x {item.Product.Name,-12} {item.Product.Price * item.Quantity}");
            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal         {subtotal}");
            Console.WriteLine($"Shipping         {ShippingFee}");
            Console.WriteLine($"Amount           {total}");
            Console.WriteLine($"Balance Left     {customer.Balance}");
        }
    }

}
