<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="PRO_MARKET.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Customers
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="input-group mb-2 mr-sm-2">
        <div class="input-group-text">
            <span class="fa fa-search"></span>
        </div>
        <asp:TextBox class="form-control" AutoPostBack="true" ID="SearchText" OnTextChanged="SearchChanged" placeholder="username" runat="server" />

    </div>
    <div class="container">
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>ID
                    </th>
                    <th>USERNAME
                    </th>
                    <th>NAME
                    </th>
                    <th>E-MAIL
                    </th>
                    <th>GENDER
                    </th>
                    <th>DETAILS
                    </th>
                </tr>
            </thead>
            <asp:Repeater ID="CustomerRepeater" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#  Eval("ID") %>
                        </td>
                        <td>
                            <%#  Eval("USERNAME_") %>
                        </td>
                        <td>
                            <%#  Eval("NAMESURNAME") %>
                        </td>
                        <td>
                            <%#  Eval("EMAIL") %>
                        </td>
                        <td>
                            <%#  Eval("GENDER") %>
                        </td>
                        <td>
                            <asp:Button Text="Details" CssClass="btn btn-info" runat="server" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

            <tr>
                <td>
                    <asp:Label Text="" ID="customersCount" runat="server" />
                </td>
            </tr>
        </table>
        <div class="dataTables_paginate paging_simple_numbers" id="datatables-reponsive_paginate">
            <ul class="pagination">
                <li class="paginate_button page-item next" id="datatables-reponsive_previous"><a href="#" aria-controls="datatables-reponsive" data-dt-idx="7" tabindex="0" class="page-link">Başa Dön</a></li>
                <asp:Repeater ID="pagesrepeater" ItemType="System.String" runat="server">
                    <ItemTemplate>
                        <li class="paginate_button page-item">
                            <asp:LinkButton OnClick="sendCurrentPage" Text='<%# Item %>' class="page-link" ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                            
                        </li>
                    </ItemTemplate>
                </asp:Repeater>


                <li class="paginate_button page-item next" id="datatables-reponsive_next"><a href="#" aria-controls="datatables-reponsive" data-dt-idx="7" tabindex="0" class="page-link">Son</a></li>
            </ul>
        </div>
    </div>

</asp:Content>
