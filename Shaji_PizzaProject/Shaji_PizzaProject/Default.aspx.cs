using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Collections;
using PizzaLibrary;
namespace Shaji_PizzaProject
{
    public partial class Default : System.Web.UI.Page
    {
        DBConnect dBConnect = new DBConnect();

        ArrayList arrPizza = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowInput(true);
                ShowOutput(false);
            }
        }

        public void ShowInput(Boolean tf)
        {
            lblWarning.Visible = tf;
            gv_Input.Visible = tf;
            lblInputCustomerAddress.Visible = tf;
            lblInputCustomerName.Visible = tf;
            lblInputCustomerPhone.Visible = tf;
            rblPickup.Visible = tf;
            txtCustomerAddress.Visible = tf;
            txtCustomerName.Visible = tf;
            txtCustomerPhone.Visible = tf;
            lblPickup.Visible = tf;
            btnSubmit.Visible = tf;
            displayInputData();
        }

        public void ShowOutput(Boolean tf)
        {
            gv_Output.Visible = tf;
            lblcustomerName.Visible = tf;
            lblcustomerAddress.Visible = tf;
            lblcustomerPhone.Visible = tf;
            lblcustomerName.Text = "Customer Name: " + txtCustomerName.Text;
            lblcustomerPhone.Text = "Phone Number: " + txtCustomerPhone.Text;
            lblcustomerAddress.Text = "Customer Address: " + txtCustomerAddress.Text;
            btnBack.Visible = tf;

            
        }

        public void displayInputData()
        {
            String str = "SELECT * FROM Pizza";
            DataSet mydata = dBConnect.GetDataSet(str);
            
            gv_Input.DataSource = mydata;
            gv_Input.DataBind();
        }

        public void formValidation()
        {
            String customerName = txtCustomerName.Text;
            String cutomerAddress = txtCustomerAddress.Text;
            String customerPhone = txtCustomerPhone.Text;

            if (customerName == "")
            {
                Response.Write("<p><alert>You must input a name for the order.</alert></p>");
            }
            if (cutomerAddress == "")
            {
                Response.Write("<p><alert>You must input an address for the order.</alert></p>");
            }

            if (customerPhone == "")
            {
                Response.Write("<p><alert>You must input a phone number for the order.</alert></p>");
            }

            if (rblPickup.SelectedItem == null)
            {
                Response.Write("<p><alert>Please select a pick up type for your order.</alert></p>");

            }
        }

        public void gridValidation()
        {
            int checks = 0;
            for (int row = 0; row < gv_Input.Rows.Count; row++)
            {

                CheckBox selectedValue;
                selectedValue = (CheckBox)gv_Input.Rows[row].FindControl("cbSelect");

                TextBox quantityValue;
                quantityValue = (TextBox)gv_Input.Rows[row].FindControl("tbQuantity");
                if (selectedValue.Checked && quantityValue.Text != "")
                {
                    checks++;
                }
            }
            if (checks == 0)
            {
                Response.Write("<alert>You must select at least one pizza for the order. Make sure that a quantity is specified for the pizza you select.</alert>");

            }
        }

        public void getPizzaInfo()
        {
            Order customerOrder;
            Pizza myPizza;
            int quantity;
            for (int row = 0; row < gv_Input.Rows.Count; row++)
            {
                CheckBox selectedValue = (CheckBox)gv_Input.Rows[row].FindControl("cbSelect");
                if (selectedValue.Checked) {
                    TextBox quantityValue = (TextBox)gv_Input.Rows[row].FindControl("tbQuantity");
                    DropDownList sizeValue = (DropDownList)gv_Input.Rows[row].FindControl("ddlSize");
                    string pizzatype = gv_Input.Rows[row].Cells[1].Text;
                    quantity = Convert.ToInt32(quantityValue.Text);
                    string size = sizeValue.SelectedValue;
                    customerOrder = new Order();
                    double price = customerOrder.calculatePrice(pizzatype, size);
                    double totalCost = quantity * price;

                    myPizza = new Pizza();
                    myPizza.PizzaType = pizzatype;
                    myPizza.PizzaSize = size;
                    myPizza.PizzaQuantity = quantity;
                    myPizza.PizzaPrice = price;
                    myPizza.PizzaTotalCost = totalCost;
                    arrPizza.Add(myPizza);

                    
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int numPizzas=0;
            double totalBill=0;
            formValidation();
            gridValidation();
            getPizzaInfo();
            ShowInput(false);
            ShowOutput(true);
            gv_Output.DataSource = arrPizza;
            gv_Output.DataBind();

            for(int i=0; i < gv_Output.Rows.Count; i++)
            {
                numPizzas += int.Parse(gv_Output.Rows[i].Cells[2].Text);
                totalBill += double.Parse(gv_Output.Rows[i].Cells[4].Text);
            }
            gv_Output.Columns[0].FooterText = "Totals: ";
            gv_Output.Columns[2].FooterText = numPizzas.ToString();
            gv_Output.Columns[4].FooterText = totalBill.ToString("C2");
            gv_Output.DataBind();
            gv_salesReport.Visible = false;
            gv_quantityReport.Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ShowInput(true);
            ShowOutput(false);
            gv_salesReport.Visible = false;
            gv_quantityReport.Visible = false;

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            ShowInput(false);
            ShowOutput(false);
            btnBack.Visible = true;
            String salestr = "SELECT * FROM Pizza ORDER BY TotalSales DESC";
            DataSet sReport = dBConnect.GetDataSet(salestr);

            gv_salesReport.DataSource = sReport;
            gv_salesReport.DataBind();

            String quantitystr = "SELECT * FROM Pizza ORDER BY TotalQuantityOrdered DESC";
            DataSet qReport = dBConnect.GetDataSet(quantitystr);

            gv_quantityReport.DataSource = qReport;
            gv_quantityReport.DataBind();

            gv_salesReport.Visible = true;
            gv_quantityReport.Visible = true;
        }
    }
}