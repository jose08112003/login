using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using login.clases;
using login.Formularios;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.Shared;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Globalization;

namespace login.Formularios
{
    public partial class frmroles : Form
    {
        public frmroles()
        {
            InitializeComponent();
        }
        private string mFieldValue;
        internal string FieldValue
        {
            get { return mFieldValue; }
        }
        internal bool Execute(string SQL, int ColumnNumberToRetrive)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(SQL, clases.GLOBALES.miconexion);
            da.Fill(ds, "Table");

            SearchForm frmSearchForm = new SearchForm();
            frmSearchForm.mColNumber = ColumnNumberToRetrive;
            frmSearchForm.mDS = ds;
            ds = null;
            frmSearchForm.ShowDialog();
            if (frmSearchForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                mFieldValue = frmSearchForm.ReturnValue;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            busca();
        }
        clases.clroles G;
        clases.conexion c;
        internal int mColNumber;
        internal DataSet mDS;

        public string ReturnValue { get; internal set; }


        private void busca()
        {
            try
            {
                G = new clases.clroles();
                clases.conexion con = new clases.conexion();
                if (con.Execute(G.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        TXTCHO_CLAVE.Text = con.FieldValue;
                        consultar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }
        private void consultar()
        {
            if (!(TXTCHO_CLAVE.Text == ""))
            {
                try
                {
                    clases.clroles B = new clases.clroles(byte.Parse(TXTCHO_CLAVE.Text));
                    DataSet ds = new DataSet();
                    c = new clases.conexion(B.CONSULTARI());
                    ds = c.consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        TXTCHO_NOMBRE.Text = ds.Tables["Tabla"].Rows[0]["ROL"].ToString();
                        /*TXTCHO_PLACAS.Text = ds.Tables["Tabla"].Rows[0]["CHO_PLACAS"].ToString();
                        TXTCHO_MODELO.Text = ds.Tables["Tabla"].Rows[0]["CHO_MODELO"].ToString();
                        TXTCHO_TELEFONO.Text = ds.Tables["Tabla"].Rows[0]["CHO_TELEFONO"].ToString();
                        TXTCHO_COLOR.Text = ds.Tables["Tabla"].Rows[0]["CHO_COLOR"].ToString();
                        // TXTLOT_LOTE.Select(TXTLOT_LOTE.Text.Length, 0);*/


                    }
                    else

                        MessageBox.Show("No Existe este dato");
                    TXTCHO_NOMBRE.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }

            }
        }
        clases.clroles B;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            graba();
        }
        private void graba()
        {
            B = new clases.clroles(byte.Parse(TXTCHO_CLAVE.Text));
            DataSet ds = new DataSet();
            c = new clases.conexion(B.CONSULTARI());
            ds = c.consultar();
            G = new clases.clroles(byte.Parse(TXTCHO_CLAVE.Text), TXTCHO_NOMBRE.Text);
            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new clases.conexion(G.modificar());
            else
                c = new clases.conexion(G.GRABAR());
            MessageBox.Show(c.ejecutar());
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmroles_Load(object sender, EventArgs e)
        {
            cargarfolio();
        }
        private void cargarfolio()
        {
            B = new clases.clroles();
            DataSet ds = new DataSet();
            c = new clases.conexion(B.consecutivo());
            ds = c.consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                TXTCHO_CLAVE.Text = ds.Tables["Tabla"].Rows[0]["FOLIO"].ToString();
                /*TXTCHO_PLACAS.Text = ds.Tables["Tabla"].Rows[0]["CHO_PLACAS"].ToString();
                TXTCHO_MODELO.Text = ds.Tables["Tabla"].Rows[0]["CHO_MODELO"].ToString();
                TXTCHO_TELEFONO.Text = ds.Tables["Tabla"].Rows[0]["CHO_TELEFONO"].ToString();
                TXTCHO_COLOR.Text = ds.Tables["Tabla"].Rows[0]["CHO_COLOR"].ToString();
                // TXTLOT_LOTE.Select(TXTLOT_LOTE.Text.Length, 0);*/


            }
        }
        

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //boton impresora
            Catalogos.Plantillas x = new Catalogos.Plantillas();
            Cursor.Current = Cursors.WaitCursor;
            clases.rptroles orptPrueba;
            ConnectionInfo oConexInfo;
            Tables oListaTablas;
            TableLogOnInfo oTablaConexInfo;
            oConexInfo = new ConnectionInfo();
            oConexInfo.ServerName = clases.GLOBALES.server;
            oConexInfo.DatabaseName = clases.GLOBALES.dbn;

            Boolean IntegratedSecurity = false;
            oConexInfo.IntegratedSecurity = IntegratedSecurity;
            oConexInfo.UserID = clases.GLOBALES.UserID;
            oConexInfo.Password = clases.GLOBALES.Password;
            oConexInfo.DatabaseName = clases.GLOBALES.dbn;
            oConexInfo.Type = ConnectionInfoType.Query;

            //orptPrueba = new rptventasperiodo();
            orptPrueba = new rptroles();
            oListaTablas = orptPrueba.Database.Tables;
            foreach (Table roTabla in oListaTablas)
            {
                oTablaConexInfo = roTabla.LogOnInfo;
                oTablaConexInfo.ConnectionInfo = oConexInfo;
                roTabla.ApplyLogOnInfo(oTablaConexInfo);
            }

            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;


            x.crystalReportViewer1.ReportSource = orptPrueba;
            x.ShowDialog();
            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
