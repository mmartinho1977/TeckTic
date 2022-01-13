<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuPage.aspx.cs" Inherits="Pantry.web.MenuPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg-btn">

        <a href="ProductPage">
            <img src='<%=ResolveUrl("~/Content/Images/products.png")%>'  style="margin: 30px; width: 150px;">
        </a>

        <a href="ProductPage">
            <img src='<%=ResolveUrl("~//Content/Images/category.png")%>' style="margin: 30px; width: 150px;">
        </a>
        <a href="ProductPage">
            <img src='<%=ResolveUrl("~/Content/Images/users.png")%>'  style="margin: 30px; width: 150px;">
        </a>
    </div>

</asp:Content>
