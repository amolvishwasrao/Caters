using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.Pizza
{
    public class PannerPizza:Pizza
    {
        public PannerPizza()
        {
            this.TypeOfFood = "Panner Pizza";
            this.price = 250;
            this._customization = new List<Customize.Cutomize>();
        }
    }
}
