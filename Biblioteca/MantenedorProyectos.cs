using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MantenedorProyectos
    {
        public void AgregarProyecto(Proyecto pro, string rut)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "INSERT INTO Proyecto(NombreProyecto, DescripcionPro, RutCliente, FechaInicio, FechaFin) VALUES('" + pro.NombreProyecto
                + "','" + pro.Descripcion + "',(Select RutCliente from Cliente where NombreCliente ='" + rut
                + "'),convert(date,'" + pro.FechaInicio + "'),convert(date,'" + pro.FechaFin + "'))";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }

        public DataTable BuscarIdProyecto(int idPro)
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());

            sql.Open();
            string consulta = "select a.IdProyecto,a.DescripcionPro,c.NombreCliente,a.FechaInicio,a.FechaFin, a.NombreProyecto from proyecto a join cliente c on (a.RutCliente=c.RutCliente) where IdProyecto='" + idPro + "'";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, sql);

            da.Fill(dt);
            sql.Close();

            return dt;
        }

        public DataTable BuscarProyecto(string nom)
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());

            sql.Open();
            string consulta = "select a.IdProyecto,a.DescripcionPro,c.NombreCliente,a.FechaInicio,a.FechaFin, a.NombreProyecto from proyecto a join cliente c on (a.RutCliente=c.RutCliente) where NombreProyecto='" + nom + "'";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, sql);

            da.Fill(dt);
            sql.Close();

            return dt;
        }



        public void EliminarProyecto(Proyecto pro)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "Delete from FotoProyecto where IdProyecto= '" + pro.IdProyecto + "'; DELETE FROM Proyecto WHERE IdProyecto='" + pro.IdProyecto + "'; ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }

        public void ModificarProyectos(Proyecto proy, string nombreCliente)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();

            string consulta = "UPDATE Proyecto SET NombreProyecto = '" + proy.NombreProyecto + "', DescripcionPro ='" + proy.Descripcion +
                "', RutCliente = (select RutCliente from Cliente where NombreCliente = '" + nombreCliente + "')," +
                " FechaInicio = convert(date, '" + proy.FechaInicio + "'), FechaFin = convert(date, '" + proy.FechaFin + "') WHERE IdProyecto = '" + proy.IdProyecto + "';";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }
    }
}
