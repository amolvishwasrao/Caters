using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caters.Model.Common;
using Caters.Model.Sandwitch;

namespace Caters.Model.Factory.SandwitchFactory
{
    public class BombayFactory : FoodFactory
    {
        public override Food GetFood()
        {
            return new BombaySandwitch();
        }
    }
}
