using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lucky_Cafe_Order
{
    public partial class Cafe_Oder : Form
    {
        public Cafe_Oder()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                string Customer_name = txtCustomerName.Text;
                if (Customer_name == string.Empty)
                {
                    MessageBox.Show("Customer Name can't be Empty");
                    return;
                }
                double total = 0;
                if (int.TryParse(txtQuantity.Text, out int quantity))
                {
                    if (quantity < 1)
                    {
                        MessageBox.Show("Quantity can't be less than 1");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Quantity can't be Letter");
                    return;
                }

                if (rbtnTea.Checked) 
                {
                    Order_list.Items.Clear();
                    string drink_name = "Tea";
                    double price = 1;
                    Random ran = new Random();
                    bool isfree_cookie = false;
                    int lucky_free = 0;

                    for (int i = 1; i <= quantity; i++)
                    {
                        int luck_number = ran.Next(1,51);
                        if (luck_number == 7)  
                        {
                            isfree_cookie = true;
                            lucky_free = luck_number;
                            Order_list.Items.Add(i + ") " + Customer_name + "-" + drink_name + "-" +
                                "Lucky:" + luck_number + "-" + price.ToString("C2"));
                            Order_list.Items.Add("\n");
                        }
                        else if(luck_number == 17)
                        {
                            isfree_cookie = true;
                            lucky_free = luck_number;
                            Order_list.Items.Add(i + ") " + Customer_name + "-" + drink_name + "-" +
                                "Lucky:" + luck_number + "-" + price.ToString("C2"));
                            Order_list.Items.Add("\n");
                        }
                        else
                        {
                            Order_list.Items.Add(i + ") " + Customer_name + "-" + drink_name + "-" +
                                "Lucky:" + luck_number + "-" + price.ToString("C2"));
                            Order_list.Items.Add("\n");
                        } 

                    }
                    if (chkStudentMember.Checked)
                    {

                        total = quantity * price;
                        double dicount = total * 0.1;
                        Order_list.Items.Add("\n\n");
                        Order_list.Items.Add("Member Discount: 10%");
                        Order_list.Items.Add("\n");
                        Order_list.Items.Add("Total Before Discount: " + total.ToString("C2"));
                        Order_list.Items.Add("\n");
                        double final_price = total - dicount;
                        Order_list.Items.Add("Total After Discount: " + final_price.ToString("C2"));

                        lbTotalResult.Text = "Total Price: " + final_price.ToString("C2");
                        lbTotalResult.ForeColor = Color.DarkBlue;
                    }
                    else
                    {
                        total = quantity * price;
                        Order_list.Items.Add("\n\n");
                        Order_list.Items.Add("Total with no Discount: " + total.ToString("C2"));
                        lbTotalResult.Text = "Total Price: " + total.ToString("C2");
                        lbTotalResult.ForeColor = Color.DarkBlue;
                            
                    }

                    if (isfree_cookie)
                    {
                        Order_list.Items.Add("\n");
                        Order_list.Items.Add("Lucky Message: You got a free cookie!(lucky " + lucky_free + ")");
                        lbluckymessage.Text = "Lucky Message: You got a free cookie!";
                        lbluckymessage.ForeColor = Color.Orange;
                    }
                    else
                    {
                        Order_list.Items.Add("\n");
                        Order_list.Items.Add("No Price this time.");
                        lbluckymessage.Text = "No Price this time.";
                        lbluckymessage.ForeColor = Color.Orange;
                    }

                }
                else if (rbtnCoffee.Checked)
                {
                    Order_list.Items.Clear();
                    string drink_name = "Coffee";
                    int price = 2;
                    Random ran = new Random();
                    bool isfree_cookie = false;
                    int lucky_free = 0;
                    for (int i = 1; i <= quantity; i++)
                    {
                        int luck_number = ran.Next(1, 51);
                        if (luck_number == 7)
                        {
                            isfree_cookie = true;
                            lucky_free = 7;
                            Order_list.Items.Add(i + ") " + Customer_name + "-" + drink_name + "-" +
                                "Lucky:" + luck_number + "-" + price.ToString("C2"));
                            Order_list.Items.Add("\n");
                        }
                        else if (luck_number == 17)
                        {
                            isfree_cookie = true;
                            lucky_free = 17;
                            Order_list.Items.Add(i + ") " + Customer_name + "-" + drink_name + "-" +
                                "Lucky:" + luck_number + "-" + price.ToString("C2"));
                            Order_list.Items.Add("\n");
                        }
                        else
                        {
                            Order_list.Items.Add(i + ") " + Customer_name + "-" + drink_name + "-" +
                                "Lucky:" + luck_number + "-" + price.ToString("C2"));
                            Order_list.Items.Add("\n");
                        }

                    }
                    if (chkStudentMember.Checked)
                    {

                        total = quantity * price;
                        double dicount = total * 0.1;
                        Order_list.Items.Add("\n\n");
                        Order_list.Items.Add("Member Discount: 10%");
                        Order_list.Items.Add("\n");
                        Order_list.Items.Add("Total Before Discount: " + total.ToString("C2"));
                        Order_list.Items.Add("\n");
                        double final_price = total - dicount;
                        Order_list.Items.Add("Total After Discount: " + final_price.ToString("C2"));

                        lbTotalResult.Text = "Total Price: " + final_price.ToString("C2");
                        lbTotalResult.ForeColor = Color.DarkBlue;
                    }
                    else
                    {
                        total = quantity * price;
                        Order_list.Items.Add("\n\n");
                        Order_list.Items.Add("Total with no Discount: " + total.ToString("C2"));
                        lbTotalResult.Text = "Total Price: " + total.ToString("C2");
                        lbTotalResult.ForeColor = Color.DarkBlue;

                    }

                    if (isfree_cookie)
                    {
                        Order_list.Items.Add("\n");
                        Order_list.Items.Add("Lucky Message: You got a free cookie!(lucky " + lucky_free + ")");
                        lbluckymessage.Text = "Lucky Message: You got a free cookie!";
                        lbluckymessage.ForeColor = Color.Orange;
                    }
                    else
                    {
                        Order_list.Items.Add("\n");
                        Order_list.Items.Add("No Price this time.");
                        lbluckymessage.Text = "No Price this time.";
                        lbluckymessage.ForeColor = Color.Orange;
                    }
                }
                else if (rbtnJuice.Checked)
                {
                    Order_list.Items.Clear();
                    string drink_name = "Juice";
                    int price = 3;
                    Random ran = new Random();
                    bool isfree_cookie = false;
                    int lucky_free = 0;
                    for (int i = 1; i <= quantity; i++)
                    {
                        int luck_number = ran.Next(1, 51);
                        if (luck_number == 7)
                        {
                            isfree_cookie = true;
                            lucky_free = 7;
                            Order_list.Items.Add(i + ") " + Customer_name + "-" + drink_name + "-" +
                                "Lucky:" + luck_number + "-" + price.ToString("C2"));
                            Order_list.Items.Add("\n");
                        }
                        else if (luck_number == 17)
                        {
                            isfree_cookie = true;
                            lucky_free = 17;
                            Order_list.Items.Add(i + ") " + Customer_name + "-" + drink_name + "-" +
                                "Lucky:" + luck_number + "-" + price.ToString("C2"));
                            Order_list.Items.Add("\n");
                        }
                        else
                        {
                            Order_list.Items.Add(i + ") " + Customer_name + "-" + drink_name + "-" +
                                "Lucky:" + luck_number + "-" + price.ToString("C2"));
                            Order_list.Items.Add("\n");
                        }

                    }
                    if (chkStudentMember.Checked)
                    {

                        total = quantity * price;
                        double dicount = total * 0.1;
                        Order_list.Items.Add("\n\n");
                        Order_list.Items.Add("Member Discount: 10%");
                        Order_list.Items.Add("\n");
                        Order_list.Items.Add("Total Before Discount: " + total.ToString("C2"));
                        Order_list.Items.Add("\n");
                        double final_price = total - dicount;
                        Order_list.Items.Add("Total After Discount: " + final_price.ToString("C2"));

                        lbTotalResult.Text = "Total Price: " + final_price.ToString("C2");
                        lbTotalResult.ForeColor = Color.DarkBlue;
                    }
                    else
                    {
                        total = quantity * price;
                        Order_list.Items.Add("\n\n");
                        Order_list.Items.Add("Total with no Discount: " + total.ToString("C2"));
                        lbTotalResult.Text = "Total Price: " + total.ToString("C2");
                        lbTotalResult.ForeColor = Color.DarkBlue;

                    }

                    if (isfree_cookie)
                    {
                        Order_list.Items.Add("\n");
                        Order_list.Items.Add("Lucky Message: You got a free cookie!(lucky " + lucky_free + ")");
                        lbluckymessage.Text = "Lucky Message: You got a free cookie!";
                        lbluckymessage.ForeColor = Color.Orange;
                    }
                    else
                    {
                        Order_list.Items.Add("\n");
                        Order_list.Items.Add("No Price this time,");
                        lbluckymessage.Text = "No Price this time.";
                        lbluckymessage.ForeColor = Color.Orange;
                    }
                }
                else
                {
                    MessageBox.Show("You must Choose Drink type.");
                    return;
                }

            }catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

   

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            
            if(Order_list.Items.Count != 0)
             {
                    StreamWriter Order_Cafee;
                    Order_Cafee = File.AppendText("orders.txt");
                    for(int i = 0; i < Order_list.Items.Count; i++)
                    {
                        Order_Cafee.WriteLine(Order_list.Items[i].ToString());
                    }
                    Order_Cafee.WriteLine("\n"+lbTotalResult.Text);
                    Order_Cafee.WriteLine(lbluckymessage.Text+"\n");
                    Order_Cafee.Close();
                    MessageBox.Show("Order Saved");
            }
            else
             {
                    MessageBox.Show("No order to save.");
                    return;
             }
            
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            if (File.Exists("orders.txt"))
            {
                Order_list.Items.Clear();
                StreamReader load_file;
                load_file = File.OpenText("orders.txt");

                while (!load_file.EndOfStream)
                {
                    Order_list.Items.Add(load_file.ReadLine());
                }
                load_file.Close();
                
            }
            else
            {
                MessageBox.Show("No File Found.");
                return;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtCustomerName.Text = "";
            txtQuantity.Text = "";
            Order_list.Items.Clear();
            lbTotalResult.Text = string.Empty;
            lbluckymessage.Text = string.Empty;
            chkStudentMember.Checked = false;
        }

        
    }
}
