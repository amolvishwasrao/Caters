using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.Customize
{
   public class Cream:DrinkTop
    {
        public Cream()
        {
            this.CustomizeName = "Cream on drink";
            this.price = 80;
        }
    }
}
