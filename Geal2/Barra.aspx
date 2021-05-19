<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Barra.aspx.cs" Inherits="Geal2.Barra" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>Untitled</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">

    <link rel="stylesheet" href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">

    <link rel="stylesheet" href="css/estilobarra.css">
</head>

<body>
    <nav class="navbar navbar-light navbar-expand-lg fixed-top">
        <div class="container-fluid">
            <a class="navbar-brand" href="InicioAdmin.aspx">
                <img id="logogeal" src="img/Logo GEAL.png" class="img-fluid">
            </a>
            <button class="navbar-toggler" data-toggle="collapse" data-target="#navcol-1" style="background-color: #00a3d8;color: white;">
                <span class="sr-only">Toggle navigation</span>
                <span class="navbar-toggler-icon"></span></button>
            <div class="collapse navbar-collaps" id="navcol-1">
                <ul class="nav navbar-nav mx-auto">
                    <li class="nav-item" role="presentation"><a class="nav-link text-center " href="Nosotros.aspx" style="color:#00a3d8;">Nosotros</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="Servicios.aspx">Servicios</a></li>
                    <li class="nav-item" role="presentation"><a class="nav-link text-center" href="Proyectos.aspx">Proyectos</a></li>
                    <li class="nav-item dropdown" role="presentation">
                        <a class="nav-link text-center" data-toggle="dropdown">Contactos</a>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" href="Contactos.aspx">Mantenedor Contactos</a>
                            <a class="dropdown-item" href="ListarContacos.aspx">Listar Contacto</a>
                           </div>
                    </li>
                    <li class="nav-item dropdown" role="presentation">
                        <a class="nav-link text-center" data-toggle="dropdown">Clientes</a>
                        <div class="dropdown-menu">
                            <a  class="dropdown-item" href="Clientes.aspx">Mantenedor Clentes</a>
                            <a class="dropdown-item" href="ListarClientes.aspx">Listar Cliente</a>
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


    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <script src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
</body>

</html>