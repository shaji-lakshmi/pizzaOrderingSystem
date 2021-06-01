<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Shaji_PizzaProject.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous"/>
    <link href="assets/pizzaStyle.css" rel="stylesheet" />
    <script src="assets/validation.js"></script>
    <title>CIS 3342: Pizza Shop </title>
</head>

<body>
    <div class="container">
        <form id="form1" runat="server">
            <h3 id="shopTitle">Temple U Italian Pizzeria</h3>
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-4">
                    <p>
                        <asp:Label ID="lblInputCustomerName" runat="server" Text="Customer Name: "></asp:Label><br />
                        <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox></p>
                    <p>
                        <asp:Label ID="lblInputCustomerAddress" runat="server" Text="Customer Address: "></asp:Label><br />
                        <asp:TextBox ID="txtCustomerAddress" runat="server"></asp:TextBox></p>
                    <p>
                        <asp:Label ID="lblInputCustomerPhone" runat="server" Text="Customer Phone Number: "></asp:Label><br />
                        <asp:TextBox ID="txtCustomerPhone" runat="server"></asp:TextBox></p>
                </div>

                <div class="col-md-6">
                    <p>
                        <asp:Label ID="lblPickup" runat="server" Text="Please choose a pickup option: "></asp:Label></p>
                    <p>
                        <asp:RadioButtonList ID="rblPickup" runat="server">
                            <asp:ListItem>Delivery</asp:ListItem>
                            <asp:ListItem>Pick_up</asp:ListItem>
                        </asp:RadioButtonList>
                    </p>
                </div>
            </div>
            <br />
            <br />
            <asp:Label ID="lblWarning" runat="server" Text="Please select at least one pizza"></asp:Label>

            <br />
            <br />
             <br />

            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <asp:GridView ID="gv_Input" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Select ">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PizzaType" HeaderText="Pizza Type" />
                            <asp:TemplateField HeaderText="Size">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlSize" runat="server">
                                        <asp:ListItem>Small</asp:ListItem>
                                        <asp:ListItem>Medium</asp:ListItem>
                                        <asp:ListItem>Large</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbQuantity" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div>
                <p>
                    <asp:Label ID="lblcustomerName" runat="server"></asp:Label></p>
                <p>
                    <asp:Label ID="lblcustomerAddress" runat="server"></asp:Label></p>
                <p>
                    <asp:Label ID="lblcustomerPhone" runat="server"></asp:Label></p>
                <asp:GridView ID="gv_Output" runat="server" AutoGenerateColumns="False" ShowFooter="True">
                    <Columns>
                        <asp:BoundField DataField="PizzaType" HeaderText="Pizza Type" />
                        <asp:BoundField DataField="PizzaSize" HeaderText="Size" />
                        <asp:BoundField DataField="PizzaQuantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="PizzaPrice" HeaderText="Price" />
                        <asp:BoundField DataField="PizzaTotalCost" HeaderText="Total Cost" />
                    </Columns>
                </asp:GridView>

            </div>

            <div id="management" class="row">
                <div class="col-md-2"></div>
                <div class="col-md-4">
                    <asp:GridView ID="gv_salesReport" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="PizzaType" HeaderText="Pizza Type" />
                            <asp:BoundField DataField="TotalSales" HeaderText="Pizza Sales" />

                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-4">
                    <asp:GridView ID="gv_quantityReport" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="PizzaType" HeaderText="Pizza Type" />
                            <asp:BoundField DataField="TotalQuantityOrdered" HeaderText="Pizza Orders" />

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2"></div>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" BackColor="#003300" ForeColor="White" />
                <asp:Button ID="btnBack" runat="server" Text="Back to Order Form" OnClick="btnBack_Click" BackColor="#993333" ForeColor="White" />
                <asp:Button ID="btnReport" runat="server" Text="Management Report" OnClick="btnReport_Click" BackColor="#FF9900" ForeColor="White" />

            </div>
        </form>
    </div>
</body>
</html>
