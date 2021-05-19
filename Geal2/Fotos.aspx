<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fotos.aspx.cs" Inherits="Geal2.Fotos" %>

<%@ OutputCache Location="None" NoStore="true" %>
<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>Fotos</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">

    <link rel="stylesheet" href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">
    <link rel="stylesheet" href="css/EstiloFormularioFotos.css">
    <link rel="stylesheet" href="css/estilobarra.css">
</head>

<body id="body_foto">

    <nav class="navbar navbar-light navbar-expand-lg fixed-top">
        <div class="container-fluid">
            <a class="navbar-brand" href="InicioAdmin.aspx">
                <img id="logogeal" src="img/Logo GEAL.png" class="img-fluid">
            </a>
            <button class="navbar-toggler" data-toggle="collapse" data-target="#navcol-1" style="background-color: #00a3d8; color: white;">
                <span class="sr-only">Toggle navigation</span>
                <span class="navbar-toggler-icon"></span>
            </button>
            <div
                class="collapse navbar-collapse" id="navcol-1">
                <ul class="nav navbar-nav mx-auto">
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="Nosotros.aspx">Nosotros</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="Servicios.aspx">Servicios</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="Proyectos.aspx">Proyectos</a></li>

                    <li class="nav-item dropdown" role="presentation">
                        <a class="nav-link text-center" data-toggle="dropdown">Clientes</a>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="Clientes.aspx">Mantenedor Clientes</a>
                            <a class="dropdown-item" href="ListarClientes.aspx">Listar Clientes</a>
                        </div>
                    </li>

                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="Fotos.aspx" style="color: #00a3d8;">Fotos</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="CambiaContraseña.aspx">Cambiar Clave</a></li>
                </ul>
                <ul class="nav navbar-nav">
                    <li class="nav-item text-center" role="presentation" id="navlogout" style="background-color: #ff0000; border-radius: 5px;"><a class="nav-link active" href="Logout.aspx">Cerrar Sesión</a></li>
                </ul>
            </div>
        </div>
    </nav>

    <div class="text-center contact-clean" id="bloque_fotos">
        <form method="post" runat="server" style="background-color: rgba(255,255,255,0.52); margin-top: 80px;">
            <h2 class="text-center">Mantenedor Fotos</h2>
            <div class="form-group">
                <asp:DropDownList class="btn btn-light btn-block dropdown-toggle text-center " ID="ddl_seleccionar" runat="server" OnSelectedIndexChanged="ddl_seleccionar_SelectedIndexChanged" AutoPostBack="True" Style="background-color: white;"></asp:DropDownList>

            </div>

            <div class="dropdown">
                <asp:DropDownList class="btn btn-light btn-block dropdown-toggle text-center" runat="server" Visible="False" ID="ddl_nombrePro" Style="background-color: white;" />
            </div>

            <div class="dropdown">
                <asp:DropDownList class="btn btn-light btn-block dropdown-toggle text-center" runat="server" Visible="False" ID="ddl_nombreServ" Style="background-color: white;" />
            </div>

            <div class="dropdown">
                <asp:DropDownList class="btn btn-light btn-block dropdown-toggle text-center" runat="server" Visible="False" ID="ddl_nombreEmp" Style="background-color: white;" />
            </div>

            <asp:Button class="btn btn-primary" type="button" ID="btn_buscar" runat="server" Text="Buscar" OnClick="btn_buscar_Click" />
            <div class="form-group">
                <asp:TextBox ID="txt_nombreimagen" class="form-control" type="text" name="name" placeholder="Nombre Imagen" runat="server" style="margin-top:10px;"/>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txt_descripcion" class="form-control" Rows="14" name="message" placeholder="Descripción" runat="server" TextMode="MultiLine" />
            </div>
            <div class="form-group">

                <div class="form-group">

                    <div class="form-row">
                        <div class="col">
                            <div class="form-group"></div>

                            <asp:FileUpload ID="archivofoto" runat="server" accept=".jpg" CssClass="form-control" />
                        </div>


                    </div>
                    <div class="form-group">
                        <h3>Imagen Seleccionada :</h3>
                    </div>
                    <div class="form-group">
                        <asp:Image ID="imgPreview" Width="200" ImageUrl="https://pngimage.net/wp-content/uploads/2018/05/agregar-png.png" runat="server" />
                    </div>



                </div>
            </div>

            <div class="form-group">
                <div class="dropdown">
                    <asp:DropDownList class="btn btn-light btn-block dropdown-toggle text-center" runat="server" ID="ddl_pro" Visible="False" Style="background-color: white;" />

                </div>
            </div>
            <div class="form-group">
                <div class="dropdown">
                    <asp:DropDownList class="btn btn-light btn-block dropdown-toggle text-center" runat="server" ID="ddl_ser" Visible="False" Style="background-color: white;" />
                    <div class="dropdown-menu" role="menu"><a class="dropdown-item" role="presentation" href="#">First Item</a><a class="dropdown-item" role="presentation" href="#">Second Item</a><a class="dropdown-item" role="presentation" href="#">Third Item</a></div>
                </div>
            </div>
            <div class="form-group">
                <div class="dropdown">
                    <asp:DropDownList class="btn btn-light btn-block dropdown-toggle text-center" runat="server" ID="ddl_emp" Visible="False" Style="background-color: white;" />
                    <div class="dropdown-menu" role="menu"><a class="dropdown-item" role="presentation" href="#">First Item</a><a class="dropdown-item" role="presentation" href="#">Second Item</a><a class="dropdown-item" role="presentation" href="#">Third Item</a></div>
                </div>
            </div>
            <div class="form-group">
                <div class="form-row">
                    <div class="col">
                        <asp:Button class="btn btn-success active" type="submit" ID="boton_agregar" runat="server" Text="Agregar" OnClick="boton_agregar_Click" Style="margin-bottom: 10px;" />
                    </div>
                    <div class="col">
                        <asp:Button class="btn btn-warning active" type="submit" ID="boton_modificar" runat="server" Text="Modificar" OnClick="boton_modificar_Click" Style="margin-bottom: 10px;" />
                    </div>
                    <div class="col">
                        <asp:Button class="btn btn-danger active" type="submit" ID="boton_eliminar" runat="server" Text="Eliminar" OnClick="boton_eliminar_Click" />
                    </div>
                    <asp:TextBox ID="txt_id" runat="server" Visible="false"></asp:TextBox>
                </div>

            </div>
        </form>
    </div>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <script src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
</body>

</html>
