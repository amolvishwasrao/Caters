using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.Customize
{
    public class WhiteBread:Bread
    {
        public WhiteBread()
        {
            this.CustomizeName = "White Bread base";
            this.price = 50;
        }
    }
}
