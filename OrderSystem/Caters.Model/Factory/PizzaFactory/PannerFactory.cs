using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caters.Model.Common;
using Caters.Model.Pizza;

namespace Caters.Model.Factory.PizzaFactory
{
    public class PannerFactory : FoodFactory
    {
        public override Food GetFood()
        {
            return new PannerPizza();
        }
    }
}
