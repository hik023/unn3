using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unn3
{
    class SortUpAge : IComparer<Car>
    {
        public int Compare(Car b1, Car b2)
        {
            if (Convert.ToInt32(b1.age) > Convert.ToInt32(b2.age)) return 1;
            else if (Convert.ToInt32(b1.age) < Convert.ToInt32(b2.age)) return -1;
            else return 0;
        }
    }
}
