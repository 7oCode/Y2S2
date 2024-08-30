using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace WebAppProject
{
    public partial class MenStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMenDailyData();
            GetMenLongData();
            GetMenRacingData();
        }


        private void GetMenDailyData()
        {
            string cs = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                // Command to retrieve Students data from Students table
                SqlCommand cmd = new
                SqlCommand("Select ShoeName, TimesBought from Men_Daily", con);
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
        private void GetMenLongData()
        {
            string cs = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                // Command to retrieve Students data from Students table
                SqlCommand cmd = new
                SqlCommand("Select ShoeName, TimesBought from Men_Long", con);
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

        private void GetMenRacingData()
        {
            string cs = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                // Command to retrieve Students data from Students table
                SqlCommand cmd = new
                SqlCommand("Select ShoeName, TimesBought from Men_Racing", con);
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
                toAdd += " ShoeName = @ShoeName,";
            }

            if (!String.IsNullOrEmpty(uShoePrice.Text))
            {
                toAdd += " ShoePrice = @ShoePrice,";
            }

            if (!String.IsNullOrEmpty(uShoeRating.Text))
            {
                toAdd += " Rating = @Rating,";

            }
            if (!String.IsNullOrEmpty(uShoeImage.Text))
            {
                toAdd += " Image = @Image,";
            }
            return toAdd;
        }



        protected void Execute_OnClick(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString;
            if (TableName.SelectedValue == "Men_Daily")
            {
                if (ActionName.SelectedValue == "Insert")
                {
                    string insert2 = "Insert into Men_Daily (ShoeName, ShoePrice, Rating, Image ) values (@ShoeName, @ShoePrice, @Rating, @Image)";
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
                            Response.Redirect("MenStats.aspx");
                        }


                    }

                }
                else
                {
                    string insert2 = "UPDATE Men_Daily SET ";
                    string toAdd = shoeCheck();
                    insert2 += toAdd + " where Id = @Id";
                    if(insert2.Contains(", where Id = @Id"))
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
            else if (TableName.SelectedValue == "Men_Long")
            {
                if (ActionName.SelectedValue == "Insert")
                {
                    string insert2 = "Insert into Men_Long (ShoeName, ShoePrice, Rating, Image ) values (@ShoeName, @ShoePrice, @Rating, @Image)";
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
                            Response.Redirect("MenStats.aspx");

                        }


                    }

                }
                else
                {
                    string insert2 = "UPDATE Men_Long SET ";
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
                    string insert2 = "Insert into Men_Racing (ShoeName, ShoePrice, Rating, Image ) values (@ShoeName, @ShoePrice, @Rating, @Image)";
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
                            Response.Redirect("MenStats.aspx");

                        }


                    }

                }
                else
                {
                    string insert2 = "UPDATE Men_Racing SET ";
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

        protected void rowDelete(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            string UserID = Mens_DailyShoe.DataKeys[e.RowIndex].Value.ToString();
            result = prod.ShoeDelete(UserID);
            if (result > 0)
            {
                retResult.Text = "Record Deleted Successfully!";
                retResult.Visible = true;
                Response.Redirect("MenStats.aspx");

            }
            else
            {
                retResult.Visible = true;
            }

            // Set the parameter value for the DeleteCommand

        }

        protected void rowDelete2(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            string UserID = Men_LongShoes.DataKeys[e.RowIndex].Value.ToString();
            result = prod.ShoeDelete2(UserID);
            if (result > 0)
            {
                retResult.Text = "Record Deleted Successfully!";
                retResult.Visible = true;
                Response.Redirect("MenStats.aspx");

            }
            else
            {
                retResult.Visible = true;
            }
        }

        protected void rowDelete3(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            string UserID = Men_RacingShoes.DataKeys[e.RowIndex].Value.ToString();
            result = prod.ShoeDelete3(UserID);
            if (result > 0)
            {
                retResult.Text = "Record Deleted Successfully!";
                retResult.Visible = true;
                Response.Redirect("MenStats.aspx");

            }
            else
            {
                retResult.Visible = true;
            }
        }



        //protected void rowUpdate(object sender, GridViewUpdatedEventArgs e)
        //{
        //    int result = 0;
        //    Product prod = new Product();
        //    string UserID = (string)Mens_DailyShoe.DataKeys[e.AffectedRows].Value;
        //    string name = Mens_DailyShoe.Rows[e.AffectedRows].Cells[2].Text;
        //    string price = Mens_DailyShoe.Rows[e.AffectedRows].Cells[3].Text;
        //    string rating = Mens_DailyShoe.Rows[e.AffectedRows].Cells[4].ToString();
        //    string image = Mens_DailyShoe.Rows[e.AffectedRows].Cells[5].Text;
        //    Console.WriteLine(name);
        //    Console.WriteLine(price);
        //    Console.WriteLine(rating);
        //    Console.WriteLine(image);

        //    result = prod.ShoeUpdate(UserID, name, price, rating, image);
        //    if (result == 1)
        //    {
        //        Response.Redirect("MenStats.aspx");
        //    }
        //    else
        //    {
        //        retResult.Text = "Error in Updating";
        //        retResult.Visible = true;
        //    }
        //}
    }
}