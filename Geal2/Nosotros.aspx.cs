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
    public partial class Nosotros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                {
                    Empresa emp = new Empresa();
                    MantenedorEmpresa man = new MantenedorEmpresa();

                    string nombre= txt_nombre.Text;

                    txt_descripcion.Text = man.BuscarEmpresa(nombre).Rows[0][2].ToString();

                    
                }
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

        protected void boton_nosotros_Click(object sender, EventArgs e)
        {
            if (txt_descripcion.Text.Length > 0)
            {
                if(txt_descripcion.Text.Length <=1000)
                {
                    try
                    {
                        Empresa empresa = new Empresa();
                        empresa.NombreEmpresa = txt_nombre.Text;
                        empresa.DescripcionEmpresa = txt_descripcion.Text;

                        MantenedorEmpresa man = new MantenedorEmpresa();
                        man.ModificarEmpresa(empresa);
                        Response.Write("<script>alert('Datos Guardados.');</script>");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('La descripcion no debe superar los 1000 caracteres.');</script>");
                }
                
            }
            else
            {
                Response.Write("<script>alert('Debe escribir una descripcion.');</script>");
            }
        }
    }
}