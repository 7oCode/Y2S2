using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppProject
{
    public partial class LoggedMen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet mendaily = GetMenDaily();

            MenDaily.DataSource = mendaily;
            MenDaily.DataBind();


            DataSet menlong = GetMenLong();
            MenLong.DataSource = menlong;
            MenLong.DataBind();

            DataSet menracing = GetMenRacing();
            MenRacing.DataSource = menracing;
            MenRacing.DataBind();
        }
        private DataSet GetMenDaily()
        {
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("MenDailyCRUD"))
                {
                    cmd.Parameters.AddWithValue("@Action", "SELECT");
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
        }

        private DataSet GetMenLong()
        {
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("MenLongCRUD"))
                {
                    cmd.Parameters.AddWithValue("@Action", "SELECT");
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
        }

        private DataSet GetMenRacing()
        {
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("MenRacingCRUD"))
                {
                    cmd.Parameters.AddWithValue("@Action", "SELECT");
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
        }

        protected void addCart(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //RepeaterItem item = (sender as Button).Parent as RepeaterItem;
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;

            //Finds the matching BS_ID in the row of data
            //Trim() allows data to be modified
            string name = (item.FindControl("lblMenDaily") as Label).Text;
            string price = (item.FindControl("lblMDailyPrice") as Label).Text;
            string quantity = (item.FindControl("ddlMDaily") as DropDownList).SelectedValue;
            string category = (item.FindControl("lblCategory") as Label).Text;
            Image imageControl = (Image)item.FindControl("MDailyShoe");
            string image = imageControl.ImageUrl;
            Console.WriteLine(quantity);
            int totalprice = Int32.Parse(price) * Int32.Parse(quantity);
            string newprice = totalprice.ToString();

            string size = (item.FindControl("ShoeSizes") as DropDownList).SelectedValue;


            string u = Session["User"].ToString();
            
            //Creates a new row in the cart
            string conn = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO UserCart (Username, ProductName, ProductPrice, Quantity, TotalPrice, Category, Image, ShoeSize) VALUES (@user ,@Name, @Price, @Quantity, @total, @category, @image, @size)", con);
                cmd.Parameters.AddWithValue("@user", u);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@total", newprice);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@image", image);
                cmd.Parameters.AddWithValue("@size", size);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}