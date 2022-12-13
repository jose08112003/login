using login.Formularios;
using Sistema;
using Sistema.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void rOLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmroles a = new frmroles();
            this.Hide(); a.Show();
        }

        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios x = new frmUsuarios();
            this.Hide(); x.Show();
        }

        private void mODULOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModulos x = new frmModulos();
            this.Hide(); x.Show();
        }

        private void gENERALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatos_Generales x = new frmDatos_Generales();
            this.Hide(); x.Show();
        }
    }
}
