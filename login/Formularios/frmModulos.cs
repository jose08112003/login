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

namespace Sistema.Forms
{
    public partial class frmModulos : Form
    {
        public frmModulos()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            busca();
        }
        clmodulo G;
        private void busca()
        {
            try
            {
                G = new clmodulo();
                conexion con = new conexion();
                if (con.Execute(G.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        TXTCLAVE.Text = con.FieldValue;
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
        clmodulo B;
        private void consultar()
        {
            if (!(TXTCLAVE.Text == ""))
            {
                try
                {
                    clmodulo B = new clmodulo(byte.Parse(TXTCLAVE.Text));
                    DataSet ds = new DataSet();
                    c = new conexion(B.CONSULTARI());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        TXTCLAVE.Text = ds.Tables["Tabla"].Rows[0]["id_modulo"].ToString();
                        TXTNOMBREMODUL.Text = ds.Tables["Tabla"].Rows[0]["nombre_modulo"].ToString();
                    }
                    else

                        MessageBox.Show("No Existe este dato");
                    TXTCLAVE.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (TXTNOMBREMODUL.Text == "")
            {
                MessageBox.Show("Introduzca un nombre al modulo");
            }
            else
            {
                graba();
                cargarfolio();
                TXTNOMBREMODUL.Clear();
            }
        }
        private void graba()
        {
            clmodulo B = new clmodulo(byte.Parse(TXTCLAVE.Text));
            DataSet ds = new DataSet();
            c = new conexion(B.CONSULTARI());
            ds = c.consultar();
            G = new clmodulo(byte.Parse(TXTCLAVE.Text), TXTNOMBREMODUL.Text);
            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new conexion(G.modificar());
            else
                c = new conexion(G.GRABAR());
            MessageBox.Show(c.ejecutar());
        }

        private void frmModulos_Load(object sender, EventArgs e)
        {
            cargarfolio();
        }
        private void cargarfolio()
        {
            B = new clmodulo();
            DataSet ds = new DataSet();
            c = new conexion(B.consecutivo());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                TXTCLAVE.Text = ds.Tables["Tabla"].Rows[0]["FOLIO"].ToString();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
