<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="PRO_MARKET.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>
            All Orders
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="input-group mb-2 mr-sm-2">
        <div class="input-group-text bg-info text-white">
            <span class="fa fa-search"></span>
        </div>
        <asp:TextBox class="form-control" AutoPostBack="true" ID="SearchText" OnTextChanged="SearchChanged" placeholder="Name or Username" runat="server" />
        <div class="input-group-text bg-danger">
            <a href="Customers.aspx" class="text-white"><span class='fa fa-times'></span></a>

        </div>

    </div>
    <div class="container">
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>ORDER ID
                    </th>
                    <th>USER 
                    </th>
                    <th>DATE
                    </th>
                    <th>TOTAL PRICE
                    </th>
                    <th>ADDRESS
                    </th>
                    <th>
                        CITY AND TOWN
                    </th>
                    <th>DETAILS
                    </th>
                </tr>
            </thead>
            <asp:Repeater ID="OrderRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#  Eval("OrderID") %>
                        </td>
                        <td>
                            <%#  Eval("Username") %>
                        </td>
                        <td>
                            <%#  Eval("OrderDate") %>
                        </td>
                        <td>
                            <%#  Eval("OrderTotalPrice") %>
                        </td>
                        <td>
                            <%#  Eval("Address") %>
                        </td>
                        <td>
                            <%#  Eval("CityandDistrict") %>
                        </td>
                        <td>
                            <asp:Button Text="Details" CssClass="btn btn-info" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

            <tr>
                <td>
                    <asp:Label Text="" ID="ordersCount" runat="server" />
                </td>
            </tr>
        </table>
        <div class="dataTables_paginate paging_simple_numbers" id="datatables-reponsive_paginate">
            <ul class="pagination">
                <li class="paginate_button page-item next" id="datatables-reponsive_previous">
                        <asp:LinkButton OnClick="sendCurrentPage" Text='Başa Dön' CssClass='btn btn-dark' ID="LinkButton1" runat="server"></asp:LinkButton>

                </li>
                <asp:Repeater ID="pagesrepeater" ItemType="System.String" runat="server">
                    <ItemTemplate>
                        <li class="paginate_button page-item">
                            <asp:LinkButton OnClick="sendCurrentPage" Text='<%# Item %>' CssClass='<%# checkCurrentPage(Item) %>' ID="LinkButton1" runat="server"></asp:LinkButton>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>

                <li class="paginate_button page-item next" id="datatables-reponsive_next">
                    <asp:LinkButton OnClick="sendCurrentPage" Text='Son' CssClass='btn btn-dark' ID="LinkButton2" runat="server"></asp:LinkButton>

                </li>
            </ul>
        </div>
    </div>
</asp:Content>
