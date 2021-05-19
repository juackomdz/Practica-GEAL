<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="barra2.aspx.cs" Inherits="Geal2.barra2" %>

<!DOCTYPE html>

<html>
<head runat="server">
 <meta charset="utf-8">
 <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title></title>
    <link href="assetsInicioUsuario/css/EstiloBarra2.css" rel="stylesheet" />
</head>
    
<body>
   <nav>
        <a class="" href="#Inicio" style="width:120px;">
            <img src="img/Logo GEAL.png" width="105" height="30" class="" alt="Logo GEAL" style="text-align:left;"></a>
       <button class="nav-boton" onclick="accion()" style="width:20px;">Menú</button>
       <a href="#" class="nav-enlace desaparece">Inicio</a>
       <a href="#" class="nav-enlace desaparece">Nosotros</a>
       <a href="#" class="nav-enlace desaparece">Servicios</a>
       <a href="#" class="nav-enlace desaparece">Proyectos</a>
       <a href="#" class="nav-enlace desaparece">Contáctanos</a>
   </nav>
    <script>
        function accion() {
            console.log('Está funcionando mi boton');
            var ancla = document.getElementsByClassName('nav-enlace');
            for (var i = 0; i < ancla.length; i++) {
                ancla[i].classList.toggle('desaparece');
            }
        }
    </script>
</body>
</html>
