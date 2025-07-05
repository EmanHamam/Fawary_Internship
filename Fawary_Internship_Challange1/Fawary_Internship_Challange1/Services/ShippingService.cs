using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fawary_Internship_Challange1.Models;

namespace Fawary_Internship_Challange1.Services
{
    public class ShippingService
    {
        public void Ship(List<IShippingItem> items)
        {
            double totalWeight = items.Sum(item => item.GetWeight());
            Console.WriteLine("** Shipment notice **");
            foreach (var item in items)
                Console.WriteLine($"{item.GetName(),-15} {item.GetWeight() * 1000}g");
            Console.WriteLine($"Total package weight {totalWeight:F1}kg\n");
        }
    }

}
