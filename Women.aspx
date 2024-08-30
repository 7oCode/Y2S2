<%@ Page Title="" Language="C#" MasterPageFile="~/EComms.Master" AutoEventWireup="true" CodeBehind="Women.aspx.cs" Inherits="WebAppProject.Women" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layout_padding gallery_section">
        <div class="container">
            <h2>Women Daily</h2>
            <div class="row">
                <asp:Repeater ID="WomenDaily" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="best_shoes">
                                <asp:Label ID="lblWDaily" CssClass="best_shoes" runat="server" Text='<%#Eval("ShoeName") %>'></asp:Label>
                                <div class="shoes_icon">
                                    <asp:Image ID="WDailyShoe" CssClass="shoes_icon" runat="server" ImageUrl='<%#Eval("Image") %>' Width="200" Height="200" />
                                </div>
                                <div class="star_text">
                                    <div class="left_part">
                                        <asp:Label ID="WDailyRating" runat="server" Text='<%#"Rating: " + Eval("Rating") %>'></asp:Label>

                                    </div>
                                    <div class="right_part">
                                        <asp:Label ID="lblWDailyPrice" CssClass="shoes_price" runat="server" ForeColor="#ff5e5b" Text='<%# "$" + Eval("ShoePrice") %>'></asp:Label>
                                    </div>
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
                                <asp:Label ID="lblMDaily" CssClass="best_shoes" runat="server" Text='<%#Eval("ShoeName") %>'></asp:Label>
                                <div class="shoes_icon">
                                    <asp:Image ID="MDailyShoe" CssClass="shoes_icon" runat="server" ImageUrl='<%#Eval("Image") %>' Width="200" Height="200" />
                                </div>
                                <div class="star_text">
                                    <div class="left_part">
                                        <asp:Label ID="MDailyRating" runat="server" Text='<%#"Rating: " + Eval("Rating") %>'></asp:Label>

                                    </div>
                                    <div class="right_part">
                                        <asp:Label ID="lblMDailyPrice" CssClass="shoes_price" runat="server" ForeColor="#ff5e5b" Text='<%# "$" + Eval("ShoePrice") %>'></asp:Label>
                                    </div>
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
                                <asp:Label ID="lblMDaily" CssClass="best_shoes" runat="server" Text='<%#Eval("ShoeName") %>'></asp:Label>
                                <div class="shoes_icon">
                                    <asp:Image ID="MDailyShoe" CssClass="shoes_icon" runat="server" ImageUrl='<%#Eval("Image") %>' Width="200" Height="200" />
                                </div>
                                <div class="star_text">
                                    <div class="left_part">
                                        <asp:Label ID="MDailyRating" runat="server" Text='<%#"Rating: " + Eval("Rating") %>'></asp:Label>

                                    </div>
                                    <div class="right_part">
                                        <asp:Label ID="lblMDailyPrice" CssClass="shoes_price" runat="server" ForeColor="#ff5e5b" Text='<%# "$" + Eval("ShoePrice") %>'></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="buy_now_bt">
            <button class="buy_text">Buy Now</button>
        </div>
    </div>
    </div>
</asp:Content>
