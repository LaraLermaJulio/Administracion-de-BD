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
    public partial class frmAreas : Form
    {
        private List<Areas> areas;
        public frmAreas()
        {
            InitializeComponent();
            areas = new AreasDAO().GetAreas();
            if (areas == null)
            {
                MessageBox.Show("Error de conexión.");
                this.Close();
                return;
            }
            else if (areas != null)
            {
                dgvAreas.DataSource = areas;
            }
            else if (areas.Count == 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Ubicacion", typeof(string));
                dgvAreas.DataSource = dt;
            }

            dgvAreas.Font = new Font("Microsoft Sans Serif", 12);
            //Desactivar la adición, eliminación y edición de el gridview
            dgvAreas.AllowUserToAddRows = false;
            dgvAreas.AllowUserToDeleteRows = false;
            dgvAreas.EditMode = DataGridViewEditMode.EditProgrammatically;
            //Activar la selección por fila en lugar de columna
            dgvAreas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Desactivar los encabezados de fila si no son necesarios.
            dgvAreas.RowHeadersVisible = false;
            // Ajustar el ancho de las columnas para que llenen el espacio disponible.
            dgvAreas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAreas.Columns["Id"].Visible = false;
            dgvAreas.Columns["Nombre"].HeaderText = "Nombre";
            dgvAreas.Columns["Ubicacion"].HeaderText = "Ubicación";
        }

        public void actualizarDGV()
        {
            areas = new AreasDAO().GetAreas();
            dgvAreas.DataSource = areas;
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            frmAgregarEditarArea agregar = new frmAgregarEditarArea(null);
            agregar.ShowDialog();
            actualizarDGV();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvAreas.SelectedRows[0];
            Areas areas = filaSeleccionada.DataBoundItem as Areas;
            frmAgregarEditarArea editar = new frmAgregarEditarArea(areas);
            editar.ShowDialog();
            actualizarDGV();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvAreas.SelectedRows[0];
            int id = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            string nombre = filaSeleccionada.Cells[1].Value.ToString();
            string message = "¿Está seguro/a que desea eliminar el área " + nombre + " ? "+
                " Los elementos en inventario relacionado a esta área también se eliminarán.";
            string caption = "Eliminacion de área.";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                bool modificacion = new AreasDAO().DeleteArea(id);
                if (modificacion)
                {
                    actualizarDGV();
                    MessageBox.Show("Eliminada exitosamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la operación.");
                }

            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
