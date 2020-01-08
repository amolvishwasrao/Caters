using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.Customize
{
   public class Bread:Cutomize
    {
        private string _customizeName;
        public Bread()
        {
            this.CustomizeName = "base";
        }

        public override string CustomizeName
        {
            get { return _customizeName; }
            set { _customizeName = value; }
        }
    }
}
