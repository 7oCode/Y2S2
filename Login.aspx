<%@ Page Title="" Language="C#" MasterPageFile="~/EComms.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppProject.Login" %>

<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="layout_padding collection_section">
        <div class="container">
            <h1 class="new_text" style="text-align: center"><strong>Login</strong></h1>
            <br />
            <br />

            <div style="padding-left: 42%">


                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

                <br />

                <br />
                <%--                <form runat="server">--%>
                <asp:TextBox ID="loginUsername" Placeholder="Username" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="loginPassword" Placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="loginPin" Placeholder="PIN" TextMode="Password" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:DropDownList ID="userCheck" runat="server">
                    <asp:ListItem Text="User" Value="User" />
                    <asp:ListItem Text="Admin" Value="Admin" />
                </asp:DropDownList>
                <br />
                <br />
                <br />
                <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginUser" />
                <%--                </form>--%>
                <br />

                <span><a href="ForgetPW.aspx">Forgot your password?</a></span><br />
                <span><a href="Register">Don't have an account? Register here!</a></span>

            </div>

        </div>
    </div>

</asp:Content>
