<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin.Master" AutoEventWireup="true" CodeBehind="RateProducts.aspx.cs" Inherits="WebAppProject.RateProducts" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layout_padding gallery_section">
        <div class="container">
            <h2>Rate Shoes</h2>
            <div class="row">
                <asp:Repeater ID="rateShoes" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="best_shoes">
                                <asp:Label ID="lblshoename" CssClass="best_shoes" Text='<%#Eval("ShoeName") %>' runat="server"></asp:Label>
                                <asp:Label ID="lblcat" CssClass="best_shoes" Text='<%#Eval("Category") %>' runat="server"></asp:Label>
                                <asp:Label ID="lblId" Text='<%#Eval("Id") %>' runat="server" Visible="false"></asp:Label>


                                <div class="shoes_icon">
                                    <asp:Image ID="lblshoeimg" CssClass="shoes_icon" runat="server" ImageUrl='<%#Eval("Image") %>' Width="200" Height="200" />
                                </div>
                                <div class="star_text">
                                    <div class="left_part">
                                        <asp:Label ID="lblshoeprice" runat="server" Text='<%#"Price: $" + Eval("ShoePrice") %>'></asp:Label>
                                        <asp:Label ID="lblshowsize" runat="server" Text='<%#Eval("ShoeSize") %>'></asp:Label>

                                        <br />
                                        <br />
                                        <asp:Label ID="lblshoequan" runat="server" Text='<%#"Quantity: " + Eval("Quantity") %>'></asp:Label>

                                        <asp:DropDownList ID="ddlrate" runat="server">
                                            <asp:ListItem Text="0" Value="0"></asp:ListItem>

                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        </asp:DropDownList>

                                        <%--                                        <asp:Label ID="lmao" runat="server" Text="is simply dummy text of the printing and typesetting industry. 
                                            Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
                                            It has survived not only five centuries, but also the leap into electronic typesetting,"></asp:Label>--%>
                                    </div>
                                    <div class="right_part">
                                        <asp:Label ID="lblMDailyPrice" CssClass="shoes_price" runat="server" ForeColor="#ff5e5b" Text='<%# "$" + Eval("TotalPrice") %>'></asp:Label>
                                        <asp:Button ID="rateAll" runat="server" Text="Rate Item" OnClick="ComputeButton_Click" />

                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>

</asp:Content>
