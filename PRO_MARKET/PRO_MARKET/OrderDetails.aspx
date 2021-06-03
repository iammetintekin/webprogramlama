<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="PRO_MARKET.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <!-- Modal -->
        <div class="card">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Sipariş Detayı</h5>
                    </div>
                    <div class="modal-body">
                        <b>Sipariş Numarası</b>
                        <asp:Label Text="text" ID="OrderId" runat="server" />
                        <br />
                        <b>Sipariş Tarihi</b>
                        <asp:Label Text="text" ID="OrderDate" runat="server" />
                        <br />
                        <b>Toplam Tutar</b>
                        <asp:Label Text="text" ID="TotalPrice" runat="server" />
                        <br />
                        <b>Sipariş Adresi</b>
                        <asp:Label Text="text" ID="Adress" runat="server" />
                        <br />
                        <hr />
                        <h5 class="modal-title">Kullanıcı</h5>
                        <hr />
                        <b>Müşteri Adı</b>
                        <asp:Label Text="text" ID="KullaniciAdi" runat="server" />
                        <br />
                        <b>Müşteri Tel</b>
                        <asp:Label Text="text" ID="KullaniciTelefon" runat="server" />
                        <br />
                        <b>Müşteri E-Mail</b>
                        <asp:Label Text="text" ID="KullaniciMail" runat="server" />
                        <hr />
                        Sipariş İçerisindeki Ürünler
                    <table class="table table-hover">
                        <tr>
                            <th>Ürün Adı </th>
                            <th>Ürün Adeti </th>
                            <th>Toplam </th>
                        </tr>
                        <asp:Repeater ID="SiparistekiUrunler" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <label><%# Eval("UrunAdi") %></label>
                                    </td>
                                    <td>
                                        <label><%# Eval("UrunAdeti") %></label>
                                    </td>
                                    <td>
                                        <label><%# Eval("UrunToplam") %></label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                        <div class="alert alert-success w-100">
                            <b>Toplam Alınan Ödeme</b><br />
                            <div>
                                <asp:Label ID="AlinanOdeme" Text="" CssClass="m-3" runat="server" />
                                TL
                            </div>

                        </div>
                        <b>Fatura Detayı</b><br />
                        <div>

                            <table class="table table-hover">
                                <tr>
                                    <th>Fatura Adresi</th>
                                    <th>Kargo Fiş No</th>
                                    <th>Toplam Ödeme</th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label Text="text" ID="faturaAdresi" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Label Text="text" ID="KargoFisNo" runat="server" /></td>
                                    <td>
                                        <asp:Label Text="text" ID="ToplamOdeme" runat="server" /></td>
                                </tr>
                            </table>


                        </div>
                    </div>
                    <div class="modal-footer">
                        <a href="Orders.aspx" class="btn btn-secondary"><i class="fa fa-arrow-alt-circle-left"></i> Geri Dön</a>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
