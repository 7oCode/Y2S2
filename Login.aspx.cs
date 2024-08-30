using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Salt_Password_Sample;
using System.Web.Services.Description;
using System.Text.RegularExpressions;


namespace WebAppProject
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginUser(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(loginUsername.Text) || String.IsNullOrEmpty(loginPassword.Text))
            {
                lblMessage.Text = "Please fill in all fields";
                return;
            }
            else if (userCheck.SelectedValue == "User")
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString);
                string checkUser = "Select * from [User] where Username = @username";
                using (SqlCommand cmd = new SqlCommand(checkUser, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@username", loginUsername.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string hashedPassword = reader["Password"].ToString();
                        string hashedPin = reader["PIN"].ToString();
                        if (Hash.VerifyHash(loginPassword.Text, "SHA512", hashedPassword) && Hash.VerifyHash(loginPin.Text, "SHA512", hashedPin))
                        {
                            Session["CHANGE_MASTERPAGE"] = "~/AfterLogin.Master";
                            Session["CHANGE_MASTERPAGE2"] = null;
                            Session["User"] = loginUsername.Text;

                            Response.Redirect("UserPage");

                            //lblMessage.Text = "Login Successful";
                        }
                        else
                        {
                            //Response.Write("<script>alert('Invalid Password');</script>");
                            lblMessage.Text = "Invalid Password";
                        }
                    }
                    else
                    {
                        //Response.Write("<script>alert('Invalid Username');</script>");
                        lblMessage.Text = "Invalid Username";
                    }
                    conn.Close();
                    loginUsername.Text = "";
                }
            }
            else
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString);
                string checkUser = "Select * from [Admin] where Username = @username";
                using (SqlCommand cmd = new SqlCommand(checkUser, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@username", loginUsername.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string hashedPassword = reader["Password"].ToString();
                        string hashedPin = reader["PIN"].ToString();
                        if (Hash.VerifyHash(loginPassword.Text, "SHA512", hashedPassword) && Hash.VerifyHash(loginPin.Text, "SHA512", hashedPin))
                        {
                            Session["CHANGE_MASTERPAGE"] = "~/Admin.Master";
                            Session["CHANGE_MASTERPAGE2"] = null;
                            Session["User"] = loginUsername.Text;

                            Response.Redirect("AdminPage");

                            //lblMessage.Text = "Login Successful";
                        }
                        else
                        {
                            //Response.Write("<script>alert('Invalid Password');</script>");
                            lblMessage.Text = "Invalid Password";
                        }
                    }
                    else
                    {
                        //Response.Write("<script>alert('Invalid Username');</script>");
                        lblMessage.Text = "Invalid Username";
                    }
                    conn.Close();
                    loginUsername.Text = "";
                }
            }

        }
        static bool IsValidEmail(string email)
        {
            // Define a regular expression pattern for validating email addresses
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Create a Regex object with the pattern
            Regex regex = new Regex(pattern);

            // Use the IsMatch method to check if the email matches the pattern
            return regex.IsMatch(email);
        }

        static bool IsValidPassword(string password)
        {
            // Define a regular expression pattern for validating the password
            string pattern = @"^(?=.*[A-Za-z0-9])(?=.*[@$!%*?&])[A-Za-z0-9@$!%*?&]{8}$";

            // Create a Regex object with the pattern
            Regex regex = new Regex(pattern);

            // Use the IsMatch method to check if the password matches the pattern
            return regex.IsMatch(password);
        }

        static bool IsValidPIN(string pin)
        {
            // Define a regular expression pattern for validating the PIN
            string pattern = @"^\d{4,}$";

            // Create a Regex object with the pattern
            Regex regex = new Regex(pattern);

            // Use the IsMatch method to check if the PIN matches the pattern
            return regex.IsMatch(pin);
        }

    }
}