using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Conexion
    {
        public static string CadenaDeConexion()
        {
            return "Data Source = KEVIN\\SQLEXPRESS; Initial Catalog = geal; Integrated Security = True";
        }
    }
}
