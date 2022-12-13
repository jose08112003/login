using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.clases
{
    internal class Datos_General
    {
        private string Nombre_Empresa;
        private string Direccion;
        private string Telefono;
        private string Gerente;

        public Datos_General(string nombre_Empresa, string direccion, string telefono, string gerente)
        {
            Nombre_Empresa = nombre_Empresa;
            Direccion = direccion;
            Telefono = telefono;
            Gerente = gerente;
        }
        public Datos_General()
        {

        }

        public Datos_General(string nombre_Empresa)
        {
            Nombre_Empresa = nombre_Empresa;
        }

        public string GRABAR()
        {
            return (" insert into DATOS_GENERALES values ('" + this.Nombre_Empresa + "','" + this.Direccion + "' ," + this.Telefono + "' ," + this.Gerente + "')");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  DATOS_GENERALES WHERE NOMBRE_DE_LA_EMPRESA = '" + this.Nombre_Empresa + "'");
        }
        public string modificar()
        {
             return (" update DATOS_GENERALES set NOMBRE_DE_LA_EMPRESA ='" + this.Nombre_Empresa + "', DIRECCION ='" + this.Direccion +  "' , TELEFONO ='" + this.Telefono + "'  WHERE GERENTE = '" + this.Gerente + "'" );
        }
        public string consultageneral()
        {
            return ("SELECT NOMBRE_DE_LA_EMPRESA as NOMBRE_DE_LA_EMPRESA,DIRECCION as DIRECCION,TELEFONO as TELEFONO,GERENTE as GERENTE FROM DATOS_GENERALES");
        }
        public string consecutivo()
        {
            return ("SELECT COUNT(*) +1 AS FOLIO FROM DATOS_GENERALES");
        }
    }
}
