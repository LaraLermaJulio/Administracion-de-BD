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
    public partial class frmAgreEditInventario : Form
    {
        private Inventario inventario;
        public frmAgreEditInventario(Inventario inventario)
        {
            InitializeComponent();
            this.inventario = inventario;
            List<Areas> areas = new AreasDAO().GetAreas();
            cmbAreas.DataSource = areas;
            cmbAreas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAreas.DisplayMember = "Nombre";
            cmbAreas.ValueMember = "Id";
            if (inventario ==null)
            {
                this.Text = "Agregar";
            }
            else
            {
                this.Text = "Editar";
                txtNombre.Text = inventario.NombreCorto;
                txtDescripcion.Text = inventario.Descripcion;
                txtSerie.Text = inventario.Serie;
                txtColor.Text = inventario.Color;
                dtpFechaAdqusion.Value = inventario.FechaAdquision;
                txtTipoAdquision.Text = inventario.TipoAdquision;
                txtObservaciones.Text = inventario.Observaciones;
                cmbAreas.SelectedValue = inventario.Areas_id;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            InventarioDAO i = new InventarioDAO();
            if (txtNombre.Text.Length > 45 || txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Nombre es un campo obligatorio que acepta hasta 45 caracteres.");
            }
            else if (txtDescripcion.Text.Length > 45 || txtDescripcion.Text.Equals(""))
            {
                MessageBox.Show("Descripción es un campo obligatorio que acepta hasta 45 caracteres.");
            }
            else if (txtSerie.Text.Length > 45 || txtSerie.Text.Equals(""))
            {
                MessageBox.Show("Serie es un campo obligatorio que acepta hasta 45 caracteres alfanuméricos.");
            }
            else if (txtColor.Text.Length > 45 || txtColor.Text.Equals(""))
            {
                MessageBox.Show("Color es un campo obligatorio que acepta hasta 45 caracteres.");
            }
            else if (txtColor.Text.Length > 45 || txtColor.Text.Equals(""))
            {
                MessageBox.Show("Color es un campo obligatorio que acepta hasta 45 caracteres.");
            }
            else if (txtTipoAdquision.Text.Length > 45 || txtTipoAdquision.Text.Equals(""))
            {
                MessageBox.Show("Tipo de adquisición es un campo obligatorio que acepta hasta 45 caracteres.");
            }
            else if (txtObservaciones.Text.Length > 45 || txtTipoAdquision.Text.Equals(""))
            {
                MessageBox.Show("Observaciones es un campo obligatorio que acepta hasta 45 caracteres.");
            }
            else
            {
                if (inventario==null)
                {
                    bool modificion=i.InsertElementInventario(txtNombre.Text, 
                        txtDescripcion.Text, txtSerie.Text,
                        txtColor.Text, dtpFechaAdqusion.Value,
                        txtTipoAdquision.Text, txtObservaciones.Text,
                        Convert.ToInt32(cmbAreas.SelectedValue));
                    if (modificion == true)
                    {
                        MessageBox.Show("El elemento se agrego con éxito al inventario.", "Éxito", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error durante la operación.", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    bool modificion= i.UpdateElementInventario(inventario.Id,txtNombre.Text,
                        txtDescripcion.Text, txtSerie.Text,
                        txtColor.Text, dtpFechaAdqusion.Value,
                        txtTipoAdquision.Text, txtObservaciones.Text,
                        Convert.ToInt32(cmbAreas.SelectedValue));
                    if (modificion == true)
                    {
                        MessageBox.Show("El elemento del inventario se actualizó con éxito.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignorar el evento
            }
        }
    }
}
