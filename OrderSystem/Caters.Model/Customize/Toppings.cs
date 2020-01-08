using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.Customize
{
    public class Toppings:Customize.Cutomize
    {
        private string _customizeName;
        public Toppings()
        {
            this.CustomizeName = "topping";
        }

        public override string CustomizeName
        {
            get { return _customizeName; }
            set { _customizeName = value; }
        }
    }
}
