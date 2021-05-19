using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
   public class MantenedorClientes
    {
        public DataTable BuscarRutCliente(string cli)
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());

            sql.Open();
            string query = "select * from Cliente where RutCliente='" + cli + "'";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, sql);

            da.Fill(dt);
            sql.Close();
            return dt;
        }

        public DataTable BuscarCliente(string cli)
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());

            sql.Open();
            string query = "select * from Cliente where NombreCliente='" + cli + "'";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, sql);

            da.Fill(dt);
            sql.Close();
            return dt;
        }

        public void AgregarCliente(Cliente cliente)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "INSERT INTO Cliente VALUES('" + cliente.RutCliente + "' ,'" + cliente.NombreCliente + "','"+cliente.Contacto1+"','" + cliente.Fono1 + "','" + cliente.Correo1 +
                "','" + cliente.Contacto2 + "','" + cliente.Fono2 + "','" + cliente.Correo2 +"')";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }

        public void EliminarCliente(Cliente cli)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "DELETE FROM Cliente Where RutCliente='" + cli.RutCliente + "';";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }


        public void ModificarCliente(Cliente cli)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();

            string consulta = "UPDATE Cliente SET NombreCliente = '" + cli.NombreCliente + "', Contacto1 = '"+cli.Contacto1+"', Fono1 = '" + cli.Fono1 + "' , Correo1 = '" + cli.Correo1 +
                "', Contacto2 = '" + cli.Contacto2 + "', Fono2 = '" + cli.Fono2 + "' , Correo2 = '" + cli.Correo2 + "' where RutCliente = '" + cli.RutCliente + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
        }


        public DataTable ListaClientes()
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            con.Open();
            string consulta = "SELECT RutCliente as 'Rut de Cliente',NombreCliente as 'Nombre de Cliente', Contacto1 as 'Contacto 1',"+
                "Fono1 as 'Fono 1',Correo1 as 'Email 1',Contacto2 as 'Contacto 2',Fono2 as 'Fono 2',Correo2 as 'Email 2' FROM Cliente; ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(dt);
            con.Close();
            return dt;
        }

    }
}
