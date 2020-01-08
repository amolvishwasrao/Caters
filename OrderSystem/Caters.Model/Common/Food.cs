using Caters.Model.Quote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.Common
{
    public abstract class Food:IPrice
    {
        public abstract string TypeOfFood { get; set; }
        public decimal price { get; set; }
        public List<Customize.Cutomize> _customization { get; set; }
    }



    
}
