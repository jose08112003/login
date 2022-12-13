using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.clases
{
    class clpermisos
    {
        private int ID;
        private int ID_ROL;
        private int ID_MODULO;
        private string GRABAR_PER;
        private string BUSCAR_PER;
        private string MODIFICAR_PER;
        private string ELIMIAR_PER;

        public clpermisos()
        {

        }

        public clpermisos(int iD, int iD_ROL, int iD_MODULO, string gRABAR_PER, string bUSCAR_PER, string mODIFICAR_PER, string eLIMIAR_PER)
        {
            ID = iD;
            ID_ROL = iD_ROL;
            ID_MODULO = iD_MODULO;
            GRABAR_PER = gRABAR_PER;
            BUSCAR_PER = bUSCAR_PER;
            MODIFICAR_PER = mODIFICAR_PER;
            ELIMIAR_PER = eLIMIAR_PER;
        }
        public string GRABAR()
        {
            return (" insert into PERMISOS values ('" + this.ID_MODULO + "','" + this.ID_ROL + "' ,"+ this.GRABAR_PER + "' ," +this.BUSCAR_PER + "' ," + this.MODIFICAR_PER + "' ," + this.ELIMIAR_PER + "' ,");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM PERMISOS WHERE ID = '" + this.ID_MODULO + "'");
        }
        public string modificar()
        {
            return (" update MODULOS set MODULOS = '" + this.ID_MODULO + "' WHERE ID = '" + this.ID_MODULO + "'");
        }
        public string consultageneral()
        {
            return (" SELECT ID as ID , MODULOS as MODULOS FROM MODULOS");
        }
        public string consecutivo()
        {
            return ("SELECT COUNT(*) +1 AS FOLIO FROM MODULOS");
        }
    }
    
}
