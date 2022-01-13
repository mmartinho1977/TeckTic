<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="Pantry.web.ProductPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg-form">
        <%--esta css resulta no retangulo blur onde está o formulário--%>
        <div class="row">
            <%--criar linha da tabela--%>

            <%--criar colunas--%>
            <div class="col-lg-1 col-md-1 col-sm-1"></div>
            <%--para a margem do lado esquedo--%>

            <%--Detalhe do Produto--%>
            <div class="col-lg-5 col-md-4 col-sm-4">
                <%-- Nesta div vamos implementar todas as textbox para mostrar o detalhe do produto. Zona do lado esquesdo do formulário--%>

                <%-- Titulo do formulário--%>
                <h1 style="font-size: 50px; text-align: left;">Produto</h1>

                <%--Campo de descriçºao do produto --%>
                <div class="form-group">
                    <div class="row" style="margin-top: 10%;">
                        <asp:Label ID="lblDesciption" CssClass="control-label col-sm-2" runat="server" Text="Descrição"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control left" Style="width: 100%; min-width: 100%;"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <%--Campo de categoria do produto --%>
                <div class="row" style="margin-top: 5%;">
                    <div class="form-group">
                        <asp:Label ID="lblCategoria" CssClass="control-label col-sm-2" runat="server" Text="Categoria"></asp:Label>
                    </div>
                    <div class="col-lg-8">
                        <asp:DropDownList ID="drdCategory" runat="server" CssClass="form-control left" AutoPostBack="true" Style="width: 100%; min-width: 100%;">
                            <asp:ListItem>Selecionar</asp:ListItem>
                            <asp:ListItem>Frescos</asp:ListItem>
                            <asp:ListItem>Mercearia</asp:ListItem>
                            <asp:ListItem>Higiene</asp:ListItem>
                            <asp:ListItem>Limpeza</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <%--Preço do produto--%>
                <div class="form-group">
                    <div class="row" style="margin-top: 10%;">
                        <asp:Label ID="lblPrice" CssClass="control-label col-sm-2" runat="server" Text="Preço"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control left" Style="width: 100%; min-width: 100%;"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegulaExpression1" ControlToValidate="txtPrice" runat="server" ErrorMessage="Só números reais"
                                ValidationExpression="^-?(?:\d+|\d{1,3}(?:,\d{3})+)(?:(\.|,)\d+)?$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <%--Quantidade atual do produto--%>
                <div class="form-group">
                    <div class="row" style="margin-top: 10%;">
                        <asp:Label ID="lblActualQuantity" CssClass="control-label col-sm-2" runat="server" Text="Quantidade atual"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtActualQuantity" runat="server" CssClass="form-control left" TextMode="Number" Style="width: 100%; min-width: 100%;"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <%--Quantidade minima do produto--%>
                <div class="form-group">
                    <div class="row" style="margin-top: 10%;">
                        <asp:Label ID="lblMinQuantity" CssClass="control-label col-sm-2" runat="server" Text="Quantidade mínima"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtMinQuantity" runat="server" CssClass="form-control left" TextMode="Number" Style="width: 100%; min-width: 100%;"></asp:TextBox>
                        </div>
                    </div>
                </div>

                 <%--Quantidade máxima do produto--%>
                <div class="form-group">
                    <div class="row" style="margin-top: 10%;">
                        <asp:Label ID="lblMaxQuantity" CssClass="control-label col-sm-2" runat="server" Text="Quantidade máxima"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtMaxQuantity" runat="server" CssClass="form-control left" TextMode="Number" Style="width: 100%; min-width: 100%;"></asp:TextBox>
                        </div>
                    </div>
                </div>

                
                 <%--Data do produto--%>
                <div class="form-group">
                    <div class="row" style="margin-top: 10%;">
                        <asp:Label ID="lblData" CssClass="control-label col-sm-2" runat="server" Text="Data de Compra"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtData" runat="server" CssClass="form-control left" Style="width: 100%; min-width: 100%; margin-right:0px;
                                padding-right:0px; float:left"></asp:TextBox>
                            <asp:Calendar ID="Calendar1" runat="server" Visible =" false" Style="float:right"></asp:Calendar>
                        </div>
                        <asp:ImageButton ID="btbCalendar" CssClass="left" runat="server" Height="100%" ImageUrl="Content/Images/calendar.png" Width="100%"
                            Style ="width:40px; margin-left: 0px; float:left"/>
                    </div>
                </div>


                <%--Area de botºes CRUD--%>
                <div class="row" style="margin-top:5%;">
                    <div class="col-lg-2"> </div>
                    <div class="col-lg-3">
                        <asp:Button ID="btbNew" CssClass="btn btn-primary right" runat="server" Text="Novo" CausesValidation="false" UseSubmitBehavior="false"
                            Width ="100%" Style="margin-top:5%;"/>
                    </div>
                    <div class="col-lg-3"> 
                        <asp:Button ID="btnSave" CssClass="btn btn-primary right" runat="server" Text="Salvar" 
                            Width ="100%" Style="margin-top:5%;"/>
                    </div>
                    <div class="col-lg-3"> 
                        <asp:Button ID="btnDelete" CssClass="btn btn-primary right" runat="server" Text="Apagar" 
                            Width ="100%" Style="margin-top:5%;"/>
                    </div>
                    <div class="col-lg-1"> </div>
                </div>


            </div>


            <%--Lista de produtos--%>
            <div class="col-lg-5 col-md-4 col-sm-4"><%--Coluna para colocar a lista dos produtos - lado direiro--%>
                <asp:ListBox Id="lbxProducts" CssClass="form-control left" runat="server" AutoPostBack="true" Font-Size="Large" Rows="25"
                    Style="margin-top:22%; margin-right:0%;margin-left:5%; width:100%; min-width:100%; height:100%; min-height:100%">
                </asp:ListBox>
            </div>

            <div class="col-lg-1 col-md-1 col-sm-1"></div>
            <%--para a margem do lado direiro--%>
        </div>
    </div>
</asp:Content>
