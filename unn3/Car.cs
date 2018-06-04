using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unn3
{
    abstract public class Car
    {
        public string model;
        public string age;
        public string price;
        public string type;
        public int number;

        public Car(string model, string age, string price)
        {
            this.model = model;
            this.age = age;
            this.price = price;
        }

        abstract public double price_calculation();
    }
}
