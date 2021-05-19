<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerMasServicios.aspx.cs" Inherits="Geal2.VerMasServicios" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>VerServicios</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">

    <link rel="stylesheet" href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">
</head>

<body>

   


    <section>
        <div class="fixed-top navbar navbar-dark bg-dark border-bottom" style="">
            <a class="btn  btn-outline-primary" role="button" href="InicioUsuarioActualizado.aspx" id="btn_volver">Volver</a>
            <h3 class="navbar m-auto" style="text-align:center; color:white;">Nuestros Servicios</h3>
        </div>
        <div class="container text-center shadow-lg p-3 mb-5 bg-light rounded" style="margin-top:150px; max-width: 1350px;">
            <asp:Repeater runat="server" ID="repetidor">
                <ItemTemplate>
                    <div class="card text-white bg-dark mb-3" style="max-width: 1200px; margin: auto;">
                        <div class="row no-gutters">
                            <div class="col-md-4" >
                                <img class="img-fluid card-img-top" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" style="max-width: 500px;" />
                            </div>
                            <div class="col-md-8">
                                <div class="card-body text-center">
                                    <h4 class="card-title">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreServicio") %>' /></h4>
                                    <p class="card-text">

                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("DescripcionServicio") %>' />
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </section>


    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <script src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>

</body>

</html>
