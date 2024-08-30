<%@ Page Title="" Language="C#" MasterPageFile="~/AfterLogin.Master" AutoEventWireup="true" CodeBehind="LoggedWomen.aspx.cs" Inherits="WebAppProject.LoggedWomen" EnableEventValidation="false" %>


<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Web" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layout_padding gallery_section">
        <div class="container">
            <h2>Women Daily</h2>
            <div class="row">
                <asp:Repeater ID="WomenDaily" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="best_shoes">
                                <asp:Label ID="lblMenDaily" CssClass="best_shoes" Text='<%#Eval("ShoeName") %>' runat="server"></asp:Label>

                                <div class="shoes_icon">
                                    <asp:Image ID="MDailyShoe" CssClass="shoes_icon" runat="server" ImageUrl='<%#Eval("Image") %>' Width="200" Height="200" />
                                </div>
                                <div class="star_text">
                                    <div class="left_part">
                                        <asp:Label ID="MDailyRating" runat="server" Text='<%#"Rating: " + Eval("Rating") %>'></asp:Label>

                                    </div>
                                    <div class="right_part">
                                        <asp:Label ID="lblMDailyPrice" CssClass="shoes_price" runat="server" ForeColor="#ff5e5b" Text='<%#Eval("ShoePrice") %>'></asp:Label>
                                        <asp:Label ID="lblCategory" Text="Women_Daily" runat="server" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlMDaily" runat="server">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:DropDownList ID="ShoeSizes" runat="server">
                                            <asp:ListItem Text="US8" Value="US8"></asp:ListItem>
                                            <asp:ListItem Text="US8.5" Value="US8.5"></asp:ListItem>
                                            <asp:ListItem Text="US9" Value="US9"></asp:ListItem>
                                            <asp:ListItem Text="US9.5" Value="US9.5"></asp:ListItem>
                                            <asp:ListItem Text="US10" Value="US10"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <asp:Button
                                        ID="btnMDaily" runat="server" Text="Add to Cart" OnClick="addCart" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>



            <br />
            <br />
            <h2>Women Long</h2>
            <div class="row">
                <asp:Repeater ID="WomenLong" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="best_shoes">
                                <asp:Label ID="lblMenDaily" CssClass="best_shoes" runat="server" Text='<%#Eval("ShoeName") %>'></asp:Label>
                                <div class="shoes_icon">
                                    <asp:Image ID="MDailyShoe" CssClass="shoes_icon" runat="server" ImageUrl='<%#Eval("Image") %>' Width="200" Height="200" />
                                </div>
                                <div class="star_text">
                                    <div class="left_part">
                                        <asp:Label ID="MDailyRating" runat="server" Text='<%#"Rating: " + Eval("Rating") %>'></asp:Label>

                                    </div>
                                    <div class="right_part">
                                        <asp:Label ID="lblMDailyPrice" CssClass="shoes_price" runat="server" ForeColor="#ff5e5b" Text='<%#Eval("ShoePrice") %>'></asp:Label>
                                        <asp:Label ID="lblCategory" Text="Women_Long" runat="server" Visible="false"></asp:Label>

                                        <asp:DropDownList ID="ddlMDaily" runat="server">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:DropDownList ID="ShoeSizes" runat="server">
                                            <asp:ListItem Text="US8" Value="US8"></asp:ListItem>
                                            <asp:ListItem Text="US8.5" Value="US8.5"></asp:ListItem>
                                            <asp:ListItem Text="US9" Value="US9"></asp:ListItem>
                                            <asp:ListItem Text="US9.5" Value="US9.5"></asp:ListItem>
                                            <asp:ListItem Text="US10" Value="US10"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <asp:Button
                                        ID="btnMDaily" runat="server" Text="Add to Cart" OnClick="addCart" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <br />
            <br />

            <h2>Women Racing</h2>
            <div class="row">
                <asp:Repeater ID="WomenRacing" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="best_shoes">
                                <asp:Label ID="lblMenDaily" CssClass="best_shoes" runat="server" Text='<%#Eval("ShoeName") %>'></asp:Label>
                                <div class="shoes_icon">
                                    <asp:Image ID="MDailyShoe" CssClass="shoes_icon" runat="server" ImageUrl='<%#Eval("Image") %>' Width="200" Height="200" />
                                </div>
                                <div class="star_text">
                                    <div class="left_part">
                                        <asp:Label ID="MDailyRating" runat="server" Text='<%#"Rating: " + Eval("Rating") %>'></asp:Label>

                                    </div>
                                    <div class="right_part">
                                        <asp:Label ID="lblMDailyPrice" CssClass="shoes_price" runat="server" ForeColor="#ff5e5b" Text='<%#Eval("ShoePrice") %>'></asp:Label>
                                        <asp:Label ID="lblCategory" Text="Women_Racing" runat="server" Visible="false"></asp:Label>

                                        <asp:DropDownList ID="ddlMDaily" runat="server">
                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:DropDownList ID="ShoeSizes" runat="server">
                                            <asp:ListItem Text="US8" Value="US8"></asp:ListItem>
                                            <asp:ListItem Text="US8.5" Value="US8.5"></asp:ListItem>
                                            <asp:ListItem Text="US9" Value="US9"></asp:ListItem>
                                            <asp:ListItem Text="US9.5" Value="US9.5"></asp:ListItem>
                                            <asp:ListItem Text="US10" Value="US10"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <asp:Button
                                        ID="btnMDaily" runat="server" Text="Add to Cart" OnClick="addCart" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
        <%-- Next Container Below --%>

        <%--        <div class="buy_now_bt">
            <button class="buy_text">Buy Now</button>
        </div>--%>
    </div>
</asp:Content>

