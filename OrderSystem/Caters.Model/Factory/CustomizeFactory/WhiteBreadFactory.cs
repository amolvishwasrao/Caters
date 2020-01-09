using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caters.Model.Customize;

namespace Caters.Model.Factory.CustomizeFactory
{
    public class WhiteBreadFactory:CustomizesFactory
    {
        public override Cutomize GetCutomize()
        {
            return new WhiteBread();
        }

    }
}
