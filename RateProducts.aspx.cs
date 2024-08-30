using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAppProject
{
    public partial class RateProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["User"] != null)
            {
                DataSet rateThing = ForRating();

                rateShoes.DataSource = rateThing;
                rateShoes.DataBind();

            }
            else
            {
                Response.Redirect("~/Login.aspx");


            }

        }

        private DataSet ForRating()
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
        //protected void ComputeButton_Click(object sender, EventArgs e)
        //{

        //    string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
        //    string user = Session["user"].ToString();   

        //    foreach (RepeaterItem item in rateShoes.Items)
        //    {
        //        // Find controls within the current item
        //        Label lblshoename = (Label)item.FindControl("lblshoename");
        //        Label lblcat = (Label)item.FindControl("lblcat");
        //        DropDownList ddlrate = (DropDownList)item.FindControl("ddlrate");

        //        // Retrieve shoe name and selected rating
        //        string shoename = lblshoename.Text;
        //        string category = lblcat.Text;
        //        int selectedRating = Convert.ToInt32(ddlrate.SelectedValue);

        //        // Perform any further actions with shoename and selectedRating
        //        // For example, you can execute SQL queries with these values
        //        // Replace this with your SQL execution logic

        //        string query2 = @"
        //    SELECT AVG(total_rating) AS average_rating
        //    FROM (
        //        SELECT SUM(Rating) AS total_rating
        //        FROM UserPurchases
        //        WHERE ShoeName = @Name AND Category = @Category
        //        GROUP BY ShoeName, Category
        //    ) AS subquery_alias";
        //        object result;
        //        decimal avgRate;

        //        string finalInsert = $"Update [{category}] Set Rating = @rating Where ShoeName = @Sname";

        //        string query = "Update UserPurchases Set Rating = @Rating where Username = @username And ShoeName = @shoename";
        //        using (SqlConnection connection = new SqlConnection(CS))
        //        {

        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                connection.Open();

        //                //command.Parameters.AddWithValue("@ShoeName", shoename);
        //                command.Parameters.AddWithValue("@Rating", selectedRating);
        //                //command.Parameters.AddWithValue("@Category", category);
        //                command.Parameters.AddWithValue("@username", user);
        //                command.Parameters.AddWithValue("@shoename", shoename);
        //                command.ExecuteNonQuery();
        //                connection.Close();
        //            }

        //            using(SqlCommand command2 = new SqlCommand(query2, connection))
        //            {
        //                command2.Parameters.AddWithValue("@Name", shoename);
        //                command2.Parameters.AddWithValue("@category", category);
        //                command2.ExecuteNonQuery();
        //                result = command2.ExecuteScalar();
        //            }

        //            avgRate = Convert.ToDecimal(result);

        //            using (SqlCommand command3 = new SqlCommand(finalInsert, connection))
        //            {
        //                command3.Parameters.AddWithValue("@rating", avgRate);
        //                command3.Parameters.AddWithValue("@Sname", shoename);
        //                command3.ExecuteNonQuery();

        //            }

        //        }



        //    }
        //}

        protected void ComputeButton_Click(object sender, EventArgs e)

        {
            RepeaterItem item = (sender as Button).Parent as RepeaterItem;

            string CS = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;

            string user = Session["user"].ToString();


            // Find controls within the current item

            Label lblshoename = (Label)item.FindControl("lblshoename");

            Label lblcat = (Label)item.FindControl("lblcat");
            Label lblId = (Label)item.FindControl("lblId");

            DropDownList ddlrate = (DropDownList)item.FindControl("ddlrate");



            // Retrieve shoe name and selected rating

            string shoename = lblshoename.Text;

            string category = lblcat.Text;
            int uID = Int32.Parse(lblId.Text);
            int selectedRating = Convert.ToInt32(ddlrate.SelectedValue);


            // Perform any further actions with shoename and selectedRating

            // For example, you can execute SQL queries with these values

            // Replace this with your SQL execution logic


            string query2 = @"

            SELECT AVG(total_rating) AS average_rating

            FROM (

                SELECT SUM(Rating) AS total_rating

                FROM UserPurchases

                WHERE ShoeName = @Name AND Category = @Category And Id= @Id

                GROUP BY ShoeName, Category

            ) AS subquery_alias";

            object result;

            decimal avgRate;


            string finalInsert = $"Update [{category}] Set Rating = @rating Where ShoeName = @Sname";

            using (SqlConnection connection = new SqlConnection(CS))

            {

                string query = "Update UserPurchases Set Rating = @Rating where Username = @username And ShoeName = @shoename And Id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))

                {

                    connection.Open();

                    command.Parameters.AddWithValue("@Rating", selectedRating);

                    command.Parameters.AddWithValue("@username", user);

                    command.Parameters.AddWithValue("@shoename", shoename);
                    command.Parameters.AddWithValue("@id", uID);

                    command.ExecuteNonQuery();

                }


                using (SqlCommand command2 = new SqlCommand(query2, connection))
                {

                    command2.Parameters.AddWithValue("@Name", shoename);
                    command2.Parameters.AddWithValue("@category", category);
                    command2.Parameters.AddWithValue("@Id", uID);
                    result = command2.ExecuteScalar();

                }


                avgRate = Convert.ToDecimal(result);


                using (SqlCommand command3 = new SqlCommand(finalInsert, connection))

                {

                    command3.Parameters.AddWithValue("@rating", avgRate);
                    command3.Parameters.AddWithValue("@Sname", shoename);
                    //command3.Parameters.AddWithValue("@Id", uID);
                    command3.ExecuteNonQuery();
                    connection.Close();

                }

                //using (SqlCommand command3 = new SqlCommand(finalClear, connection))

                //{

                //    command3.Parameters.AddWithValue("@rating", avgRate);
                //    command3.Parameters.AddWithValue("@Sname", shoename);
                //    //command3.Parameters.AddWithValue("@Id", uID);
                //    command3.ExecuteNonQuery();
                //    connection.Close();

                //}

            }



            //foreach (RepeaterItem item in rateShoes.Items)

            //{

            //    // Find controls within the current item

            //    Label lblshoename = (Label)item.FindControl("lblshoename");

            //    Label lblcat = (Label)item.FindControl("lblcat");

            //    DropDownList ddlrate = (DropDownList)item.FindControl("ddlrate");


            //    // Retrieve shoe name and selected rating

            //    string shoename = lblshoename.Text;

            //    string category = lblcat.Text;

            //    int selectedRating = Convert.ToInt32(ddlrate.SelectedValue);


            //    // Perform any further actions with shoename and selectedRating

            //    // For example, you can execute SQL queries with these values

            //    // Replace this with your SQL execution logic


            //    string query2 = @"

            //SELECT AVG(total_rating) AS average_rating

            //FROM (

            //    SELECT SUM(Rating) AS total_rating

            //    FROM UserPurchases

            //    WHERE ShoeName = @Name AND Category = @Category

            //    GROUP BY ShoeName, Category

            //) AS subquery_alias";

            //    object result;

            //    decimal avgRate;


            //    string finalInsert = $"Update [{category}] Set Rating = @rating Where ShoeName = @Sname";


            //    using (SqlConnection connection = new SqlConnection(CS))

            //    {

            //        string query = "Update UserPurchases Set Rating = @Rating where Username = @username And ShoeName = @shoename";

            //        using (SqlCommand command = new SqlCommand(query, connection))

            //        {

            //            connection.Open();

            //            command.Parameters.AddWithValue("@Rating", selectedRating);

            //            command.Parameters.AddWithValue("@username", user);

            //            command.Parameters.AddWithValue("@shoename", shoename);

            //            command.ExecuteNonQuery();

            //        }


            //        using (SqlCommand command2 = new SqlCommand(query2, connection))
            //        {

            //            command2.Parameters.AddWithValue("@Name", shoename);
            //            command2.Parameters.AddWithValue("@category", category);
            //            result = command2.ExecuteScalar();

            //        }


            //        avgRate = Convert.ToDecimal(result);


            //        using (SqlCommand command3 = new SqlCommand(finalInsert, connection))

            //        {

            //            command3.Parameters.AddWithValue("@rating", avgRate);
            //            command3.Parameters.AddWithValue("@Sname", shoename);
            //            command3.ExecuteNonQuery();

            //        }

            //    }

            //}

        }


    }
}