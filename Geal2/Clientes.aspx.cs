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
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //llenarTipoCliente();
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
                using (SqlCommand cmd = new SqlCommand("SELECT NombreCliente FROM Cliente"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    ddl_nombre.DataSource = cmd.ExecuteReader();
                    ddl_nombre.DataTextField = "NombreCliente";
                    ddl_nombre.DataBind();
                    ddl_nombre.Items.Insert(0, new ListItem("Seleccionar Cliente", "0"));
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



        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            if (ddl_nombre.SelectedIndex != 0)
            {
                try
                {
                    Cliente cli = new Cliente();
                    MantenedorClientes man = new MantenedorClientes();

                    string nombre = ddl_nombre.SelectedValue;
                    txt_rutCliente.Text = man.BuscarCliente(nombre).Rows[0][0].ToString();
                    txt_nombreCliente.Text = man.BuscarCliente(nombre).Rows[0][1].ToString();
                    txt_contacto1.Text = man.BuscarCliente(nombre).Rows[0][2].ToString();
                    txt_fono1.Text = man.BuscarCliente(nombre).Rows[0][3].ToString();
                    txt_email1.Text = man.BuscarCliente(nombre).Rows[0][4].ToString();
                    txt_contacto2.Text = man.BuscarCliente(nombre).Rows[0][5].ToString();
                    txt_fono2.Text = man.BuscarCliente(nombre).Rows[0][6].ToString();
                    txt_email2.Text = man.BuscarCliente(nombre).Rows[0][7].ToString();

                    
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('Este cliente no existe.');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Debe ingresar un rut.');</script>");
            }
        }


        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            MantenedorClientes mantenedor = new MantenedorClientes();
            if (txt_rutCliente.Text.Trim().Length > 0 && txt_nombreCliente.Text.Trim().Length > 0)
            {
                //Valida que el rut se ingrese sin puntos y con el guión
                string rut = txt_rutCliente.Text.Trim();
                rut = rut.Replace(".", "");
                bool guion = rut.Contains("-");
                if(guion== false)
                {
                    rut = rut.Insert(rut.Length - 1, "-");
                }
                
                if (rut.Length < 9 && rut.Length > 11)
                {
                    Response.Write("<script>alert('Rut incorrecto.');</script>");
                }
                else
                {
                    if (mantenedor.BuscarCliente(rut.Trim()).Rows.Count > 0)
                        {
                            Response.Write("<script>alert('Este cliente ya existe.');</script>");
                        }
                        else
                        {
                            if (validarRut(txt_rutCliente.Text.Trim()) == true)
                            {
                                if (txt_fono1.Text.Trim().Length > 0 || txt_fono2.Text.Trim().Length > 0)
                                {
                                    if (txt_fono1.Text.Trim().Length >=8  && txt_fono1.Text.Trim().Length < 12 || txt_fono2.Text.Trim().Length >= 8 && txt_fono2.Text.Trim().Length < 12)
                                    {
                                        try
                                        {
                                            Cliente cliente = new Cliente();
                                            cliente.RutCliente = rut;
                                            cliente.NombreCliente = txt_nombreCliente.Text;
                                            cliente.Contacto1 = txt_contacto1.Text;
                                            cliente.Fono1 = txt_fono1.Text;
                                            cliente.Correo1 = txt_email1.Text;
                                            cliente.Contacto2 = txt_contacto2.Text;
                                            cliente.Fono2 = txt_fono2.Text;
                                            cliente.Correo2 = txt_email2.Text;


                                            mantenedor.AgregarCliente(cliente);
                                            Response.Write("<script>alert('Agregado exitosamente.');</script>");

                                            txt_rutCliente.Text = "";
                                            txt_nombreCliente.Text = "";
                                            txt_contacto1.Text = "";
                                            txt_fono1.Text = "";
                                            txt_email1.Text = "";
                                            txt_contacto2.Text = "";
                                            txt_fono2.Text = "";
                                            txt_email2.Text = "";
                                            ddl_nombre.SelectedIndex = 0;

                                    }
                                        catch (Exception ex)
                                        {
                                            Response.Write("<script>alert('" + ex.Message + "');</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('El fono debe no debe superar los 12 caraceteres.');</script>");
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        Cliente cliente = new Cliente();
                                        cliente.RutCliente = rut;
                                        cliente.NombreCliente = txt_nombreCliente.Text;
                                        cliente.Contacto1 = txt_contacto1.Text;
                                        cliente.Fono1 = txt_fono1.Text;
                                        cliente.Correo1 = txt_email1.Text;
                                        cliente.Contacto2 = txt_contacto2.Text;
                                        cliente.Fono2 = txt_fono2.Text;
                                        cliente.Correo2 = txt_email2.Text;


                                        mantenedor.AgregarCliente(cliente);
                                        Response.Write("<script>alert('Agregado exitosamente.');</script>");

                                        txt_rutCliente.Text = "";
                                        txt_nombreCliente.Text = "";
                                        txt_contacto1.Text = "";
                                        txt_fono1.Text = "";
                                        txt_email1.Text = "";
                                        txt_contacto2.Text = "";
                                        txt_fono2.Text = "";
                                        txt_email2.Text = "";
                                        ddl_nombre.SelectedIndex = 0;

                                }
                                    catch (Exception ex)
                                    {
                                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                                    }
                                }
                                
                                
                            }
                            else
                            {
                                Response.Write("<script>alert('Rut no existente.');</script>");
                            }
                        }
                   
                }
            }
            else
            {
                Response.Write("<script>alert('Debe rellenar los campos necesarios.');</script>");
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            if (txt_rutCliente.Text.Trim().Length > 0)
            {
                MantenedorClientes ManSev = new MantenedorClientes();
                if (ManSev.BuscarCliente(txt_nombreCliente.Text.Trim()).Rows.Count > 0)
                {
                    try
                    {
                        Cliente cli = new Cliente();
                        cli.RutCliente = txt_rutCliente.Text;
                        ManSev.EliminarCliente(cli);
                        Response.Write("<script>alert('Eliminado exitosamente.');</script>");
                        txt_rutCliente.Text = "";
                        txt_nombreCliente.Text = "";
                        txt_contacto1.Text = "";
                        txt_fono1.Text = "";
                        txt_email1.Text = "";
                        txt_contacto2.Text = "";
                        txt_fono2.Text = "";
                        txt_email2.Text = "";
                        ddl_nombre.SelectedIndex = 0;

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('"+ex.Message+"');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('No se puede eliminar el cliente porque no existe.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Ingrese el rut del cliente a eliminar.');</script>");
            }
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            if (txt_rutCliente.Text.Trim().Length > 0 && txt_nombreCliente.Text.Trim().Length > 0)
            {
                MantenedorClientes man = new MantenedorClientes();
                if (man.BuscarRutCliente(txt_rutCliente.Text.Trim()).Rows.Count > 0)
                {
                    try
                    {
                        if(man.BuscarRutCliente(txt_rutCliente.Text.Trim()).Rows[0][0].ToString() == txt_rutCliente.Text)
                        {
                            Cliente cl = new Cliente();

                            cl.RutCliente = txt_rutCliente.Text;
                            cl.NombreCliente = txt_nombreCliente.Text;
                            cl.Contacto1 = txt_contacto1.Text;
                            cl.Fono1 = txt_fono1.Text;
                            cl.Correo1 = txt_email1.Text;
                            cl.Contacto2 = txt_contacto2.Text;
                            cl.Fono2 = txt_fono2.Text;
                            cl.Correo2 = txt_email2.Text;
                            man.ModificarCliente(cl);
                            Response.Write("<script>alert('Modificado exitosamente.');</script>");

                            
                        }
                        else
                        {
                            Response.Write("<script>alert('No puede modificar el Rut del cliente.');</script>");
                            txt_rutCliente.Text = "";
                            txt_nombreCliente.Text = "";
                            txt_contacto1.Text = "";
                            txt_email1.Text = "";
                            txt_fono1.Text = "";
                            txt_contacto2.Text = "";
                            txt_email2.Text = "";
                            txt_fono2.Text = "";
                            ddl_nombre.SelectedIndex = 0;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('No puede modificar el Rut del cliente.');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Debe rellenar los campos necesarios.');</script>");
            }
        }

        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }
    }
    
}