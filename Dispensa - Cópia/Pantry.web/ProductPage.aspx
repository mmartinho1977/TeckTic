<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="Pantry.web.ProductPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div class="bg-form">

                <div class="row">
                    <div class="col-lg-1 col-md-1 col-sm-1"></div>

                    <%--Detalhe do produto--%>
                    <div class="col-lg-5 col-md-5 col-sm-4">

                        <%--Titulo do formulário--%>
                        <h1 style="font-size: 50px; text-align: left">Produtos</h1>

                        <%--descricao do produto--%>
                        <div class="form-group">
                            <div class="row" style="margin-top: 10%">
                                <asp:Label ID="lblDescription" CssClass="control-label col-sm-2" runat="server"
                                    Text="Descrição" autofocus="true"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control left" required="true"
                                        Style="width: 100%; min-width: 100%" />
                                </div>
                            </div>
                        </div>

                        <%--Categoria do produto--%>
                        <div class="row" style="margin-top: 5%">
                            <div class="form-group">
                                <asp:Label ID="lblCategoria" CssClass="control-label col-lg-2" runat="server"
                                    Text="Categoria"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:DropDownList CssClass="form-control left"
                                        ID="drdCategoria"
                                        runat="server"
                                        AutoPostBack="true" Style="width: 100%; min-width: 100%">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <%--Data de compra do produto--%>
                        <div class="row" style="margin-top: 5%">
                            <div class="form-group">
                                <asp:Label ID="Label1" CssClass="control-label col-lg-2" runat="server"
                                    Text="Data de compra"></asp:Label>
                                <div class="col-lg-7" style="padding-right: 0px;">
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="form-control left" required="true" ReadOnly="true"
                                        Style="width: 100%; min-width: 100%; margin-right: 0px; padding-right: 0px; float: left"></asp:TextBox>
                                    <asp:Calendar ID="Calendar1" runat="server" Visible="False" OnSelectionChanged="Calendar1_SelectionChanged"
                                        Style="float: right"></asp:Calendar>
                                </div>
                                <div class="col-lg-1" style="padding: 0px;">
                                    <asp:ImageButton ID="btnCalendar" CssClass="left" runat="server" Height="100%" CausesValidation="false" UseSubmitBehavior="false"
                                        OnClick="btnCalendar_Click"
                                        ImageUrl="~/Content/Images/calendar.png" Width="100%"
                                        Style="width: 38px; margin-left: 0px; float: left" />

                                </div>
                            </div>
                        </div>




                        <%--Preco do produto--%>
                        <div class="row" style="margin-top: 5%">
                            <div class="form-group">
                                <asp:Label ID="lblPrice" CssClass="control-label col-lg-2" runat="server"
                                    Text="Preço"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control left" required="true"
                                        Style="width: 100%; min-width: 100%" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                        ControlToValidate="txtPrice" runat="server"
                                        ErrorMessage="Only Numbers allowed"
                                        ValidationExpression="^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:(\.|,)\d+)?$">
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                        <%--Quantidade atual do produto--%>
                        <div class="row" style="margin-top: 2%">
                            <div class="form-group">
                                <asp:Label ID="lblQuantidadeAtual" CssClass="control-label col-lg-2" runat="server" required="true"
                                    Text="Quantidade Atual"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtQuantidadeAtual" runat="server"
                                        CssClass="form-control left" TextMode="Number"
                                        Style="width: 100%; min-width: 100%" />
                                </div>
                            </div>
                        </div>

                        <%--Quantidade minima do produto--%>
                        <div class="row" style="margin-top: 5%">
                            <div class="form-group">
                                <asp:Label ID="lblQuantidadeMinima" CssClass="control-label col-lg-2"
                                    runat="server" Text="Quantidade Minima"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtQuantidadeMinima" runat="server" required="true"
                                        CssClass="form-control left" TextMode="Number"
                                        Style="width: 100%; min-width: 100%" />

                                </div>

                            </div>
                        </div>

                        <%--Quantidade maxima do produto--%>
                        <div class="row" style="margin-top: 5%">
                            <div class="form-group">
                                <asp:Label ID="lblQuantidadeMaxima" CssClass="control-label col-lg-2" runat="server"
                                    Text="Quantidade Máxima"></asp:Label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtQuantidadeMaxima" runat="server" required="true"
                                        CssClass="form-control left" TextMode="Number"
                                        Style="width: 100%; min-width: 100%;" />
                                </div>
                            </div>
                        </div>

                        <%-- Imagem do produto--%>
                        <%--<div class="row" style="margin-top: 5%">
                            <div class="form-group">
                                <asp:Label ID="Label2" CssClass="control-label col-lg-2" runat="server"
                                    Text="Imagem"></asp:Label>
                                <div class="col-lg-8">
                                    <form class="form-inline center-block" action="/" method="POST" enctype="multipart/form-data">
                                        <div class="input-group">
                                            <label id="browsebutton" class="btn btn-default input-group-addon" for="my-file-selector" style="background-color: white">
                                                <input id="my-file-selector" type="file" style="display: none;">
                                                Browse...
                                            </label>
                                           
                                            <input type="text" class="form-control" readonly="">
    </div>
    <button type="submit" class="btn btn-primary">Convert</button>
                                        
                                    </form>
                                </div>
                            </div>
                        </div>--%>



                        <%--Area de botoes CRUD--%>
                        <div class="row" style="margin-top: 5%;">
                            <div class="col-lg-2"></div>
                            <div class="col-lg-3">
                                <asp:Button ID="btnNew" CssClass="btn btn-primary right" runat="server" AutoPostBack="true"
                                    Text="Novo" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnNew_Click"
                                    Width="100%" Style="margin-top: 5%;" />
                            </div>
                            <div class="col-lg-3">
                                <asp:Button ID="btnSave" CssClass="btn btn-primary right" runat="server" OnClick="btnSave_Click"
                                    Text="Guardar" Width="100%" Style="margin-top: 5%;" />
                            </div>
                            <div class="col-lg-3">
                                <asp:Button ID="btnDelete" CssClass="btn btn-primary right" runat="server" OnClick="btnDelete_Click"
                                    Text="Eliminar" CausesValidation="false" Width="100%"
                                    Style="margin-top: 5%;" />
                            </div>
                            <div class="col-lg-1"></div>
                        </div>
                    </div>

                    <%--Lista de produtos--%>
                    <h1 style="font-size: 50px; text-align: left; color: transparent">Dumy</h1>
                    <div class="col-lg-5 col-md-5 col-sm-4">
                        <asp:ListBox ID="lbxProducts" CssClass="form-control left" runat="server" OnSelectedIndexChanged="lbxProducts_SelectedIndexChanged"
                            Style="margin-top: 10%; width: 100%; min-width: 100%; max-width: 100%; height: 100%; min-height: 100%"
                            AutoPostBack="true" Font-Size="Large" Rows="15"></asp:ListBox>
                    </div>

                    <div class="col-lg-1 col-md-1 col-sm-1"></div>

                </div>

            </div>
        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>
