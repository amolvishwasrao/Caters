using Caters.Model.Common;
using Caters.Model.Quote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.Customize
{
   public abstract class Cutomize: IPrice
    {
       
        public decimal price { get; set; }

        public abstract string CustomizeName { get; set; }
    }

  

}
