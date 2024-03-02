<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PaginaWebASP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Libreria</h1>
        </section>
        <p>&nbsp;</p>

        <asp:Button ID="btnInsertar" runat="server" Text="Insertar Libro" OnClick="btnInsertar_Click" CssClass="btn btn-primary" />
        <p>&nbsp;</p>
        <asp:Table ID="tablaLibros" runat="server" CssClass="table">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>ISBN</asp:TableHeaderCell>
                <asp:TableHeaderCell>Título</asp:TableHeaderCell>
                <asp:TableHeaderCell>Número de Edición</asp:TableHeaderCell>
                <asp:TableHeaderCell>Año de Publicación</asp:TableHeaderCell>
                <asp:TableHeaderCell>Autores</asp:TableHeaderCell>
                <asp:TableHeaderCell>País de Publicación</asp:TableHeaderCell>
                <asp:TableHeaderCell>Sinopsis</asp:TableHeaderCell>
                <asp:TableHeaderCell>Carrera</asp:TableHeaderCell>
                <asp:TableHeaderCell>Materia</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

        
    </main>

</asp:Content>
