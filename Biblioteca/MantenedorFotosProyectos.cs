using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MantenedorFotosProyectos
    {
        public DataTable BuscarFoto(string foto)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "select a.idfotopro,a.Descripcion,b.NombreProyecto,a.imagen, a.NombreImagen from fotoproyecto a left join proyecto b on(a.IdProyecto = b.IdProyecto) where nombreimagen='" + foto + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }



        public void EliminarFoto(FotoProyecto foto)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "DELETE FROM FotoProyecto Where NombreImagen='" + foto.NombreImagen + "';";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }


        public void ModificarFoto(FotoProyecto foto, string id)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "UPDATE fotoproyecto SET IdProyecto=(select idproyecto from proyecto where nombreproyecto='" + foto.Proyecto.NombreProyecto +
                "'),NombreImagen='" + foto.NombreImagen +
                "',Descripcion='" + foto.Descripcion + "' where IdFotopro='" + id + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }


    }
}
