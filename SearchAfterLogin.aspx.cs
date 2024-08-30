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
    public partial class SearchAfterLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            shoeSearch.Text = Session["Search"].ToString();

            //PostBack allows the search function to run again when another string is entered into the textbox.
            //if PostBack is not true/enabled, the method will only run one time and not run again if a new
            //string is entered.
            if (!IsPostBack)
            {
                //retrieve connection info from web.config
                string strConnectionString = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
                SqlConnection myConnect = new SqlConnection(strConnectionString);

                //open the connection
                myConnect.Open();

                //create search command to retrieve data from table
                string checksearch = "SELECT COUNT(*) FROM [All_Shoes] WHERE ShoeName LIKE @search";
                SqlCommand com = new SqlCommand(checksearch, myConnect);

                //declare @search
                com.Parameters.AddWithValue("@search", shoeSearch.Text);
                com.Parameters["@search"].Value = "%" + shoeSearch.Text + "%";

                //use temp to create a fucntion
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());

                //close the connection
                myConnect.Close();

                //if the record exists
                if (temp > 0)
                {
                    string strCommandText = "SELECT *";
                    strCommandText += " FROM All_Shoes WHERE ShoeName LIKE @search";
                    SqlCommand cmd = new SqlCommand(strCommandText, myConnect);

                    //declare cmd parameters for title and author to be dispayed
                    cmd.Parameters.Add("@search", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@search"].Value = "%" + shoeSearch.Text + "%";

                    //open the connection
                    myConnect.Open();

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Title");
                    AllShoes.DataSource = ds;
                    AllShoes.DataBind();

                    //close the connection
                    myConnect.Close();
                }

                //else record does not exist
                else
                {
                    shoeSearch.Text = "No shoes found";
                }
            }


        }
    }
}