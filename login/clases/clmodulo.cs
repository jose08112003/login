using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.clases
{
    class clmodulo
    {
        private int ID_MODULO;
        private string NOMBRE_MOD;

        public clmodulo(int iD_MODULO, string nOMBRE_MOD)
        {
            ID_MODULO = iD_MODULO;
            NOMBRE_MOD = nOMBRE_MOD;
        }

        public clmodulo(int iD_MODULO)
        {
            ID_MODULO = iD_MODULO;
        }
        public clmodulo()
        {

        }

        public string GRABAR()
        {
            return (" insert into MODULOS values ('" + this.ID_MODULO + "','" + this.NOMBRE_MOD + "')");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  MODULOS WHERE ID = '" + this.ID_MODULO + "'");
        }
        public string modificar()
        {
            return (" update MODULOS set NOMBRE_MODULO = '" + this.NOMBRE_MOD + "' WHERE ID = '" + this.ID_MODULO + "'");
        }
        public string consultageneral()
        {
            return (" SELECT ID as ID , NOMBRE_MODULO as NOMBRE_MODULO FROM MODULOS");
        }
        public string consecutivo()
        {
            return ("SELECT COUNT(*) +1 AS FOLIO FROM MODULOS");
        }
    }
}
