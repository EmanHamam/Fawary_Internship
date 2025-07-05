using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fawary_Internship_Challange1.Models;

namespace Fawary_Internship_Challange1.Models.ProductTypes
{
    public class ExpirableNonShippableProduct : Product
    {
        public DateTime ExpirationDate { get; set; }

        public override bool IsExpired() => DateTime.Now > ExpirationDate;
        public override bool RequiresShipping() => false;
    }
}
