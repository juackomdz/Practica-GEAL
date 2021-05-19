using Biblioteca;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Geal2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
            try
            {
                string correo = txt_email.Text;
                string contrasena = txt_contrasena.Text;

                con.Open();
                string consulta = "SELECT * FROM Usuario WHERE CORREO = '" + correo + "' AND CONTRASENA = '" + contrasena + "'";

                SqlCommand cmd = new SqlCommand(consulta, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    SesionUsuario.Correo = txt_email.Text;
                    Response.Redirect("InicioAdmin.aspx");
                }
                else
                {
                    dr.Close();
                    txt_mensaje.Visible = true;
                    txt_mensaje.Text = "Email o contraseña incorrectos.";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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