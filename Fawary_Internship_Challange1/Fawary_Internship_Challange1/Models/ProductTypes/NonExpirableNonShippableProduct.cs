using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fawary_Internship_Challange1.Models;

namespace Fawary_Internship_Challange1.Models.ProductTypes
{
    public class NonExpirableNonShippableProduct : Product
    {
        public override bool IsExpired() => false;
        public override bool RequiresShipping() => false;
    }
}
