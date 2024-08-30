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
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User"] != null)
            {
                loggedUser.Text = Session["User"].ToString();
                DataSet carousell = GetCarousell();

                imgCarousell.DataSource = carousell;
                imgCarousell.DataBind();

            }
            else
            {
                Response.Redirect("~/Login.aspx");


            }



        }

        protected void logoutUser(object sender, EventArgs e)
        {
            //Session["Email"] = null;
            Session["CHANGE_MASTERPAGE2"] = "~/EComms.Master";
            Session["CHANGE_MASTERPAGE"] = null;
            Session["User"] = null;
            Response.Redirect("~/Home.aspx");
        }

        //    protected void searchShoeBtn_Click(object sender, EventArgs e)
        //    {
        //        Session["Search"] = searchShoeLogged.Text;
        //        Response.Redirect("UserSearch");
        //    }
        //}
        private DataSet GetCarousell()
        {
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("imgCarousellCRUD"))
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
    }
}
