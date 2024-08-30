using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Web.UI.DataVisualization.Charting;

namespace WebAppProject
{
    public partial class AdminHome : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void rowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            string UserID = viewUsers.DataKeys[e.RowIndex].Value.ToString();
            //string name = viewUsers.Rows[e.RowIndex].Cells[1].Text;

            result = prod.UserDelete(UserID);
            if (result > 0)
            {
                Response.Redirect("AdminPage");
            }
            else
            {
                retResult.Visible = true;
            }

        }


        //protected void rowDelete(object sender, GridViewDeleteEventArgs e)
        //{
        //    int result = 0;
        //    Product prod = new Product();
        //    string shoeID = ShoeGrid.DataKeys[e.RowIndex].Value.ToString();


        //    result = prod.ShoeDelete(shoeID);

        //    if (result > 0)
        //    {
        //        Response.Write("<script>alert('Shoe Deleted');</script>");
        //        Response.Redirect("AdminHome.aspx");
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Shoe Not Deleted');</script>");
        //    }

        //}
    }
}