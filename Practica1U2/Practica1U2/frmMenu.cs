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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            frmInventarios frm = new frmInventarios();
            this.Hide();
            try
            {
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión.");
            }
            this.Show();
        }

        private void btnAreas_Click(object sender, EventArgs e)
        {
            frmAreas frm = new frmAreas();
            this.Hide();
            try
            {
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión.");
            }
            this.Show();
        }
    }
}
