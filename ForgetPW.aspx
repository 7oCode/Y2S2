<%@ Page Title="" Language="C#" MasterPageFile="~/EComms.Master" AutoEventWireup="true" CodeBehind="ForgetPW.aspx.cs" Inherits="WebAppProject.ForgetPW" %>


<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="layout_padding collection_section">
        <div class="container">
            <h1 class="new_text" style="text-align: center"><strong>Forgot Password</strong></h1>
            <br />
            <br />

            <div style="padding-left: 42%">


                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

                <br />
                <asp:TextBox ID="fusername" Placeholder="Username" runat="server"></asp:TextBox>

                <br />
                <asp:TextBox ID="fEmail" Placeholder="Email" runat="server"></asp:TextBox>
                <br />
                <br />

                <asp:TextBox ID="fPin" Placeholder="PIN" TextMode="Password" runat="server"></asp:TextBox>
                <asp:Label ID="shPin" runat="server" Text="Enter PIN again" Visible="false"></asp:Label>

                <br />
                <br />

                <asp:TextBox ID="newPW" Placeholder="New Password" runat="server" TextMode="Password" Visible="false"></asp:TextBox>
                <br />
                <br />

                <asp:TextBox ID="veriNum" Placeholder="Verification Number" TextMode="Password" runat="server" Visible="false"></asp:TextBox>
                <br />
                <br />
                <asp:DropDownList ID="fCheck" runat="server">
                    <asp:ListItem Text="User" Value="User" />
                    <asp:ListItem Text="Admin" Value="Admin" />
                </asp:DropDownList>
                <br />
                <br />
                <br />
                <asp:Button ID="fButton" runat="server" Text="Send Email" OnClick="checkUser" />
                <asp:Button ID="resetBtn" runat="server" Text="Reset Password" Visible="false" OnClick="resetPW" />

                <br />

                <%--            <span><a href="#">Forgot your password?</a></span><br />
            <span><a href="Register">Don't have an account? Register here!</a></span>--%>
            </div>

        </div>
    </div>


</asp:Content>
