using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login.clases;
using login.Formularios;

namespace Sistema.Forms
{
    public partial class frmDatos_Generales : Form
    {
        public frmDatos_Generales()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            busca();
        }
        Datos_General G;
        
        private void busca()
        {
            try
            {
                G = new Datos_General();
                conexion con = new conexion();
                if (con.Execute(G.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        TXTNOMEMPRESA.Text = con.FieldValue;
                        consultar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        conexion c;
        Datos_General B;
        private void consultar()
        {
            if (!(TXTNOMEMPRESA.Text == ""))
            {
                try
                {
                    Datos_General B = new Datos_General(TXTNOMEMPRESA.Text);
                    DataSet ds = new DataSet();
                    c = new conexion(B.CONSULTARI());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        TXTNOMEMPRESA.Text = ds.Tables["Tabla"].Rows[0]["Nombre_empresa"].ToString();
                        TXTDIRECCION.Text = ds.Tables["Tabla"].Rows[0]["Direccion"].ToString();
                        TXTTELEFONO.Text = ds.Tables["Tabla"].Rows[0]["Telefono"].ToString();
                        TXTNOMGERENTE.Text = ds.Tables["Tabla"].Rows[0]["Gerente"].ToString();
                    }
                    else

                        MessageBox.Show("No Existe este dato");
                    TXTNOMEMPRESA.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if ((TXTNOMEMPRESA.Text == "") || (TXTDIRECCION.Text == "") || (TXTTELEFONO.Text == "") || (TXTNOMGERENTE.Text == ""))
            {
                MessageBox.Show("Faltan datos que rellenar");
            }
            else
            {
                graba();
            }
        }
        private void graba()
        {
            Datos_General B = new Datos_General(TXTNOMEMPRESA.Text);
            DataSet ds = new DataSet();
            c = new conexion(B.CONSULTARI());
            ds = c.consultar();
            G = new Datos_General(TXTNOMEMPRESA.Text, TXTDIRECCION.Text,TXTTELEFONO.Text,TXTNOMGERENTE.Text);
            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new conexion(G.modificar());
            else
                c = new conexion(G.GRABAR());
            MessageBox.Show(c.ejecutar());
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TXTTELEFONO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void frmDatos_Generales_Load(object sender, EventArgs e)
        {

        }
    }
}
