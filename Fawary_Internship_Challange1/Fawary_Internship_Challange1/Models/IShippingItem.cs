using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fawary_Internship_Challange1.Models
{
    public interface IShippingItem
    {
        string GetName();
        double GetWeight();
    }
}
