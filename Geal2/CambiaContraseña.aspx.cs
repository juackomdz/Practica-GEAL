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
    public partial class CambiaContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sesion"] == null)
            {
                
                SesionUsuario = null;
                HttpResponse.RemoveOutputCacheItem(Request.CurrentExecutionFilePath);
                Response.Redirect("Login.aspx");
            }
        }

        protected void btn_cambiar1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_claveactual.Text.Trim().Length > 0)
                {
                    if (txt_clavenueva.Text.Trim().Length >= 8)
                    {
                        if (txt_claverepetida.Text.Trim().Length >= 8)
                        {
                            Usuario usu = new Usuario();
                            usu.Contraseña = txt_claveactual.Text;

                            string claveNueva = txt_claverepetida.Text;
                            string claveRepetida = txt_clavenueva.Text;
                            SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
                            con.Open();
                            string consulta = "Select * FROM Usuario Where Contrasena='" + usu.Contraseña + "';";

                            SqlCommand cmd1 = new SqlCommand(consulta, con);

                            SqlDataReader dr = cmd1.ExecuteReader();

                            if (dr.Read())
                            {
                                dr.Close();

                                if (claveNueva == claveRepetida)
                                {
                                    string consulta1 = "UPDATE Usuario SET Contrasena='" + claveNueva + "'WHERE Contrasena='" + usu.Contraseña + "'";
                                    SqlCommand cmd2 = new SqlCommand(consulta1, con);
                                    SqlDataReader dr1 = cmd2.ExecuteReader();
                                    dr1.Close();
                                    Response.Write("<script>alert('Modificada exitosamente');</script>");
                                    MantenedorCorreo cr = new MantenedorCorreo();
                                    cr.Enviar("kevinsein76@gmail.com", "Cambio de clave", "Cambio de clave exitoso. <br/> Asegurece de recordar su nueva clave.");
                                    txt_claveactual.Text = "";
                                    txt_clavenueva.Text = "";
                                    txt_claverepetida.Text = "";
                                }
                                else
                                {
                                    Response.Write("<script>alert('Las claves nuevas no coinciden.');</script>");
                                }
                            }
                            else
                            {
                                dr.Close();
                                Response.Write("<script>alert('Clave actual incorrecta.');</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Su clave nueva debe tener al menos 8 caracteres. Asegurese de no poner espacios.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Su clave nueva debe tener al menos 8 caracteres. Asegurese de no poner espacios.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Debe ingresar su clave actual.');</script>");
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
