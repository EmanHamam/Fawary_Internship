using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawary_Internship_Challange1.Models
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public abstract bool IsExpired();
        public abstract bool RequiresShipping();
        public virtual double GetWeight() => 0; // default for non-shippable
    }
}
