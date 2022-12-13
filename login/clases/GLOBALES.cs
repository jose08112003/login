using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.clases
{
   public static class GLOBALES
    {
        static public string dbn = "BDveterinaria ";

        static public string server = @"jose123sql";

        static public string Password = "08112003";

        static public string seguridad = "Integrated Security=True";

        static public string UserID = "usuario1";

        static public string miconexion = @"Data Source = " + server + "; Initial Catalog = " + dbn + "; Persist Security Info = True; User ID = sa; Password = " + Password;
    }
}
