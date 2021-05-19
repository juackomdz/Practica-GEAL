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
    public partial class VerMasProyectos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            repetidor1.ItemCommand += new RepeaterCommandEventHandler(repetidor1_ItemCommand);
            mostraProyectos();;
        }
        void repetidor1_ItemCommand(object sourse, RepeaterCommandEventArgs e)
        {
            if(e.CommandName=="btn_ver")
            {
                string idProyecto = ((LinkButton)e.CommandSource).CommandArgument;
                Response.Redirect("GaleriaProyecto.aspx?Id=" + idProyecto);
            }
        }
        
        public void mostraProyectos()
        {

            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
            sql.Open();
            string qry = "select idproyecto,NombreProyecto,DescripcionPro from Proyecto order by idProyecto desc";
            SqlCommand cm = new SqlCommand(qry, sql);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dt.Load(cm.ExecuteReader());

            repetidor1.DataSource = dt;
            repetidor1.DataBind();

            sql.Close();
           
        }

        


    }
}