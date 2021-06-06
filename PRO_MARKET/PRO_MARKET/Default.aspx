<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PRO_MARKET.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sipariş Takip | Pro Market</title>
    <link href="css/app.css" rel="stylesheet">
    <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>--%>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: #ffffff!important">
            <main class="content">
                <div class="container-fluid p-0">

                    <h1 class="h3 mb-3">
                        <img src="img/logo2.png" style="height: 100px" alt="Alternate Text" />
                        Pro Market | Hoşgeldiniz</h1>

                    <div class="row">
                        <div class="col-12">
                            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                <ol class="carousel-indicators">
                                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
                                </ol>
                                <div class="carousel-inner">
                                    <div class="carousel-item active">
                                        <img class="d-block w-100" src="img/2.jpg" />
                                    </div>
                                    <div class="carousel-item">
                                        <img class="d-block w-100" src="img/1.jpg" />
                                    </div>
                                    <div class="carousel-item">
                                        <img class="d-block w-100" src="img/3.jpg" />
                                    </div>
                                    <div class="carousel-item">
                                        <img class="d-block w-100" src="img/4.jpg" />
                                    </div>
                                </div>
                                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="sr-only">Previous</span>
                                </a>
                                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="sr-only">Next</span>
                                </a>
                            </div>
                        </div>
                        <div class="col-12">
                            <div class="card">
                                <div class="card-body">
                                    <nav>
                                        <b>Sipariş Kontrol Sistemi</b>
                                        <br />
                                        <div class="d-none d-sm-inline-block">
                                            <div class="input-group input-group-lg">
                                                <div class="input-group-prepend">
                                                   <asp:LinkButton CssClass="btn btn-square" Text='<i class="fa fa-search"></i> ARA' ID="siparisKontrol" OnClick="siparisKontrol_Click" runat="server" />
                                                </div>
                                                   <input runat="server" style="width:500px" required id="fisno" type="text" class="form-control" placeholder="Lütfen Fiş Numarası Giriniz" aria-label="Search" />
                                               
                                            </div>
      
                                        </div>
                                    </nav>
                                </div>
                            </div>
                        </div>

                        <div id="siparisDetaydiv" runat="server" class="col-12">
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
                                            <a href="Default.aspx" class="btn btn-secondary"><i class="fa fa-newspaper"></i>Yeni Fiş Kontrol</a>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </main>
        </div>
    </form>


    <script src="js/app.js"></script>
</body>
</html>
