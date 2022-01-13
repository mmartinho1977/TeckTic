<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Pantry.web.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    <div class="bg-text">
        <h1 style="font-size: 50px;">Welcome to MyPantry</h1>
        <a  href="MenuPage" style="font-size: 30px; color: white;">start</a>
        <p>Create your shop list</p>
    </div>
    <%--<p style="margin-left:20%; margin-top:40%; font-size:80px; font-weight:bold; color:#cc0000;">Welcome to MyPantry</p>
        <asp:LinkButton ID="btnBegin" runat="server" OnClick="btnBegin_Click" style="margin-left:20%; margin-top:10%; font-size:50px; font-weight:bold">begin</asp:LinkButton>--%>
</asp:Content>
