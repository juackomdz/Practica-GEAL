using Biblioteca;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Geal2
{
    public partial class InicioUsuarioActualizado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            datos();
            mostrarFoto1();
            mostrarFoto2();
            mostrarFoto3();
            mostrarFoto4();
            mostrarFoto5();
            mostrarFoto6();
            mostrarFotoServ1();
            mostrarFotoServ2();
            mostrarFotoServ3();
            mostrarFotoServ4();
            mostrarFotoServ5();
            mostrarFotoPro1();
            mostrarFotoPro2();
            mostrarFotoPro3();
        }

        public void datos()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from Empresa;";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataSet ds = new DataSet();
            da.Fill(ds);

            repetidor.DataSource = ds;
            repetidor.DataBind();
            sql.Close();
        }

        public void mostrarFoto1()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select IdFotoEmp, Imagen, Descripcion, ROW_NUMBER() over(order by idFotoEmp desc)rownum from FotoEmpresa where RutEmpresa = '65786433-2')f where f.rownum = 1;";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorfoto1.DataSource = dt;
            repetidorfoto1.DataBind();

            sql.Close();

            
        }

        public void mostrarFoto2()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select IdFotoEmp, Imagen, Descripcion, ROW_NUMBER() over(order by idFotoEmp desc)rownum from FotoEmpresa where RutEmpresa = '65786433-2')f where f.rownum = 2;";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorfoto2.DataSource = dt;
            repetidorfoto2.DataBind();

            sql.Close();
        }

        public void mostrarFoto3()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select IdFotoEmp, Imagen, Descripcion, ROW_NUMBER() over(order by idFotoEmp desc)rownum from FotoEmpresa where RutEmpresa = '65786433-2')f where f.rownum = 3;";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorfoto3.DataSource = dt;
            repetidorfoto3.DataBind();

            sql.Close();
        }

        public void mostrarFoto4()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select IdFotoEmp, Imagen, Descripcion, ROW_NUMBER() over(order by idFotoEmp desc)rownum from FotoEmpresa where RutEmpresa = '65786433-2')f where f.rownum = 4;";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorfoto4.DataSource = dt;
            repetidorfoto4.DataBind();

            sql.Close();
        }

        public void mostrarFoto5()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select IdFotoEmp, Imagen, Descripcion, ROW_NUMBER() over(order by idFotoEmp desc)rownum from FotoEmpresa where RutEmpresa = '65786433-2')f where f.rownum = 5;";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorfoto5.DataSource = dt;
            repetidorfoto5.DataBind();

            sql.Close();
        }

        public void mostrarFoto6()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select IdFotoEmp, Imagen, Descripcion, ROW_NUMBER() over(order by idFotoEmp desc)rownum from FotoEmpresa where RutEmpresa = '65786433-2')f where f.rownum = 6;";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorfoto6.DataSource = dt;
            repetidorfoto6.DataBind();

            sql.Close();
        }

        public void mostrarFotoServ1()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select NombreImagen, Imagen, IdServicio, ROW_NUMBER() over(order by IdFotoserv desc)rownum from FotoServicio)f join Servicio s on f.IdServicio = s.IdServicio where f.rownum = 1; ";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorServicio1.DataSource = dt;
            repetidorServicio1.DataBind();

            sql.Close();
        }

        public void mostrarFotoServ2()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select NombreImagen, Imagen, IdServicio, ROW_NUMBER() over(order by IdFotoserv desc)rownum from FotoServicio)f join Servicio s on f.IdServicio = s.IdServicio where f.rownum = 2; ";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorServicio2.DataSource = dt;
            repetidorServicio2.DataBind();

            sql.Close();
        }
        public void mostrarFotoServ3()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select NombreImagen, Imagen, IdServicio, ROW_NUMBER() over(order by IdFotoserv desc)rownum from FotoServicio)f join Servicio s on f.IdServicio = s.IdServicio where f.rownum = 3; ";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorServicio3.DataSource = dt;
            repetidorServicio3.DataBind();

            sql.Close();
        }
        public void mostrarFotoServ4()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select NombreImagen, Imagen, IdServicio, ROW_NUMBER() over(order by IdFotoserv desc)rownum from FotoServicio)f join Servicio s on f.IdServicio = s.IdServicio where f.rownum = 4; ";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorServicio4.DataSource = dt;
            repetidorServicio4.DataBind();

            sql.Close();
        }

        public void mostrarFotoServ5()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from(select NombreImagen, Imagen, IdServicio, ROW_NUMBER() over(order by IdFotoserv desc)rownum from FotoServicio)f join Servicio s on f.IdServicio = s.IdServicio where f.rownum = 5; ";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidorServicio5.DataSource = dt;
            repetidorServicio5.DataBind();

            sql.Close();
        }
        public void mostrarFotoPro1()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from (select idproyecto,ROW_NUMBER() over(order by idproyecto desc)rownum from Proyecto)p where p.rownum=1";
            SqlCommand cm = new SqlCommand(qry, sql);
            int lastId = Convert.ToInt32(cm.ExecuteScalar());
            
            string qry2 = "select * from (select idfotopro,ROW_NUMBER() over(order by idfotopro desc)rownum from FotoProyecto where IdProyecto='" + lastId + "')p where p.rownum=1";
            SqlCommand cm2 = new SqlCommand(qry2, sql);
            int laId = Convert.ToInt32(cm2.ExecuteScalar());

            
            string qry3 = "select p.NombreProyecto,p.DescripcionPro,fp.Imagen,fp.IdFotoPro from Proyecto p join FotoProyecto fp on(p.IdProyecto= fp.IdProyecto) where p.IdProyecto='" + lastId + "' and fp.IdFotoPro = '" + laId + "'";
            SqlCommand cm3 = new SqlCommand(qry3, sql);
            SqlDataAdapter da3 = new SqlDataAdapter(cm3);
            DataTable dt3 = new DataTable();
            dt3.Load(cm3.ExecuteReader());

            repetidorPro1.DataSource = dt3;
            repetidorPro1.DataBind();

            sql.Close();
        }

        public void mostrarFotoPro2()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from (select idproyecto,ROW_NUMBER() over(order by idproyecto desc)rownum from Proyecto)p where p.rownum=2";
            SqlCommand cm = new SqlCommand(qry, sql);
            int lastId = Convert.ToInt32(cm.ExecuteScalar());
            
            string qry2 = "select * from (select idfotopro,ROW_NUMBER() over(order by idfotopro desc)rownum from FotoProyecto where IdProyecto='" + lastId + "')p where p.rownum=1";
            SqlCommand cm2 = new SqlCommand(qry2, sql);
            int laId = Convert.ToInt32(cm2.ExecuteScalar());

            
            string qry3 = "select p.NombreProyecto,p.DescripcionPro,fp.Imagen,fp.IdFotoPro from Proyecto p join FotoProyecto fp on(p.IdProyecto= fp.IdProyecto) where p.IdProyecto='" + lastId + "' and fp.IdFotoPro = '" + laId + "'";
            SqlCommand cm3 = new SqlCommand(qry3, sql);
            SqlDataAdapter da3 = new SqlDataAdapter(cm3);
            DataTable dt3 = new DataTable();
            dt3.Load(cm3.ExecuteReader());

            repetidorPro2.DataSource = dt3;
            repetidorPro2.DataBind();

            sql.Close();
        }

        public void mostrarFotoPro3()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from (select idproyecto,ROW_NUMBER() over(order by idproyecto desc)rownum from Proyecto)p where p.rownum=3";
            SqlCommand cm = new SqlCommand(qry, sql);
            int lastId = Convert.ToInt32(cm.ExecuteScalar());
            
            string qry2 = "select * from (select idfotopro,ROW_NUMBER() over(order by idfotopro desc)rownum from FotoProyecto where IdProyecto='" + lastId + "')p where p.rownum=1";
            SqlCommand cm2 = new SqlCommand(qry2, sql);
            int laId = Convert.ToInt32(cm2.ExecuteScalar());

            
            string qry3 = "select p.NombreProyecto,p.DescripcionPro,fp.Imagen,fp.IdFotoPro from Proyecto p join FotoProyecto fp on(p.IdProyecto= fp.IdProyecto) where p.IdProyecto='" + lastId + "' and fp.IdFotoPro = '" + laId + "'";
            SqlCommand cm3 = new SqlCommand(qry3, sql);
            SqlDataAdapter da3 = new SqlDataAdapter(cm3);
            DataTable dt3 = new DataTable();
            dt3.Load(cm3.ExecuteReader());

            repetidorPro3.DataSource = dt3;
            repetidorPro3.DataBind();

            sql.Close();
        }
        protected void btn_enviar_Click(object sender, EventArgs e)
        {
            MantenedorCorreo man = new MantenedorCorreo();
            string nombre = txt_nombre.Text;
            string correo = txt_correo.Text;
            string mensaje = txt_mensaje.Text;

            man.Enviar("kevinsein76@gmail.com", "Consulta", (mensaje + ".<br/> Este mensaje fue enviado por " + nombre + "( " + correo + ".)"));

            Response.Write("<script>alert('Correo Enviado.');</script>");

            txt_nombre.Text="";
            txt_correo.Text = "";
            txt_mensaje.Text = "";
        }
    }
}