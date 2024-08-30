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
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {

                DataSet showHist = GetPurchases();
                HistGrid.DataSource = showHist;
                HistGrid.DataBind();

                if (HistGrid.Rows.Count == 0)
                {
                    lblnone.Visible = true;
                }
                else
                {
                    calcPrice();
                }

            }
            else
            {
                Response.Redirect("~/Login.aspx");


            }

        }
        private DataSet GetPurchases()
        {
            string u = Session["User"].ToString();
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * From UserPurchases Where Username = @username", con);
                da.SelectCommand.Parameters.AddWithValue("@username", u);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }

        private void calcPrice()
        {
            decimal totalPrice = 0;

            foreach (GridViewRow row in HistGrid.Rows)
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
            ratePage.Visible=true;
            tPrice.Text = "Total Spending: " + totalPrice.ToString("c");
        }

        protected void toRatePage(object sender, EventArgs e)
        {
            Response.Redirect("RateProducts.aspx");
        }


    }
}