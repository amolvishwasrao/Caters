using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caters.Model.Pizza
{
    interface IPizza
    {
        string Name { get; set; }

        string Size { get; set; }
    }
}
