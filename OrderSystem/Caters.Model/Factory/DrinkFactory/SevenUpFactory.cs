using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caters.Model.ColdDrink;
using Caters.Model.Common;

namespace Caters.Model.Factory.DrinkFactory
{
    public class SevenUpFactory : FoodFactory
    {
        public override Food GetFood()
        {
            return new SevenUp();
        }
    }
}
