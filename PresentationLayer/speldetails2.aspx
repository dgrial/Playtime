<%@ Page Title="" Language="C#" MasterPageFile="~/playtime.master" AutoEventWireup="true" CodeBehind="speldetails2.aspx.cs" Inherits="PresentationLayer.speldetails2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="repeaterSpel" runat="server">
       <ItemTemplate>
           <h1><%# Eval("Titel") %></h1>
           <img  src="images\<%# Eval("Afbeelding") %>" />
           <p>Omschrijving: <%# Eval("Omschrijving") %></p>
           <p>Spelers: <%# Eval("AantalSpelersVanaf") %> tot <%# Eval("AantalSpelersTot") %></p>
           <p>spelduur: <%# Eval("Spelduur") %> minuten</p>
           <p>moeilijkheidsgraad: <%# Eval("MoeilijkheidsgraadSterren") %></p>
       </ItemTemplate>
    </asp:Repeater>
</asp:Content>
