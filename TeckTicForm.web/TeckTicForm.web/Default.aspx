<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeckTicForm.web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h3>Formulário de receção de equipamentos</h3>
        <hr />
    </div>
    <div class="jumbotron">
        <h6>NIF</h6>
        <asp:TextBox runat="server" ID="TextBoxNif" CssClass="form-control" required="true" autofocus="true" Style="margin-bottom: 10px;" />
        <h6>Nome</h6>
        <asp:TextBox runat="server" ID="TextBoxName" class="form-control" required="true" Style="margin-bottom: 10px; min-width: 100%;" />
        <h6>Morada</h6>
        <asp:TextBox runat="server" ID="TextBoxAddress" class="form-control" required="true" Style="margin-bottom: 10px; width: 5000px; min-width: 100%;" />

        <div class="row">
            <div class="col-lg-2">
                <h6>Codigo Postal</h6>
                <asp:TextBox runat="server" ID="TextBoxPostalCode" CssClass="form-control" required="true"  Style="margin-bottom: 10px;" />
            </div>
            <div class="col-lg-8">
                <h6>Localidade</h6>
                <asp:TextBox runat="server" ID="TextBoxCity" CssClass="form-control" required="true" Style="margin-bottom: 10px;" />
            </div>
            <div class="col-lg-2">
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2">
                <h6>Telefone</h6>
                <asp:TextBox runat="server" ID="TextBoxPhone" CssClass="form-control" placeholder="Opcional" Style="margin-bottom: 10px;" Font-Overline="False" />
            </div>
            <div class="col-lg-8">
                <h6>Telemóvel</h6>
                <asp:TextBox runat="server" ID="TextBoxMobile" CssClass="form-control" required="true"  Style="margin-bottom: 10px;" />
            </div>
        </div>
        <h6>Email</h6>
        <asp:TextBox runat="server" ID="TextBoxEmail" TextMode="Email"  class="form-control" required="true" Style="margin-bottom: 20px; width: 5000px; min-width: 100%;" />

        <h4>Dados do equipamento</h4>
        <div class="jumbotron" style="background-color: rgb(194, 214, 214);">
            <h6>Tipo de equipamento</h6>
            <asp:TextBox runat="server" ID="TextBoxType" CssClass="form-control" placeholder="Ex. Computador portátil" required="true" Style="margin-bottom: 10px;" />
            <div class="row">
                <div class="col-lg-4">
                    <h6>Marca</h6>
                    <asp:TextBox runat="server" ID="TextBoxBrand" CssClass="form-control" required="true" Style="margin-bottom: 10px;" />
                </div>
                <div class="col-lg-4">
                    <h6>Modelo</h6>
                    <asp:TextBox runat="server" ID="TextBoxModel" CssClass="form-control" required="true" Style="margin-bottom: 10px;" />
                </div>
                <div class="col-lg-4">
                    <h6>Número de série</h6>
                    <asp:TextBox runat="server" ID="TextBoxSerial" CssClass="form-control" placeholder="Opcional"  Style="margin-bottom: 10px;" />
                </div>
            </div>
            <h6>Acessórios</h6>
            <asp:TextBox runat="server" ID="TextBoxItems" class="form-control" placeholder="Opcional - Ex. Transformador"  Style="margin-bottom: 10px; width: 5000px; min-width: 100%;" />
            <div class="row">
                <div class="col-lg-6">
                    <h6>Descrição do problema</h6>
                    <asp:TextBox runat="server" ID="TextBoxProblem" CssClass="form-control" TextMode="MultiLine" Rows="10" required="true"  Style="margin-bottom: 10px; min-width: 100%;" />
                </div>
                <div class="col-lg-6">
                    <h6>Como reproduzir</h6>
                    <asp:TextBox runat="server" ID="TextBoxReproduce" CssClass="form-control" TextMode="MultiLine" Rows="10" placeholder="Opcional"  Style="margin-bottom: 10px; min-width: 100%;" />
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-lg-6">
            </div>
            <div class="col-lg-6">

                <asp:Button ID="ButtonSubmit" runat="server" CssClass="btn btn-lg btn-primary btn-block btn-signin" type="submit" Text="Submeter" OnClick="ButtonSubmit_Click" Style="float: right; margin-bottom: 10px; margin-right: 0,5%"></asp:Button>
            </div>
        </div>

    </div>



</asp:Content>
