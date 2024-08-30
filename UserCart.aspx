<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin.Master" AutoEventWireup="true" CodeBehind="UserCart.aspx.cs" Inherits="WebAppProject.UserCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Cart</h1>
                <asp:Label ID="retResult" Text="Error in deleting" Visible="false" runat="server" />

                <asp:GridView ID="CartGrid" AutoGenerateColumns="False" runat="server" DataKeyNames="Id" OnRowDeleting="rowDelete">


                    <Columns>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="lblShoeCat" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Shoe Size">
                            <ItemTemplate>
                                <asp:Label ID="lblsize" runat="server" Text='<%# Eval("ShoeSize") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Price">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalPrice" runat="server" Text='<%# Eval("TotalPrice") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />

                </asp:GridView>
                <hr />
                <asp:Label ID="tPrice" runat="server" Text="Total Price: " Visible="false"></asp:Label>
                <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="checkOut" Visible="false" />

                <asp:Label
                    ID="lblnone"
                    runat="server" Text="Nothing in Cart yet, add something first!" Visible="false"></asp:Label>
                <%--                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebAppProject %>" DeleteCommand="DELETE FROM [UserCart] WHERE [Id] = @Id" SelectCommand="SELECT * FROM [UserCart]"></asp:SqlDataSource>--%>



                <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CartId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>

                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                        <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" SortExpression="TotalPrice" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>

                </asp:GridView>--%>
            </div>
        </div>
    </div>
</asp:Content>
