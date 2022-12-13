using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.clases
{
    internal class usuario
    {
        private int id_usuario;
        private string nombre;
        private string usuarios;
        private string contraseña;
        private byte rol;

        public usuario(int id_usuario, string usuarios, string contraseña, byte rol, string nombre)
        {
            this.id_usuario = id_usuario;
            this.usuarios = usuarios;
            this.contraseña = contraseña;
            this.rol = rol;
            this.nombre = nombre;
        }
        public usuario(int id_usuario)
        {
            this.id_usuario = id_usuario;
        }
        public usuario()
        {
        }
        public string grabar()
        {
            return (" insert into USUARIO values ('" + this.id_usuario + "','" + this.usuarios + "','" + this.contraseña + "','" + this.rol + "','" + this.nombre + "')");
        }
        public string consultaria()
        {
            return (" SELECT * FROM  USUARIO WHERE ID_USUARIO= '" + this.id_usuario + "'");
        }
        public string modificar()
        {
            return (" update USUARIO set  ID_USUARIO ='" + this.id_usuario + "', USUARIO ='" + this.usuarios + "', CONTRASEÑA ='" + this.contraseña + "', ID_ROL ='" + this.rol + "', NOMBRE' = " + this.nombre + "')");
        }
        public string consultageneral()
        {
            return (" SELECT ID_USUARIO as ID_USUARIO ,USUARIO as USUARIO, CONTRASEÑA as CONTRASEÑA , ID_ROL as ID_ROL, NOMBRE as NOMBRE FROM  USUARIO");
        }
        public string consecutivo()
        {
            return ("select count(*) + 1 as FOLIO from USUARIO");
        }
    }
}
