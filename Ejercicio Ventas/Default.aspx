<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Anterior</asp:LinkButton>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Siguiente</asp:LinkButton>
        
    </div>
</asp:Content>
