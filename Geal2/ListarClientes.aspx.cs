using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Geal2
{
    public partial class ListarClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                MantenedorClientes mantenedorCli = new MantenedorClientes();
                gvListaClientes.DataSource = mantenedorCli.ListaClientes();
                gvListaClientes.DataBind();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('No se pueden mostrar los datos.');</script>");
            }

            if (Session["sesion"] == null)
            {
                HttpResponse.RemoveOutputCacheItem(Request.CurrentExecutionFilePath);
                Response.Redirect("Login.aspx");
            }
        }

        public Usuario SesionUsuario
        {
            get
            {
                if (Session["sesion"] == null)
                {
                    Session["sesion"] = new Usuario();
                }
                return (Usuario)Session["sesion"];
            }
            set
            {
                Session["sesion"] = value;
            }
        }
    }
}