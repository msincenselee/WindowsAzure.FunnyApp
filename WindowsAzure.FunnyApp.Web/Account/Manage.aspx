<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="WindowsAzure.FunnyApp.Web.Account.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <hgroup class="title">
                 <h1><%: Title %></h1>
             </hgroup>

    <section id="passwordForm">
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="message-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>

        <p>You're logged in as <strong><%: User.Identity.Name %></strong>.</p>

        <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
            <p>
                You do not have a local password for this site. Add a local
                password so you can log in without an external login.
            </p>

        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="changePassword" Visible="false">
            <h3>Change password</h3>
            <asp:ChangePassword ID="ChangePassword1" runat="server" CancelDestinationPageUrl="~/" ViewStateMode="Disabled" RenderOuterTable="false" SuccessPageUrl="Manage.aspx?m=ChangePwdSuccess">
                <ChangePasswordTemplate>
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="FailureText" />
                    </p>
                    <fieldset>
                        <legend>Change password details</legend>
                        <div class="controls-row">
                            <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword">Current password</asp:Label>
                            <asp:TextBox runat="server" ID="CurrentPassword" CssClass="input-large" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CurrentPassword"
                                                        CssClass="input-validation-error" ErrorMessage="The current password field is required."
                                                        ValidationGroup="ChangePassword" />
                        </div>
                        <div class="controls-row">
                            <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword">New password</asp:Label>
                            <asp:TextBox runat="server" ID="NewPassword" CssClass="input-large" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="NewPassword"
                                                        CssClass="input-validation-error" ErrorMessage="The new password is required."
                                                        ValidationGroup="ChangePassword" />
                        </div>
                        <div class="controls-row">
                            <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword">Confirm new password</asp:Label>
                            <asp:TextBox runat="server" ID="ConfirmNewPassword" CssClass="input-large" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ConfirmNewPassword"
                                                        CssClass="input-validation-error" Display="Dynamic" ErrorMessage="Confirm new password is required."
                                                        ValidationGroup="ChangePassword" />
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                                  CssClass="input-validation-error" Display="Dynamic" ErrorMessage="The new password and confirmation password do not match."
                                                  ValidationGroup="ChangePassword" />
                        </div>
                        <div class="controls-row">
                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" CommandName="ChangePassword" Text="Change password" ValidationGroup="ChangePassword" />
                        </div>
                    </fieldset>
                </ChangePasswordTemplate>
            </asp:ChangePassword>
        </asp:PlaceHolder>
    </section>
    </div>
</asp:Content>
