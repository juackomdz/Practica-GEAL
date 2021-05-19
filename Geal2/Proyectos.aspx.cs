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
    public partial class Proyectos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                {
                    SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
                    using (SqlCommand cmd2 = new SqlCommand("SELECT NombreCliente FROM Cliente"))
                    {
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Connection = con;
                        con.Open();
                        ddl_cli.DataSource = cmd2.ExecuteReader();
                        ddl_cli.DataTextField = "NombreCliente";
                        ddl_cli.DataBind();
                        ddl_cli.Items.Insert(0, new ListItem("Seleccionar Cliente", "0"));
                        con.Close();
                    }

                    using (SqlCommand cmd1 = new SqlCommand("SELECT NombreProyecto FROM Proyecto"))
                    {
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Connection = con;
                        con.Open();
                        ddl_nombre.DataSource = cmd1.ExecuteReader();
                        ddl_nombre.DataTextField = "NombreProyecto";
                        ddl_nombre.DataBind();
                        ddl_nombre.Items.Insert(0, new ListItem("Seleccionar Proyecto", "0"));
                        con.Close();
                    }
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

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text.Trim().Length > 0)
            {
                MantenedorProyectos ManPro = new MantenedorProyectos();
                if (ManPro.BuscarProyecto(txt_nombre.Text).Rows.Count > 0)
                {
                    try
                    {
                        Proyecto pro = new Proyecto();
                        pro.IdProyecto = int.Parse(txt_id.Text);

                        ManPro.EliminarProyecto(pro);
                        Response.Write("<script>alert('Eliminado exitosamente.');</script>");
                        ddl_nombre.SelectedIndex = 0;
                        txt_nombre.Text = "";
                        txt_desc.Text = "";
                        txt_fechaI.Text = "";
                        txt_fechaF.Text = "";
                        ddl_cli.Text = "";
                        txt_id.Text = "";
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('No se puede eliminar este proyecto porque no existe.');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Debe ingresar el nombre del proyecto a eliminar.');</script>");
            }
        }


        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            MantenedorProyectos mantenedorProyectos = new MantenedorProyectos();
            if (txt_nombre.Text.Trim().Length > 0 && txt_desc.Text.Trim().Length > 0 && txt_fechaI.Text.Trim().Length > 0 && txt_fechaF.Text.Trim().Length > 0 && ddl_cli.SelectedIndex != 0)
            {
                if (txt_desc.Text.Length <=600)
                {
                    if (mantenedorProyectos.BuscarProyecto(txt_nombre.Text).Rows.Count > 0)
                    {
                        Response.Write("<script>alert('Este proyecto ya existe');</script>");
                    }
                    else
                    {
                        var fechainicio = Convert.ToDateTime(txt_fechaI.Text);
                        var fechafin = Convert.ToDateTime(txt_fechaF.Text);
                        if (fechainicio > fechafin)
                        {
                            Response.Write("<script>alert('La fecha de inicio no puede ser despues de la fecha de fin');</script>");
                        }
                        else
                        {
                            try
                            {
                                Proyecto pro = new Proyecto();
                                pro.NombreProyecto = txt_nombre.Text;
                                pro.Descripcion = txt_desc.Text;
                                pro.FechaInicio = txt_fechaI.Text;
                                pro.FechaFin = txt_fechaF.Text;

                                string rut = ddl_cli.SelectedValue;

                                mantenedorProyectos.AgregarProyecto(pro, rut);

                                Response.Write("<script>alert('Agregado exitosamente');</script>");
                                ddl_nombre.SelectedIndex = 0;
                                txt_nombre.Text = "";
                                txt_desc.Text = "";
                                txt_fechaI.Text = "";
                                txt_fechaF.Text = "";
                                ddl_cli.Text = "";
                                txt_id.Text = "";
                            }
                            catch (Exception ex)
                            {
                                Response.Write("<script>alert('" + ex.Message + "');</script>");
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('La descripción no puede superar los 600 caracteres.');</script>");
                }
                
            }
            else
            {
                Response.Write("<script>alert('Debe rellenar todos los campos');</script>");
            }
        }


        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            if (ddl_nombre.SelectedIndex != 0)
            {
                try
                {
                    Proyecto pro = new Proyecto();
                    MantenedorProyectos man = new MantenedorProyectos();

                    string nombre = ddl_nombre.SelectedValue;
                    txt_nombre.Text = man.BuscarProyecto(nombre).Rows[0][5].ToString();
                    txt_desc.Text = man.BuscarProyecto(nombre).Rows[0][1].ToString();

                    ddl_cli.Text = man.BuscarProyecto(nombre).Rows[0][2].ToString();

                    var fechaI = Convert.ToDateTime(man.BuscarProyecto(nombre).Rows[0][3]);
                    var fechaF = Convert.ToDateTime(man.BuscarProyecto(nombre).Rows[0][4]);
                    txt_fechaI.Text = fechaI.ToString("yyyy-MM-dd");
                    txt_fechaF.Text = fechaF.ToString("yyyy-MM-dd");

                    txt_id.Text = man.BuscarProyecto(nombre).Rows[0][0].ToString();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Este proyecto no existe.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Debe ingresar el nombre del proyecto.');</script>");
            }
        }



        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            MantenedorProyectos manPro = new MantenedorProyectos();
            if (txt_nombre.Text.Trim().Length > 0 && txt_desc.Text.Trim().Length > 0 && txt_fechaI.Text.Trim().Length > 0 && txt_fechaF.Text.Trim().Length > 0 && ddl_cli.SelectedIndex != 0)
            {
                if (manPro.BuscarIdProyecto(int.Parse(txt_id.Text)).Rows.Count > 0)
                {
                    var fechainicio = Convert.ToDateTime(txt_fechaI.Text);
                    var fechafin = Convert.ToDateTime(txt_fechaF.Text);
                    if (fechainicio > fechafin)
                    {
                        Response.Write("<script>alert('La fecha fin no puede ser antes que la fecha de inicio.');</script>");
                    }
                    else
                    {
                        try
                        {
                            Proyecto pro = new Proyecto();

                            pro.NombreProyecto = txt_nombre.Text;
                            pro.Descripcion = txt_desc.Text;
                            pro.IdProyecto = int.Parse(txt_id.Text);
                            string nombreCli = ddl_cli.SelectedValue;
                            pro.FechaInicio = txt_fechaI.Text;
                            pro.FechaFin = txt_fechaF.Text;
                            manPro.ModificarProyectos(pro, nombreCli);
                            Response.Write("<script>alert('Modificado exitosamente.');</script>");
                            ddl_nombre.SelectedIndex = 0;
                            txt_nombre.Text = "";
                            txt_desc.Text = "";
                            txt_fechaI.Text = "";
                            txt_fechaF.Text = "";
                            ddl_cli.Text = "";
                            txt_id.Text = "";
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('" + ex.Message + "');</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('No puede modificar este proyecto porque no existe.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Debe rellenar todos los campos.');</script>");
            }
        }


    }
}