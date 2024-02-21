using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoU5
{
    public partial class frmAgregarEditarArea : Form
    {
        private Areas area;
        public frmAgregarEditarArea(Areas area)
        {
            InitializeComponent();
            this.area = area;
            List<Areas> areas = new AreasDAO().GetAreas();
            if (area == null)
            {
                this.Text = "Agregar";
            }
            else
            {
                this.Text = "Editar";
                txtNombre.Text = area.Nombre;
                txtUbicacion.Text = area.Ubicacion;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AreasDAO a = new AreasDAO();
            if (txtNombre.Text.Length > 45 || txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Nombre es un campo obligatorio que acepta hasta 45 caracteres.");
            }
            else if (txtUbicacion.Text.Length > 45 || txtUbicacion.Text.Equals(""))
            {
                MessageBox.Show("Ubicación es un campo obligatorio que acepta hasta 45 caracteres.");
            }
            else
            {
                if (area == null)
                {
                    bool modificion = a.InsertArea(txtNombre.Text,txtUbicacion.Text);
                    if (modificion == true)
                    {
                        MessageBox.Show("El área se agrego con éxito.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error durante la operación.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bool modificion = a.UpdateArea(area.Id,txtNombre.Text, txtUbicacion.Text);
                    if (modificion == true)
                    {
                        MessageBox.Show("El área se actualizó con éxito.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error durante la operación.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
