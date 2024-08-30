using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Salt_Password_Sample;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace WebAppProject
{
    public partial class Register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerUser(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString);
            string chosen = ddl.SelectedItem.Value;
            if (chosen == "User")
            {

                string checkUser = "Select count(*) from [User] where Username = @username and Email =@email";
                using (SqlCommand cmd = new SqlCommand(checkUser, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@username", regUser.Text);
                    cmd.Parameters.AddWithValue("@email", regEmail.Text);
                    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (temp == 1)
                    {
                        lblMessage.Text = "User already exists";
                        regEmail.Text = "";
                        regPassword.Text = "";
                    }
                    else
                    {
                        //write code for regex to check for valid email
                        //write code for regex for valid password
                        DateTime date = DateTime.Now;
                        if (!IsValidEmail(regEmail.Text))
                        {
                            emailValid.Visible = true;
                        }

                        if (!IsValidPassword(regPassword.Text))
                        {
                            pwValid.Visible = true;
                        }

                        //if (!IsValidPIN(regPin.Text))
                        //{
                        //    pinValid.Visible = true;
                        //}

                        if (IsValidEmail(regEmail.Text) && IsValidPassword(regPassword.Text))
                        {
                            sendregEmail();
                            cfmButton.Visible = true;
                            cfmReg.Visible = true;

                            pwValid.Visible = true;
                            pwValid.Text = "Enter Password again";
                            regPin.Visible = true;
                            //pinValid.Visible = true;
                            //pinValid.Text = "Enter PIN again";
                            Session["rType"] = "User";
                            ddl.Visible = false;

                            regButton.Visible = false;
                        }
                        else
                        {
                            lblMessage.Text = "Error in Registering";
                        }
                        //string insertQuery = "Insert into [User] (Username, Email, Password, PIN, RegisterDate) values (@username, @email, @password, @pin, @regdate)";
                        //using (SqlCommand cmd2 = new SqlCommand(insertQuery, conn))
                        //{
                        //    string salt = null;
                        //    string hashedPassword = Hash.ComputeHash(regPassword.Text, "SHA512", null);
                        //    string hashPin = Hash.ComputeHash(regPin.Text, "SHA512", null);
                        //    cmd2.Parameters.AddWithValue("@username", regUser.Text);
                        //    cmd2.Parameters.AddWithValue("@email", regEmail.Text);
                        //    cmd2.Parameters.AddWithValue("@password", hashedPassword);
                        //    cmd2.Parameters.AddWithValue("@pin", hashPin);
                        //    cmd2.Parameters.AddWithValue("@regdate", date);
                        //    //cmd2.Parameters.AddWithValue("@salt", salt);
                        //    cmd2.ExecuteNonQuery();
                        //    lblMessage.Text = "Registration Successful";
                        //    Response.Redirect("Login.aspx");
                        //}
                    }
                    conn.Close();
                    //regEmail.Text = "";
                }

            }
            else if (chosen == "Admin")
            {
                string checkUser = "Select count(*) from [Admin] where Username = @username and Email=@email";
                using (SqlCommand cmd = new SqlCommand(checkUser, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@username", regUser.Text);
                    cmd.Parameters.AddWithValue("@email", regEmail.Text);
                    int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (temp == 1)
                    {
                        lblMessage.Text = "Admin already exists";
                        regEmail.Text = "";
                        regPassword.Text = "";
                    }
                    else
                    {
                        //write code for regex to check for valid email
                        //write code for regex for valid password
                        DateTime date = DateTime.Now;

                        if (!IsValidEmail(regEmail.Text))
                        {
                            emailValid.Visible = true;
                        }

                        if (!IsValidPassword(regPassword.Text))
                        {
                            pwValid.Visible = true;
                        }

                        //if (!IsValidPIN(regPin.Text))
                        //{
                        //    pinValid.Visible = true;
                        //}

                        if (IsValidEmail(regEmail.Text) && IsValidPassword(regPassword.Text))
                        {

                            sendregEmail();
                            cfmButton.Visible = true;
                            cfmReg.Visible = true;

                            pwValid.Visible = true;
                            pwValid.Text = "Enter Password again";
                            //pinValid.Visible = true;
                            //pinValid.Text = "Enter PIN again";
                            regPin.Visible = true;

                            Session["rType"] = "Admin";
                            ddl.Visible = false;

                            regButton.Visible = false;


                        }
                        else
                        {
                            lblMessage.Text = "Error in Registering";
                        }
                        //string insertQuery = "Insert into [Admin] (Username, Email, Password, PIN, RegisterDate) values (@username, @email, @password, @pin, @regdate)";
                        //using (SqlCommand cmd2 = new SqlCommand(insertQuery, conn))
                        //{
                        //    string salt = null;
                        //    string hashedPassword = Hash.ComputeHash(regPassword.Text, "SHA512", null);
                        //    string hashPin = Hash.ComputeHash(regPin.Text, "SHA512", null);
                        //    cmd2.Parameters.AddWithValue("@username", regUser.Text);
                        //    cmd2.Parameters.AddWithValue("@email", regEmail.Text);
                        //    cmd2.Parameters.AddWithValue("@password", hashedPassword);
                        //    cmd2.Parameters.AddWithValue("@pin", hashPin);
                        //    cmd2.Parameters.AddWithValue("@regdate", date);
                        //    //cmd2.Parameters.AddWithValue("@salt", salt);
                        //    cmd2.ExecuteNonQuery();
                        //    lblMessage.Text = "Registration Successful";
                        //    Response.Redirect("Login.aspx");
                        //}
                    }
                    conn.Close();
                    //regUser.Text = "";
                    //regEmail.Text = "";
                    //regPassword.Text = "";
                }
            }
        }

        protected void verifyRegister(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString);
            DateTime date = DateTime.Now;
            //string nCheck = Session["numCheck"].ToString();
            string nCheck = Session["NumCheck"].ToString();
            string rType = Session["rType"].ToString();
            if (cfmReg.Text.Equals(nCheck))
            {
                string insertQuery = $"Insert into [{rType}](Username, Email, Password, PIN, RegisterDate) values (@username, @email, @password, @pin, @regdate)";
                using (SqlCommand cmd2 = new SqlCommand(insertQuery, conn))
                {
                    conn.Open();
                    string salt = null;
                    string hashedPassword = Hash.ComputeHash(regPassword.Text, "SHA512", null);
                    string hashPin = Hash.ComputeHash(regPin.Text, "SHA512", null);
                    cmd2.Parameters.AddWithValue("@username", regUser.Text);
                    cmd2.Parameters.AddWithValue("@email", regEmail.Text);
                    cmd2.Parameters.AddWithValue("@password", hashedPassword);
                    cmd2.Parameters.AddWithValue("@pin", hashPin);
                    cmd2.Parameters.AddWithValue("@regdate", date);
                    //cmd2.Parameters.AddWithValue("@salt", salt);
                    cmd2.ExecuteNonQuery();
                    lblMessage.Text = "Registration Successful";
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid Verification Code";
                cfmReg.Visible = false;
                regButton.Visible = true;
                regUser.Text= "";
                regEmail.Text = "";
                regPassword.Text = "";
                regPin.Text = "";
                

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


        private void sendregEmail()
        {
            //try
            //{
            //    Random random = new Random();

            //    int value = random.Next(1000, 9999);
            //    Session["numCheck"] = value.ToString();
            //    MailMessage mail = new MailMessage();
            //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //    mail.From = new MailAddress("stu7odent@gmail.com");
            //    mail.To.Add(regEmail.Text);
            //    mail.Subject = "Verification Code";
            //    mail.Body = "Your verification code is: " + value.ToString();
            //    SmtpServer.Port = 587;
            //    SmtpServer.Credentials = new System.Net.NetworkCredential("stu7odent@gmail.com", "mctt zboh fxyn idlf");
            //    SmtpServer.EnableSsl = true;
            //    SmtpServer.Send(mail);
            //    cfmReg.Visible = true;
            //    regButton.Visible = false;

            //}
            //catch (Exception ex)
            //{
            //    lblMessage.Text = ex.ToString();

            //}

            try
            {
                Random random = new Random();

                int value = random.Next(1000, 9999);
                int upin = random.Next(100000, 999999);
                Session["numCheck"] = value.ToString();
                Session["uPin"] = upin.ToString();
                string from = "stu7odent@gmail.com";
                string mypass = "mctt zboh fxyn idlf";
                MailMessage noti = new MailMessage();
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                noti.From = new MailAddress(from);
                noti.To.Add(regEmail.Text);
                noti.Subject = "Verification Code";
                noti.Body = "Your verification code is: " + value.ToString() + " and PIN is: " + upin.ToString();

                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential(from, mypass);
                sc.EnableSsl = true;
                sc.Send(noti);
                cfmReg.Visible = true;
                regButton.Visible = false;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }


        }






    }
}