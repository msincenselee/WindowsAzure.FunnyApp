<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ImageUploadPage.aspx.cs" Inherits="WindowsAzure.FunnyApp.Web.Manager.ImageUploadPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <fieldset>
            <legend>Image Upload</legend>
            <div class="controls">
                <div class="controls-row">
                    <label>Title:</label>
                    <asp:TextBox ID="TextBoxTitle" CssClass="input-large" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                </div>
                <div class="controls-row">
                    <label>Tags:</label>
                    <asp:TextBox ID="TextBoxTag" CssClass="input-large" runat="server"></asp:TextBox>
                    <div class="help-inline"><span class="badge badge-important">Split ';'</span></div>
                </div>
                <div class="controls-row">
                    <label>Image Upload:</label>
                    <asp:FileUpload ID="FileUploadImage" CssClass="input-large" runat="server" />
                </div>
                <div class="controls-row">
                    <label>Description:</label>
                    <asp:TextBox ID="TextBoxDescription" TextMode="MultiLine" CssClass="input-large" runat="server" Height="194px" Width="268px"></asp:TextBox>
                </div>
                <div class="controls-row">
                    <asp:Button ID="ButtonSave" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="ButtonSave_Click" />
                    <asp:Button ID="ButtonCancel" runat="server" CssClass="btn" Text="Cancel" />
                </div>
        
            </div>
        </fieldset>
                <div class="controls-row">
                    <asp:Label ID="LabelResult" CssClass="badge badge-warning" runat="server" Text=""></asp:Label>
                </div>
    </div>
</asp:Content>
