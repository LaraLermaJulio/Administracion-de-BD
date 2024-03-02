using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWebASP
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Llene correctamente los datos');", true);
                return;
            }
            try
            {
                Libro libro = new Libro(0, txtISBN.Text, txtTitulo.Text,
                    Convert.ToInt32(txtNumeroEdicion.Text), Convert.ToInt32(txtAnioPublicacion.Text),
                    txtAutores.Text, txtPaisPublicacion.Text, txtSinopsis.Text, txtCarrera.Text, txtMateria.Text);

                LibroDAO libroDAO = new LibroDAO();
                if (libroDAO.AgregarLibro(libro))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Datos agregados correctamente');", true);
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Error en la operación, inténtelo de nuevo');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "alert('Llene correctamente los datos');", true);
            }

        }
        private bool validar() //validar cajas
        {
            if (txtAnioPublicacion.Text.Equals("") || txtAutores.Text.Equals("") || txtCarrera.Text.Equals("") || txtISBN.Text.Equals("") || txtMateria.Text.Equals("") || txtNumeroEdicion.Text.Equals("") || txtPaisPublicacion.Text.Equals("") || txtSinopsis.Text.Equals("") || txtTitulo.Text.Equals(""))
            {
                return false;
            }
            if (txtISBN.Text.Length<9 || txtISBN.Text.Length > 13)
            {
                return false;
            }
            return true;
        }

        protected void btnCancelarOperacion_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}