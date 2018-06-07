<%@ Page Title="" Language="C#" MasterPageFile="~/playtime.master" AutoEventWireup="true" CodeBehind="gastenboek.aspx.cs" Inherits="PresentationLayer.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Gastenboek</h1>
    <p>Voeg een <a href="gastenboekNieuw.aspx">nieuw</a> bericht toe </p>
    <asp:Repeater ID="repeaterGastenboek" runat="server">
        <ItemTemplate>
            <p>Van <%# Eval("GepostDoor") %><br />
                Op <%# Eval("GepostOp") %></p>
            <p>Bericht:<%# Eval("Bericht") %></p>
            <p>Habib</p>
            <hr />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
