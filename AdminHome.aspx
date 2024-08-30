<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="WebAppProject.AdminHome" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="layout_padding collection_section">
        <div class="container">
            <h1 class="new_text"><strong>Admin Page</strong></h1>
            <p class="consectetur_text">All Registered Users</p>



            <div class="container">


                <div class="row">
                    <div class="col-md-6">
                        
                        
                    </div>
                </div>
                <div class="row">


                    <div class="col-md-6">
                        <h1>All Users</h1>
                        <asp:Label ID="retResult" Text="Error in deleting" Visible="false" runat="server" />
                        <br />

                        <asp:GridView ID="viewUsers" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="ID" OnRowDeleting="rowDeleting">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID"></asp:BoundField>
                                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"></asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
                                <asp:CommandField ShowDeleteButton="True"></asp:CommandField>
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebAppProject %>" SelectCommand="SELECT [ID], [Username], [Email] FROM [User]"></asp:SqlDataSource>

                    </div>
                </div>


            </div>
        </div>
    </div>

</asp:Content>
