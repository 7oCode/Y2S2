<%@ Page Title="" Language="C#" MasterPageFile="~/EComms.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebAppProject.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="layout_padding collection_section">
        <div class="container">
            <h1 class="new_text" style="text-align: center"><strong>Register</strong></h1>

            <div style="padding-left: 42%">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <br />
                <br />

                <asp:TextBox ID="regUser" Placeholder="Username" runat="server"></asp:TextBox>

                <br />
                <br />
                <asp:TextBox ID="regEmail" Placeholder="Email" TextMode="Email" runat="server"></asp:TextBox>
                <asp:Label ID="emailValid" runat="server" Text="Invalid Email Format" Visible="false"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="regPassword" Placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="pwValid" runat="server" Text="Password must be 8 characters long, alphanumeric, and with special character" Visible="false"></asp:Label>

                <br />
                <br />
                <asp:TextBox ID="regPin" Placeholder="PIN" TextMode="Password" runat="server" Visible="false"></asp:TextBox>
                <asp:Label ID="pinValid" runat="server" Text="Only numbers, 4 numbers long" Visible="false"></asp:Label>

                <br />
                <br />
                <asp:TextBox ID="cfmReg" Placeholder="Confirmation Number"  runat="server" Visible="false"></asp:TextBox>


                <br />
                <br />
                <asp:DropDownList ID="ddl" runat="server">
                    <asp:ListItem Text="User" Value="User" />
                    <asp:ListItem Text="Admin" Value="Admin" />
                </asp:DropDownList>
                <br />
                <br />

                <asp:Button ID="regButton" runat="server" Text="Register" OnClick="registerUser" />
                <asp:Button ID="cfmButton" runat="server" Text="Confirm" OnClick="verifyRegister" Visible="false" />


            </div>

        </div>
    </div>
</asp:Content>
