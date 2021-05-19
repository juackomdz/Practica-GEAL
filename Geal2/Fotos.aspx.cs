using Biblioteca;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Geal2
{
    public partial class Fotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                {

                    
                    ddl_seleccionar.Items.Insert(0, new ListItem("Asociar a", "0"));
                    ddl_seleccionar.Items.Insert(1, new ListItem("Proyecto", "1"));
                    ddl_seleccionar.Items.Insert(2, new ListItem("Servicio", "2"));
                    ddl_seleccionar.Items.Insert(3, new ListItem("Empresa", "3"));

                    SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
                    using (SqlCommand cmd = new SqlCommand("SELECT NombreProyecto FROM Proyecto"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        ddl_pro.DataSource = cmd.ExecuteReader();
                        ddl_pro.DataTextField = "NombreProyecto";
                        ddl_pro.DataBind();
                        ddl_pro.Items.Insert(0, new ListItem("Seleccionar Proyecto", "0"));
                        con.Close();
                    }

                    using (SqlCommand cmd1 = new SqlCommand("SELECT NombreServicio FROM Servicio"))
                    {
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Connection = con;
                        con.Open();
                        ddl_ser.DataSource = cmd1.ExecuteReader();
                        ddl_ser.DataTextField = "NombreServicio";
                        ddl_ser.DataBind();
                        ddl_ser.Items.Insert(0, new ListItem("Seleccionar Servicio", "0"));
                        con.Close();
                    }
                    using (SqlCommand cmd2 = new SqlCommand("SELECT Nombre FROM Empresa"))
                    {
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Connection = con;
                        con.Open();
                        ddl_emp.DataSource = cmd2.ExecuteReader();
                        ddl_emp.DataTextField = "Nombre";
                        ddl_emp.DataBind();
                        ddl_emp.Items.Insert(0, new ListItem("Seleccionar Empresa", "0"));
                        con.Close();
                    }

                    using (SqlCommand cmd3 = new SqlCommand("SELECT NombreImagen FROM FotoProyecto"))
                    {
                        cmd3.CommandType = CommandType.Text;
                        cmd3.Connection = con;
                        con.Open();
                        ddl_nombrePro.DataSource = cmd3.ExecuteReader();
                        ddl_nombrePro.DataTextField = "NombreImagen";
                        ddl_nombrePro.DataBind();
                        ddl_nombrePro.Items.Insert(0, new ListItem("Seleccionar Nombre Imagen", "0"));
                        con.Close();
                    }
                    using (SqlCommand cmd4 = new SqlCommand("SELECT NombreImagen FROM FotoServicio"))
                    {
                        cmd4.CommandType = CommandType.Text;
                        cmd4.Connection = con;
                        con.Open();
                        ddl_nombreServ.DataSource = cmd4.ExecuteReader();
                        ddl_nombreServ.DataTextField = "NombreImagen";
                        ddl_nombreServ.DataBind();
                        ddl_nombreServ.Items.Insert(0, new ListItem("Seleccionar Nombre Imagen", "0"));
                        con.Close();
                    }
                    using (SqlCommand cmd5 = new SqlCommand("SELECT NombreImagen FROM FotoEmpresa"))
                    {
                        cmd5.CommandType = CommandType.Text;
                        cmd5.Connection = con;
                        con.Open();
                        ddl_nombreEmp.DataSource = cmd5.ExecuteReader();
                        ddl_nombreEmp.DataTextField = "NombreImagen";
                        ddl_nombreEmp.DataBind();
                        ddl_nombreEmp.Items.Insert(0, new ListItem("Seleccionar Nombre Imagen", "0"));
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

        protected void boton_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_seleccionar.SelectedIndex == 1)
                {
                    if (txt_nombreimagen.Text.Trim().Length > 0)
                    {
                        MantenedorFotosProyectos ManCont = new MantenedorFotosProyectos();
                        if (ManCont.BuscarFoto(txt_nombreimagen.Text).Rows.Count > 0)
                        {
                            FotoProyecto foto = new FotoProyecto();
                            foto.NombreImagen = txt_nombreimagen.Text;

                            ManCont.EliminarFoto(foto);
                            Response.Write("<script>alert('Eliminada correctamente.');</script>");
                            ddl_nombrePro.SelectedIndex = 0;
                            txt_nombreimagen.Text = "";
                            txt_descripcion.Text = "";
                            ddl_pro.SelectedIndex = 0;
                            imgPreview.ImageUrl = "https://pngimage.net/wp-content/uploads/2018/05/agregar-png.png";
                        }
                        else
                        {
                            Response.Write("<script>alert('La imagen no existe.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Debe ingresar el nombre de la imagen a eliminar.');</script>");
                    }

                }
                else if (ddl_seleccionar.SelectedIndex == 2)
                {
                    if (txt_nombreimagen.Text.Trim().Length > 0)
                    {
                        MantenedorFotosServicios ManCont = new MantenedorFotosServicios();
                        if (ManCont.BuscarFotoServicio(txt_nombreimagen.Text).Rows.Count > 0)
                        {
                            FotoServicio foto = new FotoServicio();
                            foto.NombreImagen = txt_nombreimagen.Text;

                            ManCont.EliminarFotoServicio(foto);
                            Response.Write("<script>alert('Eliminada correctamente.');</script>");
                            ddl_nombreServ.SelectedIndex = 0;
                            txt_nombreimagen.Text = "";
                            txt_descripcion.Text = "";
                            ddl_pro.SelectedIndex = 0;
                            imgPreview.ImageUrl = "https://pngimage.net/wp-content/uploads/2018/05/agregar-png.png";
                        }
                        else
                        {
                            Response.Write("<script>alert('La imagen no existe.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Debe ingresar el nombre de la imagen a eliminar.');</script>");
                    }
                }
                else if (ddl_seleccionar.SelectedIndex == 3)
                {
                    if (txt_nombreimagen.Text.Trim().Length > 0)
                    {
                        MantenedorFotosEmpresa ManCont = new MantenedorFotosEmpresa();
                        if (ManCont.BuscarFotoEmpresa(txt_nombreimagen.Text).Rows.Count > 0)
                        {
                            FotoEmpresa foto = new FotoEmpresa();
                            foto.NombreImagen = txt_nombreimagen.Text;
                            ManCont.EliminarFotoEmpresa(foto);
                            Response.Write("<script>alert('Eliminada correctamente.');</script>");
                            ddl_nombreEmp.SelectedIndex = 0;
                            txt_nombreimagen.Text = "";
                            txt_descripcion.Text = "";
                            ddl_pro.SelectedIndex = 0;
                            imgPreview.ImageUrl = "https://pngimage.net/wp-content/uploads/2018/05/agregar-png.png";
                        }
                        else
                        {
                            Response.Write("<script>alert('La imagen no existe.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Debe ingresar el nombre de la imagen a eliminar.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Debe asociar la imagen a un Proyecto, Servicio o Empresa.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void boton_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_seleccionar.SelectedIndex == 1)
                {
                    if (txt_nombreimagen.Text.Trim() == "")
                    {
                        Response.Write("<script>alert('Ingrese el nombre de imagen.');</script>");
                    }
                    else
                    {
                        if (txt_descripcion.Text.Trim() == "" && txt_descripcion.Text.Length > 500)
                        {
                            Response.Write("<script>alert('Ingrese una descripción no mayor a 500 caracteres.');</script>");
                        }
                        else
                        {
                            if (ddl_pro.SelectedIndex == 0)
                            {
                                Response.Write("<script>alert('Debe seleccionar el proyecto a asociar.');</script>");
                            }
                            else
                            {
                                if (archivofoto.PostedFile.ContentLength == 0)
                                {
                                    Response.Write("<script>alert('Ingrese un archivo de imagen.');</script>");
                                }
                                else
                                {
                                    FotoProyecto foto = new FotoProyecto();
                                    foto.NombreImagen = txt_nombreimagen.Text;
                                    foto.Descripcion = txt_descripcion.Text;
                                    string idProy = ddl_pro.SelectedValue;

                                    //obtener datos de la imagen
                                    int tamanio = archivofoto.PostedFile.ContentLength;
                                    byte[] ImagenOriginal = new byte[tamanio];
                                    archivofoto.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
                                    Bitmap ImagenOriginalBinaria = new Bitmap(archivofoto.PostedFile.InputStream);

                                    SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
                                    con.Open();
                                    string consulta1 = "SELECT * FROM FotoProyecto Where NombreImagen='" + foto.NombreImagen + "';";
                                    SqlCommand cmd1 = new SqlCommand(consulta1, con);
                                    SqlDataReader dr = cmd1.ExecuteReader();

                                    if (dr.Read())
                                    {
                                        dr.Close();
                                        Response.Write("<script>alert('Imagen ya existente.');</script>");
                                    }
                                    else
                                    {
                                        dr.Close();
                                        SqlConnection cone = new SqlConnection(Conexion.CadenaDeConexion());
                                        SqlCommand cmd = new SqlCommand();

                                        cmd.CommandText = "INSERT INTO FotoProyecto(IdProyecto,Imagen,NombreImagen,Descripcion)" +
                                            "VALUES ((SELECT IdProyecto from Proyecto where NombreProyecto=@idProy)," +
                                            "@imagen,@nombreImg,@descripcion)";
                                        cmd.Parameters.Add("@idProy", SqlDbType.NVarChar).Value = idProy;
                                        cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = ImagenOriginal;
                                        cmd.Parameters.Add("@nombreImg", SqlDbType.NVarChar).Value = txt_nombreimagen.Text;
                                        cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = txt_descripcion.Text;
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Connection = cone;
                                        cone.Open();
                                        cmd.ExecuteNonQuery();
                                        Response.Write("<script>alert('Agregada exitosamente.');</script>");
                                        string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
                                        imgPreview.ImageUrl = ImagenDataURL64;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (ddl_seleccionar.SelectedIndex == 2)
                {
                    if (txt_nombreimagen.Text.Trim() == "")
                    {
                        Response.Write("<script>alert('Ingrese un nombre de imagen.');</script>");
                    }
                    else
                    {
                        if (txt_descripcion.Text.Trim() == "" && txt_descripcion.Text.Length > 500)
                        {
                            Response.Write("<script>alert('Ingrese una descripción no mayor a 500 caracteres.');</script>");
                        }
                        else
                        {
                            if (ddl_ser.SelectedIndex == 0)
                            {
                                Response.Write("<script>alert('Debe seleccionar el servicio a asociar.');</script>");
                            }
                            else
                            {
                                if (archivofoto.PostedFile.ContentLength == 0)
                                {
                                    Response.Write("<script>alert('Ingrese un archivo de imagen.');</script>");
                                }
                                else
                                {
                                    FotoServicio foto = new FotoServicio();
                                    foto.NombreImagen = txt_nombreimagen.Text;
                                    foto.Descripcion = txt_descripcion.Text;
                                    string idServ = ddl_ser.SelectedValue;

                                    //obtener datos de la imagen
                                    int tamanio = archivofoto.PostedFile.ContentLength;
                                    byte[] ImagenOriginal = new byte[tamanio];
                                    archivofoto.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
                                    Bitmap ImagenOriginalBinaria = new Bitmap(archivofoto.PostedFile.InputStream);


                                    SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
                                    con.Open();
                                    string consulta1 = "SELECT * FROM FotoServicio Where NombreImagen='" + foto.NombreImagen + "';";
                                    SqlCommand cmd1 = new SqlCommand(consulta1, con);
                                    SqlDataReader dr = cmd1.ExecuteReader();

                                    if (dr.Read())
                                    {
                                        dr.Close();
                                        Response.Write("<script>alert('Imagen ya existente.');</script>");
                                    }
                                    else
                                    {
                                        dr.Close();
                                        SqlConnection cone = new SqlConnection(Conexion.CadenaDeConexion());
                                        cone.Open();
                                        string consulta3 = "Select * from Servicio s join FotoServicio f on s.IdServicio=f.IdServicio WHERE s.NombreServicio = '" + idServ + "';";
                                        SqlCommand cmd3 = new SqlCommand(consulta3, con);
                                        SqlDataReader dr3 = cmd3.ExecuteReader();
                                        if (dr3.Read())
                                        {
                                            dr3.Close();
                                            Response.Write("<script>alert('Ya existe una imagen para ese servicio.');</script>");
                                        }
                                        else
                                        {
                                            dr3.Close();
                                            SqlConnection conex = new SqlConnection(Conexion.CadenaDeConexion());
                                            SqlCommand cmd = new SqlCommand();

                                            cmd.CommandText = "INSERT INTO FotoServicio(IdServicio,Imagen,NombreImagen,Descripcion)" +
                                            "VALUES ((SELECT IdServicio from Servicio where NombreServicio=@idServ)," +
                                            "@imagen,@nombreImg,@descripcion)";
                                            cmd.Parameters.Add("@idServ", SqlDbType.NVarChar).Value = idServ;
                                            cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = ImagenOriginal;
                                            cmd.Parameters.Add("@nombreImg", SqlDbType.NVarChar).Value = txt_nombreimagen.Text;
                                            cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = txt_descripcion.Text;
                                            cmd.CommandType = CommandType.Text;
                                            cmd.Connection = conex;
                                            conex.Open();
                                            cmd.ExecuteNonQuery();
                                            Response.Write("<script>alert('Agregada exitosamente.');</script>");
                                            string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
                                            imgPreview.ImageUrl = ImagenDataURL64;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (ddl_seleccionar.SelectedIndex == 3)
                {
                    if (txt_nombreimagen.Text.Trim() == "")
                    {
                        Response.Write("<script>alert('Ingrese un nombre de imagen.');</script>");
                    }
                    else
                    {
                        if (txt_descripcion.Text.Trim() == "" && txt_descripcion.Text.Length > 500)
                        {
                            Response.Write("<script>alert('Ingrese una descripción no mayor a 500 caracteres.');</script>");
                        }
                        else
                        {
                            if (ddl_emp.SelectedIndex == 0)
                            {
                                Response.Write("<script>alert('Debe seleccionar la empresa para asociar la imagen.');</script>");
                            }
                            else
                            {
                                if (archivofoto.PostedFile.ContentLength == 0)
                                {
                                    Response.Write("<script>alert('Ingrese un archivo de imagen.');</script>");
                                }
                                else
                                {
                                    FotoEmpresa foto = new FotoEmpresa();
                                    foto.NombreImagen = txt_nombreimagen.Text;
                                    foto.Descripcion = txt_descripcion.Text;
                                    string idEmp = ddl_emp.SelectedValue;

                                    //obtener datos de la imagen
                                    int tamanio = archivofoto.PostedFile.ContentLength;
                                    byte[] ImagenOriginal = new byte[tamanio];
                                    archivofoto.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
                                    Bitmap ImagenOriginalBinaria = new Bitmap(archivofoto.PostedFile.InputStream);


                                    SqlConnection con = new SqlConnection(Conexion.CadenaDeConexion());
                                    con.Open();
                                    string consulta1 = "SELECT * FROM FotoEmpresa Where NombreImagen='" + foto.NombreImagen + "';";
                                    SqlCommand cmd1 = new SqlCommand(consulta1, con);
                                    SqlDataReader dr = cmd1.ExecuteReader();

                                    if (dr.Read())
                                    {
                                        dr.Close();
                                        Response.Write("<script>alert('Imagen ya existente.');</script>");
                                    }
                                    else
                                    {
                                        dr.Close();
                                        SqlConnection cone = new SqlConnection(Conexion.CadenaDeConexion());
                                        SqlCommand cmd = new SqlCommand();

                                        cmd.CommandText = "INSERT INTO FotoEmpresa(RutEmpresa,Imagen,NombreImagen,Descripcion)" +
                                            "VALUES ((SELECT RutEmpresa from Empresa where Nombre=@idEmp)," +
                                            "@imagen,@nombreImg,@descripcion)";
                                        cmd.Parameters.Add("@idEmp", SqlDbType.NVarChar).Value = idEmp;
                                        cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = ImagenOriginal;
                                        cmd.Parameters.Add("@nombreImg", SqlDbType.NVarChar).Value = txt_nombreimagen.Text;
                                        cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar).Value = txt_descripcion.Text;
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Connection = cone;
                                        cone.Open();
                                        cmd.ExecuteNonQuery();
                                        Response.Write("<script>alert('Agregada exitosamente.');</script>");
                                        string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
                                        imgPreview.ImageUrl = ImagenDataURL64;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Debe asociar la imagen a un Proyecto, Servicio o Empresa');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            
                try
                {
                    if (ddl_seleccionar.SelectedIndex == 0)
                    {
                        Response.Write("<script>alert('Debe asociar la imagen a un Proyecto, Servicio o Empresa.');</script>");
                    }
                    else if (ddl_seleccionar.SelectedIndex == 1)
                    {
                        if(ddl_nombrePro.SelectedIndex != 0)
                        {
                            MantenedorFotosProyectos man = new MantenedorFotosProyectos();
                            string nombre = ddl_nombrePro.SelectedValue;
                            txt_id.Text = man.BuscarFoto(nombre).Rows[0][0].ToString();
                            txt_descripcion.Text = man.BuscarFoto(nombre).Rows[0][1].ToString();
                            ddl_pro.Text = man.BuscarFoto(nombre).Rows[0][2].ToString();
                            txt_nombreimagen.Text = man.BuscarFoto(nombre).Rows[0][4].ToString();


                            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
                            string query = "select imagen from fotoproyecto where nombreimagen='" + nombre + "'";
                            SqlCommand cm = new SqlCommand(query, sql);
                            sql.Open();
                            cm.CommandTimeout = 0;

                            byte[] img = (byte[])cm.ExecuteScalar();
                            System.Drawing.Image rImg = null;
                            using (MemoryStream ms = new MemoryStream(img))
                            {
                                rImg = System.Drawing.Image.FromStream(ms);
                                imgPreview.ImageUrl = "data:image;base64," + Convert.ToBase64String(img);
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Debe seleccionar una imagen.');</script>");
                        }
                        
                    }
                    else if (ddl_seleccionar.SelectedIndex == 2)
                    {
                        if (ddl_nombreServ.SelectedIndex != 0)
                        {
                            MantenedorFotosServicios man = new MantenedorFotosServicios();
                            string nombre = ddl_nombreServ.SelectedValue;
                            txt_id.Text = man.BuscarFotoServicio(nombre).Rows[0][0].ToString();
                            txt_descripcion.Text = man.BuscarFotoServicio(nombre).Rows[0][1].ToString();
                            ddl_ser.Text = man.BuscarFotoServicio(nombre).Rows[0][3].ToString();
                            txt_nombreimagen.Text = man.BuscarFotoServicio(nombre).Rows[0][4].ToString();
                            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
                            string query = "select imagen from fotoServicio where nombreimagen='" + nombre + "'";
                            SqlCommand cm = new SqlCommand(query, sql);
                            sql.Open();
                            cm.CommandTimeout = 0;

                            byte[] img = (byte[])cm.ExecuteScalar();
                            System.Drawing.Image rImg = null;
                            using (MemoryStream ms = new MemoryStream(img))
                            {
                                rImg = System.Drawing.Image.FromStream(ms);
                                imgPreview.ImageUrl = "data:image;base64," + Convert.ToBase64String(img);
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Debe seleccionar una imagen.');</script>");
                        }
                    }
                    else
                    {
                        if (ddl_nombreEmp.SelectedIndex != 0)
                        {
                            MantenedorFotosEmpresa man = new MantenedorFotosEmpresa();
                            string nombre = ddl_nombreEmp.SelectedValue;
                            txt_id.Text = man.BuscarFotoEmpresa(nombre).Rows[0][0].ToString();
                            txt_descripcion.Text = man.BuscarFotoEmpresa(nombre).Rows[0][1].ToString();
                            ddl_emp.Text = man.BuscarFotoEmpresa(nombre).Rows[0][3].ToString();
                            txt_nombreimagen.Text = man.BuscarFotoEmpresa(nombre).Rows[0][4].ToString();
                            SqlConnection sql = new SqlConnection(Conexion.CadenaDeConexion());
                            string query = "select imagen from fotoEmpresa where nombreimagen='" + nombre + "'";
                            SqlCommand cm = new SqlCommand(query, sql);
                            sql.Open();
                            cm.CommandTimeout = 0;

                            byte[] img = (byte[])cm.ExecuteScalar();
                            System.Drawing.Image rImg = null;
                            using (MemoryStream ms = new MemoryStream(img))
                            {
                                rImg = System.Drawing.Image.FromStream(ms);
                                imgPreview.ImageUrl = "data:image;base64," + Convert.ToBase64String(img);
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Debe seleccionar una imagen.');</script>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('"+ex.Message+"');</script>");
                }
            
        }


        protected void boton_modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_seleccionar.SelectedIndex == 1)
                {
                    if (txt_nombreimagen.Text.Trim().Length > 0 && txt_descripcion.Text.Trim().Length > 0 && ddl_pro.SelectedIndex != 0)
                    {
                        if(txt_descripcion.Text.Length<=500)
                        {
                            FotoProyecto foto = new FotoProyecto();
                            MantenedorFotosProyectos man = new MantenedorFotosProyectos();

                            string id = txt_id.Text;

                            foto.Proyecto.NombreProyecto = ddl_pro.SelectedValue;

                            foto.NombreImagen = txt_nombreimagen.Text;
                            foto.Descripcion = txt_descripcion.Text;

                            if (archivofoto.HasFile)
                            {
                                int tamanio = archivofoto.PostedFile.ContentLength;
                                byte[] ImagenOriginal = new byte[tamanio];
                                archivofoto.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
                                Bitmap ImagenOriginalBinaria = new Bitmap(archivofoto.PostedFile.InputStream);

                                SqlConnection cone = new SqlConnection(Conexion.CadenaDeConexion());
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "UPDATE fotoproyecto SET Imagen=@imagen where IdFotopro='" + id + "'";
                                //imagen
                                cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = ImagenOriginal;
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = cone;
                                cone.Open();
                                cmd.ExecuteNonQuery();

                                string ImagenDataURL64 = "data:image;base64," + Convert.ToBase64String(ImagenOriginal);
                                imgPreview.ImageUrl = ImagenDataURL64;

                                man.ModificarFoto(foto, id);
                            }
                            else
                            {
                                man.ModificarFoto(foto, id);
                            }
                            Response.Write("<script>alert('Modificado exitosamente.');</script>");
                            txt_nombreimagen.Text = "";
                            txt_id.Text = "";
                            txt_descripcion.Text = "";
                            ddl_nombrePro.SelectedIndex = 0;
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
                else if (ddl_seleccionar.SelectedIndex == 2)
                {
                    if (txt_nombreimagen.Text.Trim().Length > 0 && txt_descripcion.Text.Trim().Length > 0 && ddl_ser.SelectedIndex != 0)
                    {
                        if (txt_descripcion.Text.Length <= 500)
                        {
                            FotoServicio foto = new FotoServicio();
                            MantenedorFotosServicios man = new MantenedorFotosServicios();

                            string id = txt_id.Text;

                            foto.Servicio.NombreServicio = ddl_ser.SelectedValue;

                            foto.NombreImagen = txt_nombreimagen.Text;
                            foto.Descripcion = txt_descripcion.Text;

                            if (archivofoto.HasFile)
                            {
                                int tamanio = archivofoto.PostedFile.ContentLength;
                                byte[] ImagenOriginal = new byte[tamanio];
                                archivofoto.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
                                Bitmap ImagenOriginalBinaria = new Bitmap(archivofoto.PostedFile.InputStream);

                                SqlConnection cone = new SqlConnection(Conexion.CadenaDeConexion());
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "UPDATE fotoServicio SET Imagen=@imagen where IdFotoserv='" + id + "'";
                                //imagen
                                cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = ImagenOriginal;
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = cone;
                                cone.Open();
                                cmd.ExecuteNonQuery();

                                string ImagenDataURL64 = "data:image;base64," + Convert.ToBase64String(ImagenOriginal);
                                imgPreview.ImageUrl = ImagenDataURL64;

                                man.ModificarFotoServicio(foto, id);
                            }
                            else
                            {
                                man.ModificarFotoServicio(foto, id);
                            }
                            Response.Write("<script>alert('Modificado exitosamente.');</script>");
                            txt_nombreimagen.Text = "";
                            txt_id.Text = "";
                            txt_descripcion.Text = "";
                            ddl_nombreServ.SelectedIndex = 0;
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
                else if (ddl_seleccionar.SelectedIndex == 3)
                {
                    if (txt_nombreimagen.Text.Trim().Length > 0 && txt_descripcion.Text.Trim().Length > 0 && ddl_emp.SelectedIndex != 0)
                    {
                        if (txt_descripcion.Text.Length <= 500)
                        {
                            FotoEmpresa foto = new FotoEmpresa();
                            MantenedorFotosEmpresa man = new MantenedorFotosEmpresa();

                            string id = txt_id.Text;

                            foto.Empresa.NombreEmpresa = ddl_emp.SelectedValue;

                            foto.NombreImagen = txt_nombreimagen.Text;
                            foto.Descripcion = txt_descripcion.Text;

                            if (archivofoto.HasFile)
                            {
                                int tamanio = archivofoto.PostedFile.ContentLength;
                                byte[] ImagenOriginal = new byte[tamanio];
                                archivofoto.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
                                Bitmap ImagenOriginalBinaria = new Bitmap(archivofoto.PostedFile.InputStream);

                                SqlConnection cone = new SqlConnection(Conexion.CadenaDeConexion());
                                SqlCommand cmd = new SqlCommand();
                                cmd.CommandText = "UPDATE fotoEmpresa SET Imagen=@imagen where IdFotoEmp='" + id + "'";
                                //imagen
                                cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = ImagenOriginal;
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = cone;
                                cone.Open();
                                cmd.ExecuteNonQuery();

                                string ImagenDataURL64 = "data:image;base64," + Convert.ToBase64String(ImagenOriginal);
                                imgPreview.ImageUrl = ImagenDataURL64;

                                man.ModificarFotoEmpresa(foto, id);
                            }
                            else
                            {
                                man.ModificarFotoEmpresa(foto, id);
                            }
                            Response.Write("<script>alert('Modificados exitosamente.');</script>");
                            txt_nombreimagen.Text = "";
                            txt_id.Text = "";
                            txt_descripcion.Text = "";
                            ddl_nombreEmp.SelectedIndex = 0;
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
                else
                {
                    Response.Write("<script>alert('Debe asociar la imagen a un Proyecto, Servicio o Empresa.');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ddl_seleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_seleccionar.SelectedIndex==1)
            {
                ddl_pro.Visible = true;
                ddl_ser.Visible = false;
                ddl_emp.Visible = false;
                ddl_ser.SelectedIndex = 0;
                ddl_emp.SelectedIndex = 0;
                ddl_nombrePro.Visible = true;
                ddl_nombreServ.Visible = false;
                ddl_nombreEmp.Visible = false;
                ddl_nombreServ.SelectedIndex = 0;
                ddl_nombreEmp.SelectedIndex = 0;
            }
            else if(ddl_seleccionar.SelectedIndex == 2)
            {
                ddl_pro.Visible = false;
                ddl_ser.Visible = true;
                ddl_emp.Visible = false;
                ddl_pro.SelectedIndex = 0;
                ddl_emp.SelectedIndex = 0;
                ddl_nombrePro.Visible = false;
                ddl_nombreServ.Visible = true;
                ddl_nombreEmp.Visible = false;
                ddl_nombrePro.SelectedIndex = 0;
                ddl_nombreEmp.SelectedIndex = 0;

            }
            else if (ddl_seleccionar.SelectedIndex == 3)
            {
                ddl_pro.Visible = false;
                ddl_ser.Visible = false;
                ddl_emp.Visible = true;
                ddl_pro.SelectedIndex = 0;
                ddl_ser.SelectedIndex = 0;
                ddl_nombrePro.Visible = false;
                ddl_nombreServ.Visible = false;
                ddl_nombreEmp.Visible = true;
                ddl_nombrePro.SelectedIndex = 0;
                ddl_nombreServ.SelectedIndex = 0;
            }
            else
            {
                ddl_pro.Visible = false;
                ddl_ser.Visible = false;
                ddl_emp.Visible = false;
                ddl_pro.SelectedIndex = 0;
                ddl_ser.SelectedIndex = 0;
                ddl_emp.SelectedIndex = 0;
                ddl_nombrePro.Visible = false;
                ddl_nombreServ.Visible = false;
                ddl_nombreEmp.Visible = false;
                ddl_nombrePro.SelectedIndex = 0;
                ddl_nombreServ.SelectedIndex = 0;
                ddl_nombreEmp.SelectedIndex = 0;
            }
        }
    }
    
}