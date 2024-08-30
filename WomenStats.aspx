<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="WomenStats.aspx.cs" Inherits="WebAppProject.WomenStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="layout_padding collection_section">
    <div class="container">
        <h1 class="new_text"><strong>Men Shoes Stats</strong></h1>
        <p class="consectetur_text">consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation</p>
        <asp:Chart ID="Chart1" runat="server">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

        <asp:Chart ID="Chart2" runat="server">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

        <asp:Chart ID="Chart3" runat="server">
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>


        <asp:TextBox ID="uShoeName" Placeholder="Shoe Name" runat="server"></asp:TextBox>
        <br />

        <asp:TextBox ID="uShoePrice" Placeholder="Shoe Price" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="uShoeRating" Placeholder="Shoe Rating" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="uShoeImage" Placeholder="Shoe Image" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="uShoeId" Placeholder="Shoe ID (updating)" runat="server"></asp:TextBox>
        <br />


        <asp:DropDownList ID="TableName" runat="server">
            <asp:ListItem Text="Women_Daily" Value="Women_Daily" />
            <asp:ListItem Text="Women_Long" Value="Women_Long" />
            <asp:ListItem Text="Women_Racing" Value="Women_Racing" />
        </asp:DropDownList>

        <asp:DropDownList ID="ActionName" runat="server">
            <asp:ListItem Text="Update" Value="Update" />
            <asp:ListItem Text="Insert" Value="Insert" />

        </asp:DropDownList>
        <asp:Button ID="doAction" runat="server" Text="Execute" OnClick="Execute_OnClick" />

        <br />
        <br />
        <br />
        <br />
        <br />

        <div class="container">

            <h1>Men Shoes</h1>




            <div class="row">


                <div class="col-md-4">
                    <asp:Label ID="retResult" Text="Error in deleting" Visible="false" runat="server" />
                    <br />
                    <asp:GridView ID="Women_DailyShoe" runat="server" DataSourceID="SqlDataSource4" AutoGenerateColumns="False" OnRowDeleting="rowDelete4" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
                            <asp:BoundField DataField="ShoeName" HeaderText="ShoeName" SortExpression="ShoeName"></asp:BoundField>
                            <asp:BoundField DataField="ShoePrice" HeaderText="ShoePrice" SortExpression="ShoePrice"></asp:BoundField>
                            <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating"></asp:BoundField>
                            <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image"></asp:BoundField>
                            <asp:BoundField DataField="TimesBought" HeaderText="TimesBought" SortExpression="TimesBought"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:WebAppProject %>"
                        SelectCommand="SELECT [Id], [ShoeName], [ShoePrice], [Rating], [Image], [TimesBought] FROM [Women_Daily]">
                        <%--                            DeleteCommand="Delete from Men_Daily Where Id = @Id"
                        <DeleteParameters>
                            <asp:Parameter Name="Id" Type="Int32" />
                        </DeleteParameters>--%>

                    </asp:SqlDataSource>
                </div>


            </div>
            <br />
            <br />

            <div class="row">
                <div class="col-md-4">
                    <asp:GridView ID="Women_LongShoes" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource5" OnRowDeleting="rowDelete5" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
                            <asp:BoundField DataField="ShoeName" HeaderText="ShoeName" SortExpression="ShoeName"></asp:BoundField>
                            <asp:BoundField DataField="ShoePrice" HeaderText="ShoePrice" SortExpression="ShoePrice"></asp:BoundField>
                            <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating"></asp:BoundField>
                            <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image"></asp:BoundField>
                            <asp:BoundField DataField="TimesBought" HeaderText="TimesBought" SortExpression="TimesBought"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:WebAppProject %>" SelectCommand="SELECT [Id], [ShoeName], [ShoePrice], [Rating], [Image], [TimesBought] FROM [Women_Long]"></asp:SqlDataSource>

                </div>
            </div>
            <br />
            <br />


            <div class="row">
                <div class="col-md-4">
                    <asp:GridView ID="Women_RacingShoes" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource6" OnRowDeleting="rowDelete6" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
                            <asp:BoundField DataField="ShoeName" HeaderText="ShoeName" SortExpression="ShoeName"></asp:BoundField>
                            <asp:BoundField DataField="ShoePrice" HeaderText="ShoePrice" SortExpression="ShoePrice"></asp:BoundField>
                            <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image"></asp:BoundField>
                            <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating"></asp:BoundField>
                            <asp:BoundField DataField="TimesBought" HeaderText="TimesBought" SortExpression="TimesBought"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:WebAppProject %>" SelectCommand="SELECT [Id], [ShoeName], [ShoePrice], [Image], [Rating], [TimesBought] FROM [Women_Racing]"></asp:SqlDataSource>

                </div>


            </div>


        </div>
    </div>
    <hr />
</div>
</asp:Content>
