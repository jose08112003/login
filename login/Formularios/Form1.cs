using login.clases;
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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        clases.conexion c;
        clases.clusuario CU;
        private void button1_Click(object sender, EventArgs e)
        {
            ingresar();
            
        }
        private void ingresar()
        {
            clases.clusuario U = new clases.clusuario(textUSU.Text, textPASS.Text);
            DataSet ds = new DataSet();
            c = new clases.conexion(U.CONSULTAR());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                Form2 x = new Form2();
                x.Show(); this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña invalidos", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textUSU.Focus();
                
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {


        }
    }
}
