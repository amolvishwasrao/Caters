using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.Customize
{
    public class DrinkTop:Cutomize
    {
        private string _customizeName;
        public DrinkTop()
        {
            this.CustomizeName = "Drink Top";
            
        }

        public override string CustomizeName
        {
            get { return _customizeName; }
            set { _customizeName = value; }
        }
    }
}
