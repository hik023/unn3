using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unn3
{
    class HugeCar : Car
    {
        private double calc_price;

        public HugeCar(string model, string age, string price) : base(model, age, price) {
            this.type = "Грузовая";
            this.calc_price = Convert.ToDouble(price);

        }

        override public double price_calculation()
        {
            if(Convert.ToInt32(Convert.ToString(2017 - Convert.ToInt32(this.age))) >= 1 && Convert.ToInt32(Convert.ToString(2017 - Convert.ToInt32(this.age))) <= 3)
            {
                return this.calc_price * 0.9;
            }
            else {
                if (Convert.ToInt32(Convert.ToString(2017 - Convert.ToInt32(this.age))) >= 4 && Convert.ToInt32(Convert.ToString(2017 - Convert.ToInt32(this.age))) <= 10)
                {
                    return this.calc_price * 0.8;
                }
                else
                {
                    if (Convert.ToInt32(Convert.ToString(2017 - Convert.ToInt32(this.age))) >= 11)
                    {
                        return this.calc_price * 0.7;
                    }
                    else
                    {
                        return this.calc_price;
                    }
                }
            }
            
            
            

        }
    }
}
