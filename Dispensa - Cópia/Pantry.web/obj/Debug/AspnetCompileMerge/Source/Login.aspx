<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pantry.web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card card-container">
        <img id="profile-img" class="profile-img-card" src="//ssl.gstatic.com/accounts/ui/avatar_2x.png" />
        <p id="profile-name" class="profile-name-card"></p>

        <span id="reauth-email" class="reauth-email"></span>
        <div class="row">
            <div class="col-lg-2 col-sm-1"></div>
            <div class="col-lg-8">
                <asp:TextBox runat="server" type="Text" ID="txtUsername" CssClass="form-control" placeholder="Username" required="true" autofocus="true" Style="margin-bottom: 10px;" />
                <asp:TextBox runat="server" type="password" ID="txtPassword" class="form-control" placeholder="Password" required="true" />
                <div id="remember" class="checkbox">
                    <label>
                        <asp:CheckBox ID="cbxRemember" runat="server" Text="Remember me" />
                    </label>
                </div>
                <asp:Button ID="SignInButton" runat="server" CssClass="btn btn-lg btn-primary btn-block btn-signin" type="submit" Text="Sign in" OnClick="SignInButton_Click"></asp:Button>
                <a href="#" class="forgot-password">Forgot the password?
                </a>
            </div>
            <div class="col-lg-2"></div>
        </div>
    </div>
</asp:Content>
