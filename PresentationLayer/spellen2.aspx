<%@ Page Title="" Language="C#" MasterPageFile="~/playtime.master" AutoEventWireup="true" CodeBehind="spellen2.aspx.cs" Inherits="PresentationLayer.spellen2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Alle spellen</h1>
        <section id="artikels">
            <asp:Repeater ID="repeaterSpellen" runat="server">
                <ItemTemplate>
                    <article class="spel">
                    <strong><%# Eval("Titel") %></strong><br />
                    van <%# Eval("AantalSpelersVanaf") %> tot <%# Eval("AantalSpelersTot") %> spelers<br />
                    spelduur: <%# Eval("Spelduur") %> minuten<br />
                    moeilijkheidsgraad: <%# Eval("MoeilijkheidsgraadSterren") %><br />
                    <p><a href="speldetails2.aspx?id=<%# Eval("SpelID") %>">details ...</a></p>
                    </article>
                </ItemTemplate>
            </asp:Repeater>
        </section>
</asp:Content>
