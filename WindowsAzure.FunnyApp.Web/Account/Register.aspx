<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WindowsAzure.FunnyApp.Web.Account.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <hgroup class="title">
                 <h1><%: Title %></h1>
                 <h2>Use the form below to create a new account.</h2>
             </hgroup>

    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        Passwords are required to be a minimum of <%: Membership.MinRequiredPasswordLength %> characters in length.
                    </p>

                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>

                    <fieldset>
                        <legend>Registration Form</legend>
                        <div class="controls-row">
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName">User name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName"  CssClass="input-large" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                                                            CssClass="input-validation-error" ErrorMessage="The user name field is required." />
                            </div>
                        <div class="controls-row">
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="Email">Email address</asp:Label>
                                <asp:TextBox runat="server" ID="Email" TextMode="Email" CssClass="input-large" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Email"
                                                            CssClass="input-validation-error" ErrorMessage="The email address field is required." />
                            </div>
                            <div class="controls-row">
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="input-large" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password"
                                                            CssClass="input-validation-error" ErrorMessage="The password field is required." />
                            </div>
                            <div class="controls-row">
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="ConfirmPassword">Confirm password</asp:Label>
                                <asp:TextBox runat="server" ID="ConfirmPassword" CssClass="input-large" TextMode="Password" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ConfirmPassword"
                                                            CssClass="input-validation-error" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                                      CssClass="input-validation-error" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                            </div>
                        <div class="controls-row">
                              <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" CommandName="MoveNext" Text="Register" />
                        </div>
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    </div>
</asp:Content>
