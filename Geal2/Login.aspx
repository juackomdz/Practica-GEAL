<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Geal2.Login" %>

<!DOCTYPE html>
<html>

<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>Login</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">

    <link rel="stylesheet" href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">
    <link rel="stylesheet" href="css/estiloformulariologin.css">
    <link rel="stylesheet" href="css/estiloLogin.css">
    <link rel="stylesheet" href="css/estilobarra.css">

     <script language="javascript" type="text/javascript">
     javascript:window.history.forward(1);
     </script>
</head>

<body>
   <a class="btn btn-primary" role="button" href="InicioUsuarioActualizado.aspx" id="btn_volver">Volver</a>
    <div id="login" class="login-clean">
        <form method="post" runat="server">
            <h2 class="sr-only">Login Form</h2>
            <div class="illustration"><i class="fas fa-user" id="loginicono">
                <img src="img/usericon.png" style="width:50%; height:50%;" /></i></div>
            <div class="form-group"><asp:TextBox class="form-control" type="email" name="email" placeholder="Email" id="txt_email" runat="server" required=""/></div>
            <div class="form-group"><asp:TextBox class="form-control" type="password" name="password" placeholder="Contaseña" id="txt_contrasena" runat="server" required=""/></div>
            <div>      
            <asp:TextBox ID="txt_mensaje" ReadOnly = "true" BorderColor="White" style="color:red" Font-Size="10" runat="server" 
             Visible="False" Width="213px" BorderStyle="Double" Enabled="False"></asp:TextBox></div>

            <div class="form-group"><asp:Button class="btn btn-primary btn-block" type="submit" id="btn_login" placeholder="Iniciar Sesión" runat="server" Text="Iniciar Sesión" OnClick="btn_login_Click"/></div><a href="OlvidarContraseña.aspx" class="forgot">¿Ha olvidado su contraseña?</a></form>
    </div>
     <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
</body>

</html>
