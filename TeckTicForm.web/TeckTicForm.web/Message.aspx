<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="TeckTicForm.web.Message" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2>Obrigada!</h2>
        <asp:Label ID="LabelResult" runat="server" Text ="Dentro de alguns momentos vai receber um e-mail com o número do processo e a requisição em formato PDF."></asp:Label>
        <p />
         <asp:Label Id="LabelEmail" runat="server" Text ="Reencaminhe o documento anexo para apoio.cliente@techtic.pt"></asp:Label>
        <p />
        <a runat="server" href="~/">Novo Formulário</a>
        <p />
        <hr />
    </div>
</asp:Content>
