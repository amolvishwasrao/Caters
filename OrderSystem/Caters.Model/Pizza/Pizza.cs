using Caters.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.Pizza
{
    public class Pizza : Food
    {

        private string _TypeOFfood;

        public Pizza()
        {
            this.TypeOfFood = "Pizza";
        }
        public override string TypeOfFood
        {
            get { return _TypeOFfood; }
            set { value = _TypeOFfood; }
        }

        
    }
}
