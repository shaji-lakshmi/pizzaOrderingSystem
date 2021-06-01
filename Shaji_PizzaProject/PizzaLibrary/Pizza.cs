using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary
{
    public class Pizza
    {
        public string pizzatype;
        public string size;
        public int quantity;
        public double price;
        public double totalcost; 

        public String PizzaType
        {
            get { return pizzatype;  }
            set { pizzatype = value; }
        }

        public String PizzaSize
        {
            get { return size; }
            set { size = value; }
        }

        public int PizzaQuantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double PizzaPrice
        {
            get { return price; }
            set { price = value; }
        }

        public double PizzaTotalCost
        {
            get { return totalcost; }
            set { totalcost = value; }
        }
    }
}
