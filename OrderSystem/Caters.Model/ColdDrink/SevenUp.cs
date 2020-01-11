using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.ColdDrink
{
   public  class SevenUp:ColdDrink
    {
        public SevenUp()
        {
            this.TypeOfFood = "SevenUp";
            this.price = 150;
            this.Customization = new List<Customize.Cutomize>();
        }
    }
}
