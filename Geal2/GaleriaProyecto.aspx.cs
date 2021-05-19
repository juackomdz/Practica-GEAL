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
    public partial class GaleriaProyecto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(Request.QueryString["Id"] != null)
            {
                int Id = int.Parse(Request.QueryString["Id"]);
                Label1.Text = Id.ToString();
            }
            mostrarProyecto();
            mostrarFotos();
        }
        public void mostrarProyecto()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            int idPro = int.Parse(Label1.Text);
            string qry = "select NombreProyecto,DescripcionPro from Proyecto where idProyecto ='"+idPro+"'";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidor.DataSource = dt;
            repetidor.DataBind();

            sql.Close();

        }

        public void mostrarFotos()
        {
            
            SqlConnection sql2 = new SqlConnection(Conexion.CadenaDeConexion());
            sql2.Open();
            int idPro = int.Parse(Label1.Text);
            string qry2 = "select * from FotoProyecto where IdProyecto='" +idPro + "'";
            SqlCommand cm2 = new SqlCommand(qry2, sql2);
            SqlDataAdapter da = new SqlDataAdapter(cm2);
            DataTable dt = new DataTable();
            dt.Load(cm2.ExecuteReader());

            repetidor1.DataSource = dt;
            repetidor1.DataBind();

            
            sql2.Close();

        }
}
}