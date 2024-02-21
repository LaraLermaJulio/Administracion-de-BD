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
    public partial class frmInventarios : Form
    {
        private List<Inventario> inventario;
        public frmInventarios()
        {

            InitializeComponent();
            inventario = new InventarioDAO().GetInventario();
            if(inventario == null) {
            
                MessageBox.Show("Error de conexión.");
                this.Close();
                return;
            }
            else if (inventario != null)
            {
                dgvInventarios.DataSource = inventario;
            }
            else if(inventario.Count==0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("NombreCorto", typeof(string));
                dt.Columns.Add("Descripcion", typeof(string));
                dt.Columns.Add("Serie", typeof(string));
                dt.Columns.Add("Color", typeof(string));
                dt.Columns.Add("FechaAdquision", typeof(string));
                dt.Columns.Add("TipoAdquision", typeof(string));
                dt.Columns.Add("Observaciones", typeof(string));
                dt.Columns.Add("Areas_id", typeof(string));
                dt.Columns.Add("Area", typeof(string));
                dgvInventarios.DataSource = dt;
            }

            dgvInventarios.Font = new Font("Microsoft Sans Serif", 12);
            //Desactivar la adición, eliminación y edición de el gridview
            dgvInventarios.AllowUserToAddRows = false;
            dgvInventarios.AllowUserToDeleteRows = false;
            dgvInventarios.EditMode = DataGridViewEditMode.EditProgrammatically;
            //Activar la selección por fila en lugar de columna
            dgvInventarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Desactivar los encabezados de fila si no son necesarios.
            dgvInventarios.RowHeadersVisible = false;
            // Ajustar el ancho de las columnas para que llenen el espacio disponible.
            dgvInventarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvInventarios.Columns["Id"].Visible = false;
            dgvInventarios.Columns["NombreCorto"].HeaderText = "Nombre";
            dgvInventarios.Columns["Descripcion"].HeaderText = "Descripción";
            dgvInventarios.Columns["Serie"].HeaderText = "Serie";
            dgvInventarios.Columns["Color"].HeaderText = "Color";
            dgvInventarios.Columns["FechaAdquision"].HeaderText = "Fecha de adquisición";
            dgvInventarios.Columns["TipoAdquision"].HeaderText = "Tipo de adquisición";
            dgvInventarios.Columns["Observaciones"].HeaderText = "Observaciones";
            dgvInventarios.Columns["Areas_id"].Visible = false;
            dgvInventarios.Columns["Area"].HeaderText = "Área";
        }

        public void actualizarDGV()
        {
            inventario = new InventarioDAO().GetInventario();
            dgvInventarios.DataSource = inventario;
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            frmAgreEditInventario agregar = new frmAgreEditInventario(null);
            agregar.ShowDialog();
            actualizarDGV();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvInventarios.SelectedRows[0];
            Inventario inventario = filaSeleccionada.DataBoundItem as Inventario;
            frmAgreEditInventario editar = new frmAgreEditInventario(inventario);
            editar.ShowDialog();
            actualizarDGV();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow filaSeleccionada = dgvInventarios.SelectedRows[0];
            int id = int.Parse(filaSeleccionada.Cells[0].Value.ToString());
            string nombre = filaSeleccionada.Cells[1].Value.ToString();
            string message = "¿Está seguro/a que desea eliminar el elemento " + nombre + " ? ";
            string caption = "Eliminacion de elemento de inventario";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                bool modificacion = new InventarioDAO().DeleteElementInventario(id);
                if (modificacion)
                {
                    actualizarDGV();
                    MessageBox.Show("Eliminado exitosamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo realizar la operación.");
                }

            }
        }
    }
}
