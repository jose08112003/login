using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.clases;
using login.Formularios;

namespace login.clases
{
    class clroles
    {
        public byte id;
        public string nombre;

        // Método constructor para grabar y modificar
        public clroles(byte id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        // Método constructor para consulta individual
        public clroles(byte id)
        {
            this.id = id;
        }
        // Método constructor busqueda de toda la información de la tabla de roles
        public clroles()
        {

        }

        public string GRABAR()
        {
            return (" insert into ROL values ('" + this.id + "','" + this.nombre + "')");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  ROL WHERE ID_ROL = '" + this.id + "'");
        }
        public string modificar()
        {
            return (" update ROL set ROL = '" + this.nombre + "' WHERE ID_ROL = '" + this.id + "'");
        }
        public string consultageneral()
        {
            return (" SELECT ID_ROL as ID_ROL , ROL as ROL FROM ROL");
        }
        public string consecutivo()
        {
            return ("SELECT COUNT(*) +1 AS FOLIO FROM ROL");
        }
    }
}
