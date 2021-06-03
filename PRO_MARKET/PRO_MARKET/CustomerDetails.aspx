<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CustomerDetails.aspx.cs" Inherits="PRO_MARKET.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h4>Müşteri Detay</h4>
        <div class="row">
            <div class="col-xl-12">
                <div class="card flex-fill w-100">

                    <div class="container">
                        <div class="main-body">

                            <!-- /Breadcrumb -->

                            <div class="row gutters-sm">
                                <div class="col-md-4 mb-3">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="d-flex flex-column align-items-center text-center">
                                                <img src="https://image.flaticon.com/icons/png/128/848/848006.png" alt="Admin" class="rounded-circle" width="150">
                                                <div class="mt-3">
                                                    <h4>
                                                        <asp:Label Text="Ad Soyad" ID="adsoyad" runat="server" /></h4>
                                                    <p class="text-secondary mb-1">
                                                        <asp:Label Text="Kullanıcı Adı" ID="kullaniciAdi" runat="server" />
                                                    </p>
                                                    <p class="text-muted font-size-sm">
                                                        Üyelik Tarihi : 
                                                        <asp:Label Text="Üyelik Tarihi" ID="UyelikTarihi" runat="server" />

                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <div class="card mb-3">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0">Ad Soyad</h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:Label Text="Ad Soyad" ID="AdSoyadLabel" runat="server" />
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0">Email</h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:Label Text="email@email.com" ID="EmailLabel" runat="server" />
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0">Phone</h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:Label Text="Telefon" ID="Tel1" runat="server" />
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0">Cinsiyet</h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:Label Text="Cinsiyet" ID="Cinsiyet" runat="server" />
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0">Doğum Tarihi</h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:Label Text="DogumTarihi" ID="Dogum" runat="server" />
                                                </div>
                                            </div>
                                            <hr>
                                            <div class="row">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0">Kayıtlı Adresler</h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:Repeater ID="Kayitliadresler" runat="server">
                                                        <ItemTemplate>
                                                            <label>
                                                                <%#  Eval("Adres") %>
                                                            </label>
                                                            <br />
                                                            <br />

                                                        </ItemTemplate>
                                                    </asp:Repeater>


                                                </div>
                                            </div>
                                        </div>
                                    </div>




                                </div>
                                <h6 class="mb-0">Geçmiş Siparişler
                                </h6>
                                <div class="card mt-3">

                                    <table class="table table-hover w-100">
                                        <tr>
                                            <th>Sipariş No
                                            </th>
                                            <th>Kullanıcı
                                            </th>
                                            <th>Sipariş Tarihi
                                            </th>
                                            <th>Sipariş Adresi
                                            </th>
                                            <th>Sipariş Şehir
                                            </th>
                                           
                                             <th>Toplam Ödeme
                                            </th>

                                            <th>Detay
                                            </th>
                                        </tr>
                                        <asp:Repeater ID="MusteriSiparisler" runat="server">
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
                                                        <%#  Eval("Address") %>
                                                    </td>
                                                    <td>
                                                        <%#  Eval("CityandDistrict") %>
                                                    </td>
                                                    <td>
                                                        <%#  Eval("OrderTotalPrice") %> <br />
                                                           <%#  Eval("SiparisSayisi") %>  adet ürün
                                                    </td>
                                                    <td>
                                                      <a class="btn btn-info" href="OrderDetails.aspx?OID=<%#  Eval("OrderID") %>">Details</a>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </table>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
