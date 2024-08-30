<%@ Page Title="" Language="C#" MasterPageFile="~/EComms.Master" AutoEventWireup="true" CodeBehind="Men.aspx.cs"  Inherits="WebAppProject.Men" EnableEventValidation="false"%>

<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Web" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="layout_padding gallery_section">
        <div class="container">
            <h2>Men Daily</h2>
            <div class="row">
                <asp:Repeater ID="MenDaily" runat="server">
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
                                        <br />
                                        <br />
<%--                                        <asp:Label ID="lmao" runat="server" Text="is simply dummy text of the printing and typesetting industry. 
                                            Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. 
                                            It has survived not only five centuries, but also the leap into electronic typesetting,"></asp:Label>--%>

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
            <h2>Men Long</h2>
            <div class="row">
                <asp:Repeater ID="MenLong" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="best_shoes">
                                <asp:Label ID="lblMenLong" CssClass="best_shoes" runat="server" Text='<%#Eval("ShoeName") %>'></asp:Label>
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

            <h2>Men Racing</h2>
            <div class="row">
                <asp:Repeater ID="MenRacing" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-4">
                            <div class="best_shoes">
                                <asp:Label ID="lblMenRacing" CssClass="best_shoes" runat="server" Text='<%#Eval("ShoeName") %>'></asp:Label>
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
        <%-- Next Container Below --%>

        <div class="buy_now_bt">
            <button class="buy_text">Buy Now</button>
        </div>
    </div>
</asp:Content>
