using Fawary_Internship_Challange1.Models;
using Fawary_Internship_Challange1.Models.ProductTypes;
using Fawary_Internship_Challange1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawary_Internship_Challange1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Valid Checkout Example");
            ValidCheckout();

            Console.WriteLine("\n Empty Cart Error");
            EmptyCartError();

            Console.WriteLine("\n Insufficient Balance Error ");
            InsufficientBalanceError();

            Console.WriteLine("\n Expired Product Error");
            ExpiredProductError();

            Console.WriteLine("\n Exceeding Stock Error");
            ExceedingStockError();
        }

        static void ValidCheckout()
        {
            var customer = new Customer { Name = "Eman", Balance = 1000 };

            var cheese = new ExpirableShippableProduct
            {
                Name = "Cheese",
                Price = 50,
                Quantity = 10,
                ExpirationDate = DateTime.Now.AddDays(2),
                Weight = 0.3  //in kg
            };

            var biscuits = new ExpirableShippableProduct
            {
                Name = "Biscuits",
                Price = 15,
                Quantity = 5,
                ExpirationDate = DateTime.Now.AddDays(1),
                Weight = 0.3
            };

            var scratchCard = new NonExpirableNonShippableProduct
            {
                Name = "Scratch Card",
                Price = 50,
                Quantity = 100
            };

            var cart = new Cart();
            cart.AddProduct(cheese, 2);
            cart.AddProduct(biscuits, 1);
            cart.AddProduct(scratchCard, 1);

            var checkout = new CheckoutService();
            checkout.Checkout(customer, cart);
        }

        static void EmptyCartError()
        {
            try
            {
                var customer = new Customer { Name = "Ali", Balance = 500 };
                var cart = new Cart();
                var checkout = new CheckoutService();
                checkout.Checkout(customer, cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        static void InsufficientBalanceError()
        {
            try
            {
                var customer = new Customer { Name = "Laila", Balance = 100 };
                var tv = new NonExpirableShippableProduct
                {
                    Name = "TV",
                    Price = 300,
                    Quantity = 2,
                    Weight = 2
                };

                var cart = new Cart();
                cart.AddProduct(tv, 1);

                var checkout = new CheckoutService();
                checkout.Checkout(customer, cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        static void ExpiredProductError()
        {
            try
            {
                var customer = new Customer { Name = "Sarah", Balance = 500 };
                var expiredCheese = new ExpirableShippableProduct
                {
                    Name = "Old Cheese",
                    Price = 80,
                    Quantity = 5,
                    ExpirationDate = DateTime.Now.AddDays(-1),
                    Weight = 0.3
                };

                var cart = new Cart();
                cart.AddProduct(expiredCheese, 1);

                var checkout = new CheckoutService();
                checkout.Checkout(customer, cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        static void ExceedingStockError()
        {
            try
            {
                var customer = new Customer { Name = "Omar", Balance = 1000 };
                var mobile = new NonExpirableShippableProduct
                {
                    Name = "Mobile",
                    Price = 500,
                    Quantity = 2
                };

                var cart = new Cart();
                cart.AddProduct(mobile, 3); // Exceeds available quantity

                var checkout = new CheckoutService();
                checkout.Checkout(customer, cart);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
    }
}
