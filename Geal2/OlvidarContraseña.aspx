<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OlvidarContraseña.aspx.cs" Inherits="Geal2.OlvidarContraseña" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>OlvidarContraseña</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">

    <link href="css/EstiloOlvidarContraseña.css" rel="stylesheet" />

</head>

<body>
    <a class="btn btn-primary" role="button" href="Login.aspx" id="btn_volver">Volver</a>
    <div class="contact-clean" style="background-color: rgba(241,247,252,0);">
        <form class="text-truncate" method="post" runat="server" style="background-color: rgba(255,255,255,0.62);margin-top: 60px;">
            <h2 class="text-center">¿Has olvidado<br>&nbsp;tu contraseña?</h2>
            <div class="form-group">
                <p>Ingresa tu email para confirmar</p><asp:TextBox class="form-control" type="email" name="email" placeholder="Email" id="txt_email" runat="server"/></div>
            <div class="form-group text-center"><asp:Button class="btn btn-primary btn-block" type="submit" id="btn_confirmar" runat="server" Text="Confirmar" OnClick="btn_confirmar_Click"/>
                <asp:TextBox ID="txt_clave" runat="server" Visible="false"></asp:TextBox>
                
            </div>
        </form>
    </div>
   <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <script src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>
</body>

</html>