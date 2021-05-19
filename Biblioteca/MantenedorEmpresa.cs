using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MantenedorEmpresa
    {
        public DataTable BuscarEmpresa(string emp)
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());

            sql.Open();
            string query = "select * from Empresa where Nombre='" + emp + "'";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, sql);

            da.Fill(dt);
            sql.Close();
            return dt;
        }

        public void ModificarEmpresa(Empresa empresa)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();

            string consulta = "UPDATE Empresa SET Descripcion = '"+empresa.DescripcionEmpresa+"' where Nombre = '"+empresa.NombreEmpresa+"' ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }
    }
}
