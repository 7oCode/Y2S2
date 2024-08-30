using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebAppProject
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Home", "", "~/Home.aspx");

            routes.MapPageRoute("Men", "Men", "~/Men.aspx");
            routes.MapPageRoute("Women", "Women", "~/Women.aspx");
            routes.MapPageRoute("Unisex", "Unisex", "~/Unisex.aspx");

            routes.MapPageRoute("LoggedMen", "LoggedMen", "~/LoggedMen.aspx");
            routes.MapPageRoute("LoggedWomen", "LoggedWomen", "~/LoggedWomen.aspx");
            routes.MapPageRoute("LoggedUnisex", "LoggedUnisex", "~/LoggedUnisex.aspx");
            routes.MapPageRoute("History", "History", "~/History.aspx");
            routes.MapPageRoute("UserCart", "UserCart", "~/UserCart.aspx");



            routes.MapPageRoute("MenStats", "MenStats", "~/MenStats.aspx");
            routes.MapPageRoute("WomenStats", "WomenStats", "~/WomenStats.aspx");

            //routes.MapPageRoute("Unisex", "Unisex", "~/Unisex.aspx");



            routes.MapPageRoute("Register", "Register", "~/Register.aspx");
            routes.MapPageRoute("Login", "Login", "~/Login.aspx");
            routes.MapPageRoute("UserPage", "UserPage", "~/LoggedHome.aspx");
            routes.MapPageRoute("AdminPage", "AdminPage", "~/AdminHome.aspx");



            routes.MapPageRoute("SearchShoes", "Search", "~/Search.aspx");
            routes.MapPageRoute("SearchAfterLogin", "UserSearch", "~/SearchAfterLogin.aspx");


        }


        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}