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
    public partial class OlvidarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_email.Text.Trim()=="")
                {
                    Response.Write("<script>alert('Debe ingresar su email.');</script>");
                }
                else
                {
                    Usuario usu = new Usuario();
                    usu.Correo = txt_email.Text;
                    bool modificar = false;
                    SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
                    con.Open();
                    string consulta = "Select * FROM Usuario Where Correo ='" + usu.Correo + "';";
                    SqlCommand cmd = new SqlCommand(consulta, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read()) 
                    {
                        
                        dr.Close();
                        MantenedorUsuario man = new MantenedorUsuario();
                        man.GenerarContraseña(usu);
                        modificar = true;
                        
                        string correo = txt_email.Text;

                        txt_clave.Text = man.BuscarUsuario(correo).Rows[0][2].ToString();

                        string clave = txt_clave.Text;
                        if (modificar==true)
                        {
                            MantenedorCorreo mante = new MantenedorCorreo();
                            

                            mante.Enviar("kevinsein76@gmail.com", "Cambio de contraseña", ("Se ha moidificado tu contraseña. Tu contraseña momentane es: '"+clave+"' <br/> Al iniciar sesión NO OLVIDES CAMBIARLA."));

                            
                            Response.Write("<script>alert('Te hemos enviado un correo con tu nueva contraseña.');</script>");

                            txt_clave.Text = "";
                            txt_email.Text = "";
                            
                        }
                        else
                        {
                            Response.Write("<script>alert('La contraseña no se modificó.');</script>");
                        }

                        
                    }
                    else
                    {
                        dr.Close();
                        Response.Write("<script>alert('El correo no coincide.');</script>");
                    }
                }
                
            }
            catch
            {

            }
        }
    }
}