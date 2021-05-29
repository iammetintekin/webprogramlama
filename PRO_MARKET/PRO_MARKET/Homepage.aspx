<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="PRO_MARKET.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Homepage</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h4>Anasayfa</h4>
        <div class="row">
            <div class="col-xl-12 d-flex">
                <div class="w-100">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title mb-4">Ödemeler</h5>
                                    <h1 class="mt-1 mb-3">
                                        <strong><asp:Label ID="SalesLabel" Text="" runat="server" /> adet</strong></h1>
                                    <div class="mb-1">
                                        <span class="text-danger"><i class="mdi mdi-arrow-bottom-right"></i>-3.65% </span>
                                        <span class="text-muted">Since last week</span>
                                    </div>
                                </div>
                            </div>
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title mb-4">Müşteriler</h5>
                                    <h1 class="mt-1 mb-3">
                                        <strong> <asp:Label Text="" ID="CustomersCount" runat="server" /> adet</strong></h1>
                                    <div class="mb-1">
                                        <span class="text-success"><i class="mdi mdi-arrow-bottom-right"></i>5.25% </span>
                                        <span class="text-muted">Since last week</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title mb-4">Kazançlar</h5>
                                    <h1 class="mt-1 mb-3">
                                        <strong><asp:Label Text="" ID="AllEarnings" runat="server" />
                                        ₺</strong>
                                    </h1>
                                    <div class="mb-1">
                                        <span class="text-success"><i class="mdi mdi-arrow-bottom-right"></i>6.65% </span>
                                        <span class="text-muted">Since last week</span>
                                    </div>
                                </div>
                            </div>
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title mb-4">Siparişler</h5>
                                    <h1 class="mt-1 mb-3">
                                        <strong><asp:Label Text="" ID="OrdersCount" runat="server" /> adet</strong></h1>
                                    <div class="mb-1">
                                        <span class="text-danger"><i class="mdi mdi-arrow-bottom-right"></i>-2.25% </span>
                                        <span class="text-muted">Since last week</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-12">
                <div class="card flex-fill w-100">
                    <div class="card-header">

                        <h5 class="card-title mb-0">Aylık Satışlardan Elde Edilen Gelir (TL)</h5>
                    </div>
                    <div class="card-body py-3">
                        <div id="chardiv" class="chart chart-sm">
                            <div class="chartjs-size-monitor">
                                <div class="chartjs-size-monitor-expand"><div class=""></div></div><div class="chartjs-size-monitor-shrink"><div class=""></div></div></div>
										<canvas id="chartjs-dashboard-line" style="display: block; width: 399px; height: 250px;" width="399" height="250" class="chartjs-render-monitor"></canvas>
									</div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
