using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MantenedorServicios
    {

        public void RegistrarServicio(Servicio serv)
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());

            sql.Open();
            string consulta = "INSERT INTO Servicio(NombreServicio,DescripcionServicio) VALUES ('" + serv.NombreServicio + "','" + serv.DescripcionServicio + "');";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, sql);

            da.Fill(dt);
            sql.Close();
        }


        public DataTable BuscarServicio(string ser)
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());

            sql.Open();
            string query = "SELECT * FROM Servicio WHERE NombreServicio = '" + ser + "'";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, sql);

            da.Fill(dt);
            sql.Close();

            return dt;
        }

        

        public void EliminarServicio(Servicio serv)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "DELETE FROM Servicio Where NombreServicio='" + serv.NombreServicio + "';";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();

        }

        public void ModificarServicio(Servicio servi)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();

            string consulta = "UPDATE Servicio SET NombreServicio = '"+servi.NombreServicio+"', DescripcionServicio = '"+servi.DescripcionServicio
                +"' where IdServicio = '"+servi.IdServicio+"'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }


    }
}
