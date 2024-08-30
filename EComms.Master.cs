using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebAppProject
{
    public partial class EComms : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet carousell = GetCarousell();

            imgCarousell.DataSource = carousell;
            imgCarousell.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["Search"] = searchShoe.Text;
            Response.Redirect("Search");

        }
        protected void load_men(object sender, EventArgs e)
        {
            //Response.Redirect("Men_Shoes");
        }

        private DataSet GetCarousell()
        {
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using(SqlCommand cmd = new SqlCommand("imgCarousellCRUD"))
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