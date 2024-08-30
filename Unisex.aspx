<%@ Page Title="" Language="C#" MasterPageFile="~/EComms.Master" AutoEventWireup="true" CodeBehind="Unisex.aspx.cs" Inherits="WebAppProject.Unisex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layout_padding gallery_section">
        <div class="container">
            <h2>Unisex</h2>
            <div class="row">
                <asp:Repeater ID="UnisexShoes" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="best_shoes">
                                <asp:Label ID="lblUnisex" CssClass="best_shoes" runat="server" Text='<%#Eval("ShoeName") %>'></asp:Label>
                                <div class="shoes_icon">
                                    <asp:Image ID="UnisexShoe" CssClass="shoes_icon" runat="server" ImageUrl='<%#Eval("Image") %>' Width="200" Height="200" />
                                </div>
                                <div class="star_text">
                                    <div class="left_part">
                                        <asp:Label ID="UnisexRating" runat="server" Text='<%#"Rating: " + Eval("Rating") %>'></asp:Label>

                                    </div>
                                    <div class="right_part">
                                        <asp:Label ID="lblUnisexPrice" CssClass="shoes_price" runat="server" ForeColor="#ff5e5b" Text='<%# "$" + Eval("ShoePrice") %>'></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <br />
            <br />

        </div>
        <%-- Next Container Below --%>

        <div class="buy_now_bt">
            <button class="buy_text">Buy Now</button>
        </div>
    </div>
</asp:Content>

