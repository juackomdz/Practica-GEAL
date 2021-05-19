using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MantenedorFotosEmpresa
    {
        public DataTable BuscarFotoEmpresa(string foto)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "select a.IdFotoEmp,a.Descripcion,a.Imagen,d.Nombre, a.NombreImagen from FotoEmpresa a left join empresa d on(a.RutEmpresa = d.RutEmpresa)  where a.NombreImagen='" + foto + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void EliminarFotoEmpresa(FotoEmpresa foto)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "DELETE FROM FotoEmpresa Where NombreImagen='" + foto.NombreImagen + "';";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }
        public void ModificarFotoEmpresa(FotoEmpresa foto, string id)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "UPDATE fotoEmpresa SET RutEmpresa=(select RutEmpresa from Empresa where Nombre='" + foto.Empresa.NombreEmpresa +
                "'),NombreImagen='" + foto.NombreImagen + "',Descripcion='" + foto.Descripcion + "' where IdFotoEmp='" + id + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }
    }
}
