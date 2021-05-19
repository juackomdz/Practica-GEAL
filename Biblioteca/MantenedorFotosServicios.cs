using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MantenedorFotosServicios
    {

        public void ModificarFotoServicio(FotoServicio foto, string id)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "UPDATE FotoServicio SET IdServicio=(select IdServicio from Servicio where NombreServicio='" + foto.Servicio.NombreServicio +
                "'),NombreImagen='" + foto.NombreImagen + "',Descripcion='" + foto.Descripcion + "' where IdFotoServ='" + id + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }

        public DataTable BuscarFotoServicio(string foto)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "select a.IdfotoServ,a.Descripcion,a.Imagen,b.nombreServicio, a.NombreImagen from FotoServicio a left join Servicio b on(a.IdServicio= b.IdServicio)  where a.NombreImagen='" + foto + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void EliminarFotoServicio(FotoServicio foto)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "DELETE FROM FotoServicio Where NombreImagen='" + foto.NombreImagen + "';";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }
    }
}
