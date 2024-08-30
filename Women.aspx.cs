using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppProject
{
    public partial class Women : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet womendaily = GetWomenDaily();
            WomenDaily.DataSource = womendaily;
            WomenDaily.DataBind();

            DataSet womenlong = GetWomenLong();
            WomenLong.DataSource = womenlong;
            WomenLong.DataBind();

            DataSet womenracing = GetWomenRacing();
            WomenRacing.DataSource = womenracing;
            WomenRacing.DataBind();
        }

        private DataSet GetWomenDaily()
        {
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("WomenDailyCRUD"))
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

        private DataSet GetWomenLong()
        {
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("WomenLongCRUD"))
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

        private DataSet GetWomenRacing()
        {
            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("WomenRacingCRUD"))
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