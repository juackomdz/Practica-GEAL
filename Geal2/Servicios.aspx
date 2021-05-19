<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="Geal2.Servicios" %>
<%@ OutputCache Location="None" NoStore="true"%>
<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>Servicios</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">

    <link rel="stylesheet" href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">

    <link rel="stylesheet" href="css/estiloformularioservicios.css">
    <link rel="stylesheet" href="css/estilobarra.css">

</head>

<body id="body_servicios">

    <nav class="navbar navbar-light navbar-expand-lg fixed-top">
        <div class="container-fluid">
            <a class="navbar-brand" href="InicioAdmin.aspx">
                <img id="logogeal" src="img/Logo GEAL.png" class="img-fluid">
            </a>
            <button class="navbar-toggler" data-toggle="collapse" data-target="#navcol-1" style="background-color: #00a3d8;color: white;">
                <span class="sr-only">Toggle navigation</span>
                <span class="navbar-toggler-icon"></span></button>
            <div
                class="collapse navbar-collapse" id="navcol-1">
                <ul class="nav navbar-nav mx-auto">
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="Nosotros.aspx">Nosotros</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="Servicios.aspx" style="color:#00a3d8;">Servicios</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="Proyectos.aspx">Proyectos</a></li>
                    
                    <li class="nav-item dropdown" role="presentation">
                        <a class="nav-link text-center" data-toggle="dropdown">Clientes</a>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="Clientes.aspx">Mantenedor Clientes</a>
                            <a class="dropdown-item" href="ListarClientes.aspx">Listar Clientes</a>
                           </div>
                    </li>
                    
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="Fotos.aspx">Fotos</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="CambiaContraseña.aspx">Cambiar Clave</a></li>
                </ul>
                <ul class="nav navbar-nav">
                    <li class="nav-item text-center" role="presentation" id="navlogout" style="background-color: #ff0000;border-radius: 5px;"><a class="nav-link active" href="Logout.aspx" >Cerrar Sesión</a></li>
                </ul>
        </div>
        </div>
    </nav>
    <div class="text-center contact-clean" id="bloque_formulario">
        <form method="post" runat="server" style="background-color: rgba(255,255,255,0.52); margin-top:80px">
            <h2 class="text-center">Mantenedor de Servicios</h2>
            <div class="dropdown">
                    <asp:DropDownList class="btn btn-light btn-block dropdown-toggle text-center" runat="server" ID="ddl_nombre" style="background-color:white;"/>
                
                </div>
            <asp:Button class="btn btn-primary" type="button" id="boton_buscar" runat="server" Text="Buscar" OnClick="boton_buscar_Click"/> 
            <div class="form-group">
                <asp:TextBox ID="txt_nombre" class="form-control" type="text" name="name" placeholder="Nombre Servicio" runat="server" style="margin-top:10px;"/></div>
            <div class="form-group"><asp:TextBox id="txt_desc" class="form-control" rows="14" name="message" placeholder="Descripción" runat="server" TextMode="MultiLine"/></div>
            <div class="form-group text-center">
                <div class="form-row">
                    <div class="col"><asp:Button class="btn btn-success active" type="submit" id="boton_agregar" runat="server" Text="Agregar" OnClick="boton_agregar_Click" style="margin-bottom: 10px;"/></div>
                    <div class="col"><asp:Button class="btn" type="submit" runat="server" id="boton_modificar" Text="Modificar" OnClick="boton_modificar_Click" style="margin-bottom: 10px; background-color:#E8B507;" /></div>
                    <div class="col"><asp:Button class="btn btn-danger active" type="submit" id="boton_eliminar" runat="server" Text="Eliminar" OnClick="boton_eliminar_Click"/></div>
                </div>
                <asp:TextBox ID="txt_idServicio" runat="server" Visible="False"></asp:TextBox>
            </div>
        </form>
    </div>
        <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
        <script src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
</body>

</html>