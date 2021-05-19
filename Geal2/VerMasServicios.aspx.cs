using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca;


namespace Geal2
{
    public partial class VerMasServicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarServicios();
        }

        public void mostrarServicios()
        {
            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select * from servicio s join fotoServicio f on s.idServicio = f.idServicio;";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidor.DataSource = dt;
            repetidor.DataBind();

            sql.Close();
        }
    }
}