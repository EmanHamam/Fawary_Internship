using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawary_Internship_Challange1.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public bool CanAfford(double amount) => Balance >= amount;
        public void Pay(double amount) => Balance -= amount;
    }
}
