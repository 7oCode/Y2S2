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
    public partial class Unisex : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet unisex = GetUnisex();
            UnisexShoes.DataSource = unisex;
            UnisexShoes.DataBind();
        }

        private DataSet GetUnisex()
        {
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * From Unisex", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }
    }
}