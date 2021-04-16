<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="PRO_MARKET.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table">
        <asp:Repeater ID="CustomerRepeater" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#  Eval("USERNAME_") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>


    </table>
</asp:Content>
