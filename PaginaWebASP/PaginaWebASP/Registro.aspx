<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PaginaWebASP.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Registrar Libro</h1>
        </section>
        <p>&nbsp;</p>

        <div class="container">
            <div class="card p-4">
                <div class="mb-3">
                    <asp:Label runat="server" Text="ISBN:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label runat="server" Text="Título:" CssClass="form-label" ></asp:Label>
                    <asp:TextBox ID="txtTitulo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label runat="server" Text="Número de Edición:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtNumeroEdicion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label runat="server" Text="Año de Publicación:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtAnioPublicacion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label runat="server" Text="Autores:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtAutores" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label runat="server" Text="País de Publicación:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPaisPublicacion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label runat="server" Text="Sinopsis:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtSinopsis" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label runat="server" Text="Carrera:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCarrera" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label runat="server" Text="Materia:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtMateria" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <div class="mb-3">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                    </div>
                    <div class="mb-3">
                        <asp:Button ID="btnCancelarOperacion" runat="server" Text="Cancelar" OnClick="btnCancelarOperacion_Click" CssClass="btn btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

