<%@ Page Title="" Language="C#" MasterPageFile="~/playtime.master" AutoEventWireup="true" CodeBehind="gastenboekNieuw.aspx.cs" Inherits="PresentationLayer.gastenboekNieuw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Laat een bericht achter op ons gastenboek</h1>
    <p>van:<br />
        <asp:TextBox ID="textBoxVan" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorVan" runat="server" ErrorMessage="*" ControlToValidate="textboxVan" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>bericht:<br />
        <asp:TextBox ID="textBoxBericht" runat="server" Height="60px" TextMode="MultiLine" Width="95%"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatorBericht" runat="server" ErrorMessage="*" ControlToValidate="textboxBericht" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="buttonOpslaan" runat="server" Text="Opslaan" OnClick="buttonOpslaan_Click" /></p>
</asp:Content>
