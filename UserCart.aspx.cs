using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebAppProject
{
    public partial class UserCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {

                DataSet showcart = GetCart();
                CartGrid.DataSource = showcart;
                CartGrid.DataBind();

                if (CartGrid.Rows.Count == 0)
                {
                    lblnone.Visible = true;
                }
                else
                {
                    calcPrice();
                    btnCheckout.Visible=true;
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");


            }
  
        }

        private void calcPrice()
        {
            decimal totalPrice = 0;

            foreach (GridViewRow row in CartGrid.Rows)
            {
                // Find the labels in the row
                Label lblQuantity = (Label)row.FindControl("lblQuantity");
                Label lblTotalPrice = (Label)row.FindControl("lblTotalPrice");

                // Retrieve the quantity and total price from labels
                int quantity = Convert.ToInt32(lblQuantity.Text);
                decimal rowTotalPrice = Convert.ToDecimal(lblTotalPrice.Text);

                // Add the row's total price to the overall total
                totalPrice += (rowTotalPrice * quantity);
            }
            tPrice.Visible = true;
            tPrice.Text = "Total Price: " + totalPrice.ToString("c");
        }

        private DataSet GetCart()
        {
            string u = Session["User"].ToString();
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * From UserCart Where Username = @username", con);
                da.SelectCommand.Parameters.AddWithValue("@username", u);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
        protected void checkOut(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataSet cCart = GetCart();
                DateTime date = DateTime.Now;
                string username = Session["User"].ToString();
                // Iterate through the rows of the DataSet
                foreach (DataRow row in cCart.Tables[0].Rows) // Assuming you have only one DataTable in the DataSet
                {
                    //// Extract data from each row
                    //string category = row["Category"].ToString(); // Replace "Category" with the actual column name

                    //string productName = row["ProductName"].ToString(); // Replace "ProductName" with the actual column name
                    ////int price = Convert.ToInt32(row["ShoePrice"]); // Replace "ShoePrice" with the actual column name
                    //string price = row["ShoePrice"].ToString();
                    //int quantity = Convert.ToInt32(row["Quantity"]); // Replace "Quantity" with the actual column name
                    //decimal totalPrice = Convert.ToDecimal(row["TotalPrice"]); // Replace "TotalPrice" with the actual column name

                    string uName = row["Username"].ToString();
                    string category = row["Category"].ToString();
                    string productName = row["ProductName"].ToString();
                    string price = row["ProductPrice"].ToString();
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    decimal totalPrice = Convert.ToDecimal(row["TotalPrice"]);
                    string image = row["image"].ToString();




                    // Execute INSERT statement to insert data into 'UserPurchases' table
                    string insertQuery = "INSERT INTO UserPurchases (Username, Category, ShoeName, ShoePrice, Quantity, TotalPrice, DateBought, Image)" +
                        " VALUES (@username, @category, @ProductName, @shoeprice, @Quantity, @TotalPrice, @DateBought, @image)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@username", uName);
                    insertCommand.Parameters.AddWithValue("@category", category);
                    insertCommand.Parameters.AddWithValue("@ProductName", productName);
                    insertCommand.Parameters.AddWithValue("@shoeprice", price);
                    insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                    insertCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    insertCommand.Parameters.AddWithValue("@DateBought", date);
                    insertCommand.Parameters.AddWithValue("@image", image);



                    string selectQuery = "SELECT TimesBought FROM " +
                        category + " WHERE ShoeName = @ProductName";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@ProductName", productName);
                    int counter = Convert.ToInt32(selectCommand.ExecuteScalar());

                    // Execute the INSERT statement
                    insertCommand.ExecuteNonQuery();
                    counter+= quantity;
                    string updateQuery = "UPDATE " + category + " SET TimesBought = @rating WHERE ShoeName = @ProductName";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@rating", counter);
                    updateCommand.Parameters.AddWithValue("@ProductName", productName);
                    updateCommand.ExecuteNonQuery();
                }

                // Now, remove items from 'UserCart' table
                string deleteQuery = "DELETE FROM UserCart Where Username = @uName";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                deleteCommand.Parameters.AddWithValue("@uName", username);

                // Execute the DELETE statement
                deleteCommand.ExecuteNonQuery();

                connection.Close();

                Response.Redirect("History.aspx");
            }
        }


        protected void rowDelete(object sender, GridViewDeleteEventArgs e)
        {
            //string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            ////string user = Session["Email"].ToString();
            //string user = Session["User"].ToString();
            //using (SqlConnection con = new SqlConnection(CS))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("DELETE FROM UserCart WHERE Username = @username and Id = @Id", con);
            //    cmd.Parameters.AddWithValue("@username", user);
            //    //cmd.Parameters.AddWithValue("@Id", rID);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    Response.Redirect("UserCart.aspx");

            //}
            int result = 0;
            Product prod = new Product();
            string UserID = CartGrid.DataKeys[e.RowIndex].Value.ToString();
            result = prod.CartDelete(UserID);
            if (result > 0)
            {
                retResult.Text = "Record Deleted Successfully!";
                retResult.Visible = true;
                
                Response.Redirect("UserCart.aspx");

            }
            else
            {
                retResult.Visible = true;
            }
            CartGrid.DataBind();
        }
    }
}