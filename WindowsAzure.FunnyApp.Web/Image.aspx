<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Image.aspx.cs" Inherits="WindowsAzure.FunnyApp.Web.Image" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="container">
        <fieldset>
            <legend><asp:Label ID="LabelTitle" runat="server" Text=""></asp:Label></legend>
            <div class="controls">
                <div class="controls-row">
                    <asp:Image ID="ImageYou" runat="server" />
                </div>
                <div class="controls-row">
                    <asp:Label ID="LabelDescription" runat="server" Text=""></asp:Label>
                </div>
                <div class="controls-row">
                    <asp:Literal ID="LiteralTag" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="controls-row">
                <asp:Repeater ID="RepeaterComments" runat="server">
                    <ItemTemplate>
                        <div class="controls">
                            <label><i> <%# Eval("UserName") %></i></label>
                            <p><%# Eval("Content") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="controls">
                <div class="controls-row">
                    <label>Name:</label>
                    <asp:TextBox ID="TextBoxUserName" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ImageGrup" ControlToValidate="TextBoxUserName" CssClass="input-validation-error" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                </div>
                <div class="controls-row">
                    <label>Email:</label>
                    <asp:TextBox ID="TextBoxEmail" CssClass="input-xlarge" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ImageGrup" ControlToValidate="TextBoxEmail" CssClass="input-validation-error" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="ImageGrup" ControlToValidate="TextBoxEmail" runat="server" ErrorMessage="Input problem" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                <div class="controls-row">
                    <label>Comment</label>
                    <asp:TextBox ID="TextBoxCommet" TextMode="MultiLine" CssClass="input-large" runat="server" Height="132px" Width="407px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ImageGrup" ControlToValidate="TextBoxCommet" CssClass="input-validation-error" runat="server" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                </div>
                <div class="controls-row">
                    <asp:Button ID="ButtonCommentSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="ButtonCommentSubmit_Click" />
                </div>
                 <div class="controls-row">
                    <asp:Label ID="LabelResult" CssClass="badge badge-warning" runat="server" Text=""></asp:Label>
                </div>
            </div>
       
        </fieldset>
    </div>
    <asp:HiddenField ID="HiddenFieldPost" runat="server" />
</asp:Content>
