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
    public partial class Servicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
                using (SqlCommand cmd = new SqlCommand("SELECT NombreServicio FROM Servicio"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddl_nombre.DataSource = cmd.ExecuteReader();
                    ddl_nombre.DataTextField = "NombreServicio";
                    ddl_nombre.DataBind();
                    ddl_nombre.Items.Insert(0, new ListItem("Seleccionar Servicio", "0"));
                    con.Close();
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

        protected void boton_agregar_Click(object sender, EventArgs e)
        {
            MantenedorServicios man = new MantenedorServicios();
            if (txt_nombre.Text.Trim().Length > 0 && txt_desc.Text.Trim().Length > 0)
            {
                if(txt_desc.Text.Length<=500)
                {
                    if (man.BuscarServicio(txt_nombre.Text).Rows.Count > 0)
                    {
                        Response.Write("<script>alert('Este servicio ya existe.');</script>");
                    }
                    else
                    {
                        try
                        {
                            Servicio servicio = new Servicio();

                            servicio.NombreServicio = txt_nombre.Text;
                            servicio.DescripcionServicio = txt_desc.Text;

                            man.RegistrarServicio(servicio);
                            Response.Write("<script>alert('Agregado exitosamente.');</script>");
                            ddl_nombre.SelectedIndex = 0;
                            txt_nombre.Text = "";
                            txt_desc.Text = "";
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('" + ex.Message + "');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('La descripcion no debe superar los 500 caracteres.');</script>");
                }
                
            }
            else
            {
                Response.Write("<script>alert('Debe rellenar todos los campos.');</script>");
            }
        }

        protected void boton_buscar_Click(object sender, EventArgs e)
        {
            if (ddl_nombre.SelectedIndex != 0 )
            {
                try
                {
                    Servicio ser = new Servicio();
                    MantenedorServicios man = new MantenedorServicios();

                    string nombre = ddl_nombre.Text;
                    txt_nombre.Text = man.BuscarServicio(nombre).Rows[0][1].ToString();
                    txt_desc.Text = man.BuscarServicio(nombre).Rows[0][2].ToString();
                    txt_idServicio.Text = man.BuscarServicio(nombre).Rows[0][0].ToString();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('"+ex.Message+"');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Debe ingresar el nombre del servicio a buscar.');</script>");
            }
        }

        protected void boton_eliminar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text.Trim().Length > 0)
            {
                MantenedorServicios ManSev = new MantenedorServicios();
                if (ManSev.BuscarServicio(txt_nombre.Text).Rows.Count > 0)
                {
                    try
                    {
                        Servicio sev = new Servicio();
                        sev.NombreServicio = txt_nombre.Text;

                        ManSev.EliminarServicio(sev);
                        Response.Write("<script>alert('Eliminado exitosamente.');</script>");
                        ddl_nombre.SelectedIndex = 0;
                        txt_nombre.Text = "";
                        txt_desc.Text = "";
                        txt_idServicio.Text = "";
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Este servicio no existe.');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Debe ingesar el nombre del servicio a eliminar.');</script>");
            }
        }

        protected void boton_modificar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text.Trim().Length > 0 && txt_desc.Text.Trim().Length > 0)
            {
                if(txt_desc.Text.Length<=500)
                {
                    MantenedorServicios man = new MantenedorServicios();
                    if (man.BuscarServicio(txt_nombre.Text).Rows.Count > 0)
                    {
                        try
                        {
                            Servicio servicio = new Servicio();
                            servicio.IdServicio = int.Parse(txt_idServicio.Text);
                            servicio.NombreServicio = txt_nombre.Text;
                            servicio.DescripcionServicio = txt_desc.Text;

                            man.ModificarServicio(servicio);
                            Response.Write("<script>alert('Modificado exitosamente.');</script>");
                            ddl_nombre.SelectedIndex = 0;
                            txt_nombre.Text = "";
                            txt_desc.Text = "";
                            txt_idServicio.Text = "";
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('" + ex.Message + "');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('No se puede modificar este servicio porque no existe');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('La descripcion no debe superar los 500 caracteres.');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Debe rellenar todos los campos.');</script>");
            }
        }


    }
}