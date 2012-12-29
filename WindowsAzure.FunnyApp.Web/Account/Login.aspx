<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WindowsAzure.FunnyApp.Web.Account.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <div class="container">
        <section id="loginForm">
            <div class="controls">
                <asp:Login ID="Login1" runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
                    <LayoutTemplate>
                        <p class="validation-summary-errors">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                        <fieldset>
                            <legend>Log in Form</legend>
                            <div class="controls-row">
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">User name</asp:Label>
                                <asp:TextBox runat="server" CssClass="input-xxlarge" ID="UserName" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                            </div>
                            <div class="controls-row">
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" CssClass="input-xxlarge" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                            </div>
                            <div class="controls-row">
                                <asp:CheckBox runat="server" ID="RememberMe" Text="Remember me?" />
                            </div>
                            <div class="controls-row">
                                <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" CommandName="Login" Text="Log in" />
                            </div>
                        </fieldset>
                    </LayoutTemplate>
                </asp:Login>
            </div>
            <div class="controls-row">
                    <div class="help-block">
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register</asp:HyperLink>
                    if you don't have an account.    
                    </div>
            </div>
        </section>
    </div>
</asp:Content>
