<%@ Page Title="" Language="C#" MasterPageFile="~/playtime.master" AutoEventWireup="true" CodeBehind="speldetails1.aspx.cs" Inherits="PresentationLayer.speldetails1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Speldetails</h1>
    <asp:Repeater ID="repeaterSpel" runat="server">
       <ItemTemplate>
            <p>Titel: <%# Eval("Titel") %></p>
           <p>Omschrijving: <%# Eval("Omschrijving") %></p>
           <p>Spelers: <%# Eval("AantalSpelersVanaf") %> tot <%# Eval("AantalSpelersTot") %></p>
           <p>spelduur: <%# Eval("Spelduur") %> minuten</p>
           <p>moeilijkheidsgraad: <%# Eval("MoeilijkheidsgraadSterren") %></p>
       </ItemTemplate>
    </asp:Repeater>
</asp:Content>
