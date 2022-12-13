using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.clases
{
    class clusuario
    {
        private String USUARIO;
        private String CONTRASEÑA;
        private String NOMBRE;
        private byte v;

        

        public clusuario(string uSUARIO, string cONTRASEÑA)
        {
            USUARIO = uSUARIO;
            CONTRASEÑA = cONTRASEÑA;
        }

        public string CONSULTAR()
        {
            return ("SELECT USUARIO ,CONTRASEÑA FROM USUARIO WHERE USUARIO='" + this.USUARIO + "' and CONTRASEÑA = dbo.MD5('" + this.CONTRASEÑA + "')");
        }
       
    }
}

