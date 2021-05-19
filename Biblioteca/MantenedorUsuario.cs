using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MantenedorUsuario
    {
        public void GenerarContraseña(Usuario usu)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "update Usuario set Contrasena = concat('cmeg',substring(Contrasena,3,4)) where Correo = '"+usu.Correo+"';";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }


        public DataTable BuscarUsuario(string correo)
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());

            sql.Open();
            string query = "SELECT * FROM Usuario WHERE Correo = '" + correo + "'";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, sql);

            da.Fill(dt);
            sql.Close();

            return dt;
        }

    }
}
