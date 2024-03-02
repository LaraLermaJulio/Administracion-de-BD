using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWebASP
{
    public partial class _Default : Page
    {
        LibroDAO libroDAO = new LibroDAO();
        List<Libro> libros = new List<Libro>();

        protected void Page_Load(object sender, EventArgs e)
        {
            actualizarTabla();
        }

        private void actualizarTabla()
        {
            libros = libroDAO.getAll();
            foreach (Libro libro in libros)
            {
                TableRow row = new TableRow();

                row.Cells.Add(new TableCell { Text = libro.ID.ToString() });
                row.Cells.Add(new TableCell { Text = libro.ISBN });
                row.Cells.Add(new TableCell { Text = libro.Titulo });
                row.Cells.Add(new TableCell { Text = libro.Numero_Edicion.ToString() });
                row.Cells.Add(new TableCell { Text = libro.Anio_Publicacion.ToString() });
                row.Cells.Add(new TableCell { Text = libro.Autores });
                row.Cells.Add(new TableCell { Text = libro.Pais_Publicacion });
                row.Cells.Add(new TableCell { Text = libro.Sinopsis });
                row.Cells.Add(new TableCell { Text = libro.Carrera });
                row.Cells.Add(new TableCell { Text = libro.Materia });

                tablaLibros.Rows.Add(row);
            }
        }


        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}