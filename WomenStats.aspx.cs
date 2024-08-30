using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebAppProject
{
    public partial class WomenStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetWomenDailyData();
            GetWomenLongData();
            GetWomenRacingData();
        }

        private void GetWomenDailyData()
        {
            string cs = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                // Command to retrieve Students data from Students table
                SqlCommand cmd = new
                SqlCommand("Select ShoeName, TimesBought from Women_Daily", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                // Retrieve the Series to which we want to add DataPoints
                Series series = Chart1.Series["Series1"];
                // Loop thru each Student record
                while (rdr.Read())
                {
                    // Add X and Y values using AddXY() method
                    series.Points.AddXY(rdr["ShoeName"].ToString(),
                    rdr["TimesBought"]);
                }
            }
        }
        private void GetWomenLongData()
        {
            string cs = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                // Command to retrieve Students data from Students table
                SqlCommand cmd = new
                SqlCommand("Select ShoeName, TimesBought from Women_Long", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                // Retrieve the Series to which we want to add DataPoints
                Series series = Chart2.Series["Series1"];
                // Loop thru each Student record
                while (rdr.Read())
                {
                    // Add X and Y values using AddXY() method
                    series.Points.AddXY(rdr["ShoeName"].ToString(),
                    rdr["TimesBought"]);
                }
            }
        }

        private void GetWomenRacingData()
        {
            string cs = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                // Command to retrieve Students data from Students table
                SqlCommand cmd = new
                SqlCommand("Select ShoeName, TimesBought from Women_Racing", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                // Retrieve the Series to which we want to add DataPoints
                Series series = Chart3.Series["Series1"];
                // Loop thru each Student record
                while (rdr.Read())
                {
                    // Add X and Y values using AddXY() method
                    series.Points.AddXY(rdr["ShoeName"].ToString(),
                    rdr["TimesBought"]);
                }
            }
        }

        private string shoeCheck()
        {
            string toAdd = " ";
            if (!String.IsNullOrEmpty(uShoeName.Text))
            {
                toAdd += " ShoeName = @ShoeName";
            }

            if (!String.IsNullOrEmpty(uShoePrice.Text))
            {
                toAdd += " ,ShoePrice = @ShoePrice";
            }

            if (!String.IsNullOrEmpty(uShoeRating.Text))
            {
                toAdd += " ,Rating = @Rating";

            }
            if (!String.IsNullOrEmpty(uShoeImage.Text))
            {
                toAdd += " Image = @Image";
            }
            return toAdd;
        }



        protected void Execute_OnClick(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            if (TableName.SelectedValue == "Women_Daily")
            {
                if (ActionName.SelectedValue == "Insert")
                {
                    string insert2 = "Insert into Women_Daily (ShoeName, ShoePrice, Rating, Image ) values (@ShoeName, @ShoePrice, @Rating, @Image)";
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(insert2, con))
                        {
                            cmd.Parameters.AddWithValue("@ShoeName", uShoeName.Text);
                            cmd.Parameters.AddWithValue("@ShoePrice", uShoePrice.Text);
                            cmd.Parameters.AddWithValue("@Rating", uShoeRating.Text);
                            cmd.Parameters.AddWithValue("@Image", uShoeImage.Text);
                            cmd.ExecuteNonQuery();
                            Response.Redirect("WomenStats.aspx");
                        }


                    }

                }
                else
                {
                    string insert2 = "UPDATE Women_Daily SET ";
                    string toAdd = shoeCheck();
                    insert2 += toAdd + " where Id = @Id";
                    if (insert2.Contains(", where Id = @Id"))
                    {
                        string uInsert = insert2.Replace(", where Id = @Id", " where Id = @Id");
                        using (SqlConnection con = new SqlConnection(cs))
                        {

                            con.Open();
                            using (SqlCommand cmd = new SqlCommand(uInsert, con))
                            {
                                cmd.Parameters.AddWithValue("@ShoeName", uShoeName.Text);
                                cmd.Parameters.AddWithValue("@ShoePrice", uShoePrice.Text);
                                cmd.Parameters.AddWithValue("@Rating", uShoeRating.Text);
                                cmd.Parameters.AddWithValue("@Image", uShoeImage.Text);
                                cmd.Parameters.AddWithValue("@Id", uShoeId.Text);
                                cmd.ExecuteNonQuery();
                                Response.Redirect("MenStats.aspx");

                            }


                        }
                    }
                }



            }
            else if (TableName.SelectedValue == "Women_Long")
            {
                if (ActionName.SelectedValue == "Insert")
                {
                    string insert2 = "Insert into Women_Long (ShoeName, ShoePrice, Rating, Image ) values (@ShoeName, @ShoePrice, @Rating, @Image)";
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(insert2, con))
                        {
                            cmd.Parameters.AddWithValue("@ShoeName", uShoeName.Text);
                            cmd.Parameters.AddWithValue("@ShoePrice", uShoePrice.Text);
                            cmd.Parameters.AddWithValue("@Rating", uShoeRating.Text);
                            cmd.Parameters.AddWithValue("@Image", uShoeImage.Text);
                            cmd.ExecuteNonQuery();
                            Response.Redirect("WomenStats.aspx");

                        }


                    }

                }
                else
                {
                    string insert2 = "UPDATE Women_Long SET ";
                    string toAdd = shoeCheck();
                    insert2 += toAdd + " where Id = @Id";
                    if (insert2.Contains(", where Id = @Id"))
                    {
                        string uInsert = insert2.Replace(", where Id = @Id", " where Id = @Id");
                        using (SqlConnection con = new SqlConnection(cs))
                        {

                            con.Open();
                            using (SqlCommand cmd = new SqlCommand(uInsert, con))
                            {
                                cmd.Parameters.AddWithValue("@ShoeName", uShoeName.Text);
                                cmd.Parameters.AddWithValue("@ShoePrice", uShoePrice.Text);
                                cmd.Parameters.AddWithValue("@Rating", uShoeRating.Text);
                                cmd.Parameters.AddWithValue("@Image", uShoeImage.Text);
                                cmd.Parameters.AddWithValue("@Id", uShoeId.Text);
                                cmd.ExecuteNonQuery();
                                Response.Redirect("MenStats.aspx");

                            }


                        }
                    }
                }
            }
            else
            {
                if (ActionName.SelectedValue == "Insert")
                {
                    string insert2 = "Insert into Women_Racing (ShoeName, ShoePrice, Rating, Image ) values (@ShoeName, @ShoePrice, @Rating, @Image)";
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(insert2, con))
                        {
                            cmd.Parameters.AddWithValue("@ShoeName", uShoeName.Text);
                            cmd.Parameters.AddWithValue("@ShoePrice", uShoePrice.Text);
                            cmd.Parameters.AddWithValue("@Rating", uShoeRating.Text);
                            cmd.Parameters.AddWithValue("@Image", uShoeImage.Text);
                            cmd.ExecuteNonQuery();
                            Response.Redirect("WomenStats.aspx");

                        }


                    }

                }
                else
                {
                    string insert2 = "UPDATE Women_Racing SET ";
                    string toAdd = shoeCheck();
                    insert2 += toAdd + " where Id = @Id";
                    if (insert2.Contains(", where Id = @Id"))
                    {
                        string uInsert = insert2.Replace(", where Id = @Id", " where Id = @Id");
                        using (SqlConnection con = new SqlConnection(cs))
                        {

                            con.Open();
                            using (SqlCommand cmd = new SqlCommand(uInsert, con))
                            {
                                cmd.Parameters.AddWithValue("@ShoeName", uShoeName.Text);
                                cmd.Parameters.AddWithValue("@ShoePrice", uShoePrice.Text);
                                cmd.Parameters.AddWithValue("@Rating", uShoeRating.Text);
                                cmd.Parameters.AddWithValue("@Image", uShoeImage.Text);
                                cmd.Parameters.AddWithValue("@Id", uShoeId.Text);
                                cmd.ExecuteNonQuery();
                                Response.Redirect("MenStats.aspx");

                            }


                        }
                    }
                }
            }

        }

        protected void rowDelete4(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            string UserID = Women_DailyShoe.DataKeys[e.RowIndex].Value.ToString();
            result = prod.ShoeDelete(UserID);
            if (result > 0)
            {
                retResult.Text = "Record Deleted Successfully!";
                retResult.Visible = true;
                Response.Redirect("WomenStats.aspx");

            }
            else
            {
                retResult.Visible = true;
            }

            // Set the parameter value for the DeleteCommand

        }

        protected void rowDelete5(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            string UserID = Women_LongShoes.DataKeys[e.RowIndex].Value.ToString();
            result = prod.ShoeDelete2(UserID);
            if (result > 0)
            {
                retResult.Text = "Record Deleted Successfully!";
                retResult.Visible = true;
                Response.Redirect("WomenStats.aspx");

            }
            else
            {
                retResult.Visible = true;
            }
        }

        protected void rowDelete6(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            string UserID = Women_RacingShoes.DataKeys[e.RowIndex].Value.ToString();
            result = prod.ShoeDelete3(UserID);
            if (result > 0)
            {
                retResult.Text = "Record Deleted Successfully!";
                retResult.Visible = true;
                Response.Redirect("WomenStats.aspx");

            }
            else
            {
                retResult.Visible = true;
            }
        }

    }
}