using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unn3
{
    class LightCar: Car
    {
        private double calc_price;

        public LightCar(string model, string age, string price) : base(model, age, price) {
            this.type = "Легковая";
            
                
        }

        override public double price_calculation()
        {
            this.calc_price = Convert.ToDouble(price);
            for (int i=0;i<Convert.ToInt32(Convert.ToString(2017 - Convert.ToInt32(this.age))); i++)
            {
                this.calc_price = this.calc_price * 0.9;
            }
            return this.calc_price;
        }
    }
}
