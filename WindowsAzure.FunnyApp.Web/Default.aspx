<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WindowsAzure.FunnyApp.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <section id="thumbnails">
            <div class="page-header">
                <h1>Thumbnails <small>Grids of images, videos, text, and more</small></h1>
            </div>
            <div class="row-fluid">
                <ul class="thumbnails">
                    <asp:Repeater ID="RepeaterImages" runat="server">
                        <ItemTemplate>
                            <li class="span3">
                                <a href='/Image.aspx?q=<%# Eval("Rowkey") %>' class="thumbnail">
                                    <img src="<%# Eval("PostImage") %>" alt="<%# Eval("PostTitle")  %>" />
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </section>
    </div>
</asp:Content>
