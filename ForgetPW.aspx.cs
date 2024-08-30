using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using Salt_Password_Sample;


namespace WebAppProject
{
    public partial class ForgetPW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void checkUser(object sender, EventArgs e)
        {
            string type = fCheck.SelectedValue;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString);
            string check1 = $"Select * from [{type}] where Username = @username And Email = @email";
            string updateCheck = $"Update [{type}] set Password = @password where Username = @username and Email = @email";
            using (SqlCommand cmd = new SqlCommand(check1, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@username", fusername.Text);
                cmd.Parameters.AddWithValue("@email", fEmail.Text);
                //cmd.Parameters.AddWithValue("@pin", Hash.ComputeHash(fPin.Text, "SHA512", null));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //string hashedPassword = reader["Password"].ToString();
                    //string hashedPin = reader["PIN"].ToString();
                    //if (Hash.VerifyHash(fPassword.Text, "SHA512", hashedPassword) && Hash.VerifyHash(fPin.Text, "SHA512", hashedPin))
                    //{
                    //    Session["CHANGE_MASTERPAGE"] = "~/AfterLogin.Master";
                    //    Session["CHANGE_MASTERPAGE2"] = null;
                    //    Session["User"] = fusername.Text;

                    //    Response.Redirect("UserPage");

                    //    //lblMessage.Text = "Login Successful";
                    //}
                    //else
                    //{
                    //    //Response.Write("<script>alert('Invalid Password');</script>");
                    //    lblMessage.Text = "Invalid Password";
                    //}

                    SendForget();
                    //using (SqlCommand cmd2 = new SqlCommand(updateCheck, conn))
                    //{
                    //    cmd2.Parameters.AddWithValue("@password", Hash.ComputeHash(newPW.Text, "SHA512", null));
                    //    cmd2.Parameters.AddWithValue("@username", fusername.Text);
                    //    cmd2.Parameters.AddWithValue("@email", fEmail.Text);
                    //    cmd2.ExecuteNonQuery();
                    //}
                    conn.Close();
                    
                }
                else
                {
                    lblMessage.Text = "Invalid Username, Email or PIN";
                }

            }



        }

        protected void resetPW(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WebAppProject"].ConnectionString);

            string uType = Session["uType"].ToString();
            string query = $"Update [{uType}] set Password = @password where Username = @username and Email = @email";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@password", Hash.ComputeHash(newPW.Text, "SHA512", null));
                cmd.Parameters.AddWithValue("@username", fusername.Text);
                cmd.Parameters.AddWithValue("@email", fEmail.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("Login");
            }

        }


        private void SendForget()
        {
            //Your implementation to send email

            try
            {
                Random random = new Random();

                int value = random.Next(1000, 9999);
                Session["numCheck"] = value.ToString();
                Session["uType"] = fCheck.SelectedValue;
                string from = "stu7odent@gmail.com";
                string mypass = "mctt zboh fxyn idlf";
                MailMessage noti = new MailMessage();
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                noti.From = new MailAddress(from);
                noti.To.Add(fEmail.Text);
                noti.Subject = "Reset Code";
                noti.Body = "Your reset code is: " + value.ToString();

                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential(from, mypass);
                sc.EnableSsl = true;
                sc.Send(noti);


                newPW.Visible= true;
                veriNum.Visible = true;
                resetBtn.Visible = true;
                shPin.Visible = true;

                fCheck.Visible = false;
                fButton.Visible = false;

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }

    }
}