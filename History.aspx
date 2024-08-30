<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="WebAppProject.History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>History</h1>

                <asp:GridView ID="HistGrid" AutoGenerateColumns="False" runat="server" DataKeyNames="Id">

                    <Columns>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label ID="lblShoeCat" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ShoeName") %>'></asp:Label>
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
                        <asp:TemplateField HeaderText="Date Bought">
                            <ItemTemplate>
                                <asp:Label ID="lblDateBought" runat="server" Text='<%# Eval("DateBought") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

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
                <br />
                <br />
                <asp:Button ID="ratePage" runat="server" Text="Rate Items" Visible="false" OnClick="toRatePage" />
                <br />
                <br />

                <asp:Label
                    ID="lblnone"
                    runat="server" Text="Nothing bought yet, add something first!" Visible="false"></asp:Label>

            </div>
        </div>
    </div>


</asp:Content>
