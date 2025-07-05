using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fawary_Internship_Challange1.Models;

namespace Fawary_Internship_Challange1.Models.ProductTypes
{
    public class NonExpirableShippableProduct : Product
    {
        public double Weight { get; set; }

        public override bool IsExpired() => false;
        public override bool RequiresShipping() => true;
        public override double GetWeight() => Weight;
    }
}
