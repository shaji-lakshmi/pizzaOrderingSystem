using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Utilities;
using System.Data;
using System.Collections;

namespace PizzaLibrary
{
    public class Order
    {
        DBConnect dBConnect = new DBConnect();
        
        public double calculatePrice(string PizzaType, string Size)
        {
            double small = 1;
            double medium = 1.5;
            double large = 1.75;
            double price;

            String str = "SELECT BasePrice FROM Pizza WHERE PizzaType='"+PizzaType+"'";
            DataSet mydata = dBConnect.GetDataSet(str);
            price = Convert.ToDouble(mydata.Tables[0].Rows[0]["BasePrice"].ToString()); 

            if (Size == "Small")
            {
                price = price * small;
            }
            else if (Size == "Medium")
            {
                price = price * medium;
            }
            else if (Size == "Large")
            {
                price = price * large;
            }

            return price;
        }

        public void updateValues(string pizzaType, int quantityOrdered, double dollars)
        {
            double tSales;
            int tQuantity;

            String sales = "SELECT TotalSales FROM Pizza WHERE PizzaType = '" + pizzaType+"'";
            DataSet totalSales = dBConnect.GetDataSet(sales);
            tSales = Convert.ToDouble(totalSales.Tables[0].Rows[0]["TotalSales"].ToString());
            tSales = tSales + dollars;

            String quantity = "SELECT TotalQuantityOrdered FROM Pizza WHERE PizzaType ='" + pizzaType +"'";
            DataSet totalQuantity = dBConnect.GetDataSet(quantity);
            tQuantity = Convert.ToInt32(totalQuantity.Tables[0].Rows[0]["TotalQuantityOrdered"].ToString());
            tQuantity = tQuantity + quantityOrdered;

            String updateValues = "UPDATE Pizza SET TotalSales = '" + tSales + "',TotalQuantityOrdered = '" + tQuantity +"' WHERE PizzaType = '" + pizzaType+"'";
            dBConnect.DoUpdate(updateValues);
            
        }

        public double getTotalSales(string pizzaType)
        {
            double tSales;

            String sales = "SELECT TotalSales FROM Pizza WHERE PizzaType ='"+pizzaType+"'";
            DataSet totalSales = dBConnect.GetDataSet(sales);

            tSales = Convert.ToDouble(totalSales.Tables[0].Rows[0]["TotalSales"].ToString());
            return tSales;
        }

        public int getTotalQuantity(string pizzaType)
        {
            int tQuantity;

            String quantity = "SELECT TotalQuantityOrdered FROM Pizza WHERE PizzaType ='" +pizzaType+"'";
            DataSet totalQuantity = dBConnect.GetDataSet(quantity);
            tQuantity = Convert.ToInt32(totalQuantity.Tables[0].Rows[0]["TotalQuantityOrdered"].ToString());

            return tQuantity;
        }
    }
}
