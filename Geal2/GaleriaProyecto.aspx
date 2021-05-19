<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GaleriaProyecto.aspx.cs" Inherits="Geal2.GaleriaProyecto" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>GaleriaDeFotosProyectos</title>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">

    <link rel="stylesheet" href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">
</head>
<body>
    <div class="container">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <section style="margin-bottom:100px;">
            <div class="fixed-top navbar navbar-dark bg-dark border-bottom" style="">
                <a class="btn btn-outline-primary" role="button" href="VerMasProyectos.aspx" id="btn_volver">Volver</a>
                <h3 class="navbar m-auto" style="text-align: center; color: white;">Galeria de Fotos</h3>
            </div>
            <div class="container shadow-lg p-3 mb-5 bg-white rounded" style="margin-top: 100px;">
            <div class="container text-center " style="margin-top: 50px;">
                <asp:Repeater runat="server" ID="repetidor">
                    <ItemTemplate>
                        <div class="card text-white bg-dark mb-3" style="max-width: 1000px; margin: auto;">
                            <div class="row no-gutters">

                                <div class="col-md-12">
                                    <div class="card-body text-center">
                                        <h4 class="card-title">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreProyecto") %>' /></h4>
                                        <p class="card-text">

                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("DescripcionPro") %>' />
                                        </p>


                                    </div>
                                </div>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            
            <div class="row" style="max-width: 1000px; margin: auto;">
                <asp:Repeater runat="server" ID="repetidor1">
                    <ItemTemplate>


                        <div class="col-md-6">

                            <img class="img-fluid card-img-top" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" style="margin-bottom:20px;" />
                            
                        </div>
                        

                    </ItemTemplate>
                </asp:Repeater>
            </div>
                </div>
        </section>


    </div>

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
    <script src="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.js"></script>

</body>
</html>
