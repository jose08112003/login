using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using login.clases;

namespace Sistema
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cargarroles();
            cargarfolio();
        }
        private void cargarroles()
        {
            DataSet ds = new DataSet();
            clroles s = new clroles();
            conexion c = new conexion(s.consultageneral());
            ds = c.consultar();
            cdroles.DataSource = ds.Tables[0];
            cdroles.DisplayMember = ds.Tables[0].Columns["ROL"].ToString();
            cdroles.ValueMember = ds.Tables[0].Columns["ID_ROL"].ToString();
        }

        /*byte puesto = 0;
              puesto = byte.parse
               (xmbpuesto.selectedvalue.tostring)

        byte */
        public string consultafeneral()
        {
            return ("select * ");
        }

        usuario G;
        private void busca()
        {
            try
            {
                G = new usuario();
                conexion con = new conexion();
                if (con.Execute(G.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        textBox1.Text = con.FieldValue;
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
        usuario B;
        private void consultar()
        {
            if (!(textBox1.Text == ""))
            {
                try
                {
                    B = new usuario(Convert.ToInt32(textBox1.Text));
                    DataSet ds = new DataSet();
                    c = new conexion(B.consultaria());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        textBox1.Text = ds.Tables["Tabla"].Rows[0]["ID_USUARIO"].ToString();
                        textBox4.Text = ds.Tables["Tabla"].Rows[0]["USUARIO"].ToString();
                        textBox2.Text = ds.Tables["Tabla"].Rows[0]["CONTRASEÑA"].ToString();
                        textBox5.Text = ds.Tables["Tabla"].Rows[0]["NOMBRE"].ToString();
                        cdroles.Text = ds.Tables["Tabla"].Rows[0]["ID_ROL"].ToString();
                    }
                    else

                        MessageBox.Show("No Existe este dato");
                    textBox4.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }
            }
        }

        void cargarfolio()
        {
            B = new usuario();
            DataSet ds = new DataSet();
            c = new conexion(B.consecutivo());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                textBox1.Text = ds.Tables["Tabla"].Rows[0]["FOLIO"].ToString();
            }
        }

        private void graba()
        {
            usuario B = new usuario(Convert.ToInt32(textBox1.Text));
            DataSet ds = new DataSet();
            c = new conexion(B.consultaria());
            ds = c.consultar();
            G = new usuario(Convert.ToInt32(textBox1.Text), textBox4.Text, Contraseña.Encrypt.GetMD5(textBox2.Text), byte.Parse(cdroles.SelectedValue.ToString()), textBox5.Text);//, true
            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new conexion(G.modificar());
            else
                c = new conexion(G.grabar());
            MessageBox.Show(c.ejecutar());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            busca();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == ""))
            {
                MessageBox.Show("Falta de rellenar datos");
            }
            else
            {
                if (textBox2.Text == textBox3.Text)
                {
                    graba();
                    cargarfolio();
                    textBox4.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("La contraseña no conside");
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }

}