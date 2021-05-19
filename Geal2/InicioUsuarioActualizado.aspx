<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioUsuarioActualizado.aspx.cs" Inherits="Geal2.InicioUsuarioActualizado" %>

<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>InicioUsuario</title>
    <link rel="stylesheet" href="assetsInicioUsuario/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assetsInicioUsuario/css/dh-row-text-image-right-responsive.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/Swiper/3.3.1/css/swiper.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/lightbox2/2.8.2/css/lightbox.min.css">

    <link rel="stylesheet" href="assetsInicioUsuario/css/Lightbox-Gallery.css">

    <link href="css/EstiloFormularioDeContacto.css" rel="stylesheet" />
    <link href="assetsInicioUsuario/css/EstiloBarra2.css" rel="stylesheet" />
    <link href="assetsInicioUsuario/css/Simple-Slider.css" rel="stylesheet" />
</head>

<body>
    <nav class="navbar bg-dark navbar-expand-sm fixed-top">
        <a class="navbar-brand js-scroll-trigger" href="#Inicio">
            <img src="img/Logo GEAL.png" width="105" height="30" class="d-inline-block align-top" alt="Logo GEAL"></a>
        <button class="navbar-toggler nav-boton" data-toggle="collapse" data-target="#barra">
            <img src="img/toggle%20menu.png" class="img-fluid" style="max-width: 30px;" />

        </button>

        <div class="collapse navbar-collapse " id="barra">
            <div class="navbar-nav mr-auto ml-auto text-center">
                <a class="nav-item nav-link js-scroll-trigger nav-enlace" href="#Inicio">Inicio</a>
                <a class="nav-item nav-link js-scroll-trigger nav-enlace" href="#Nosotros">Nosotros</a>
                <a class="nav-item nav-link js-scroll-trigger nav-enlace" href="#Servicios">Servicios</a>
                <a class="nav-item nav-link js-scroll-trigger nav-enlace" href="#Proyectos">Proyectos</a>
                <a class="nav-item nav-link js-scroll-trigger nav-enlace" href="#Contactanos">Contactános</a>
            </div>
        </div>
    </nav>
    <style>
        #titulo {
            color: white;
            font-size: 90px;
            font-style: italic;
        }

        .texto-inicio {
            max-width: 600px;
            margin-left: 20px;
            margin-right: 20px;
        }

        @media (max-width: 400px) {
            #titulo {
                font-size: 60px;
            }

            #subtitulo {
                font-size: 30px;
            }

            .imagenes {
                flex: auto;
            }

            .simple-slider .swiper-button-next, .simple-slider .swiper-button-prev {
                display: none;
            }
        }
    </style>

    <header id="Inicio" style="background-image: url(img/subasta-electrica-copia.jpg); background-position: center; background-size: cover; background-repeat: no-repeat;">
        <div class="container d-flex d-sm-flex d-md-flex d-lg-flex align-items-center align-items-sm-center align-items-md-center justify-content-lg-center align-items-lg-center" style="height: 100vh;">
            <%--<div class="container" style="background-color:rgba(0,0,0,0.50);border-radius:10px; max-width:600px;">--%>
            <div id="texto-inicio" class="text-center container" style="max-width: 500px; margin-top: 10px; margin-bottom: 10px; background-color: rgba(0,0,0,0.50); border-radius: 10px;">
                <div><span class="div-titulo" id="titulo">GEAL</span></div>
                <div><span class="div-subtitulo" id="subtitulo" style="color: white; font-size: 45px; font-style: italic;">Electricidad Industrial</span></div>
                <div><a class="btn btn-warning btn-xl text-uppercase js-scroll-trigger" role="button" href="#Contactanos" id="btncontactanos" style="margin-bottom: 30px; font-weight: bold;">Contáctanos</a></div>
            </div>
            <%-- </div>--%>
        </div>
    </header>

    <div id="Nosotros" class="photo-gallery">
        <div class="container">
            <div class="intro" style="max-width: 1000px;">
                <asp:Repeater runat="server" ID="repetidor">
                    <ItemTemplate>
                        <h2 class="text-center" style="font-size: 35px;">
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label></h2>
                        <p class="text-center m-suto " style="font-size: 25px;">
                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                        </p>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <div class="row photos">
                <div class="col-sm-6 col-md-6 col-lg-4 item">
                    <asp:Repeater runat="server" ID="repetidorfoto1">
                        <ItemTemplate>
                            <a href="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" data-lightbox="photos">
                                <img class="img-fluid" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" /></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-sm-6 col-md-6 col-lg-4 item">
                    <asp:Repeater runat="server" ID="repetidorfoto2">
                        <ItemTemplate>
                            <a href="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" data-lightbox="photos">
                                <img class="img-fluid" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" /></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-sm-6 col-md-6 col-lg-4 item">
                    <asp:Repeater runat="server" ID="repetidorfoto3">
                        <ItemTemplate>
                            <a href="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" data-lightbox="photos">
                                <img class="img-fluid" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" /></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-sm-6 col-md-6 col-lg-4 item">
                    <asp:Repeater runat="server" ID="repetidorfoto4">
                        <ItemTemplate>
                            <a href="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" data-lightbox="photos">
                                <img class="img-fluid" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" /></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-sm-6 col-md-6 col-lg-4 item">
                    <asp:Repeater runat="server" ID="repetidorfoto5">
                        <ItemTemplate>
                            <a href="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" data-lightbox="photos">
                                <img class="img-fluid" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" /></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="col-sm-6 col-md-6 col-lg-4 item">
                    <asp:Repeater runat="server" ID="repetidorfoto6">
                        <ItemTemplate>
                            <a href="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" data-lightbox="photos">
                                <img class="img-fluid" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" /></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>


            </div>
        </div>
    </div>


    <section class="text-center" id="Servicios" style="margin-top: 100px; background-color: #E4E4E4;">
        <div class="text-center" style="width: 100%;"><span style="color: rgb(0,0,0); font-weight: bold; font-size: 35px;">Nuestros Servicios</span></div>
        <div class="simple-slider text-center">
            <div class="text-center swiper-container" style="max-width: 900px; max-height: 700px;">
                <div class="text-center swiper-wrapper">
                    <div class="swiper-slide">
                        <asp:Repeater runat="server" ID="repetidorServicio1">
                            <ItemTemplate>
                                <h4>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreServicio") %>'></asp:Label></h4>
                                <img class="img-fluid w-100 d-block imagenes" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>">
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <div class="swiper-slide">
                        <asp:Repeater runat="server" ID="repetidorServicio2">
                            <ItemTemplate>
                                <h4>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreServicio") %>'></asp:Label></h4>
                                <img class="img-fluid w-100 d-block imagenes" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" alt="Slide Image" style="margin: auto; max-height: 500px; min-height: 150px;">
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="swiper-slide">
                        <asp:Repeater runat="server" ID="repetidorServicio3">
                            <ItemTemplate>
                                <h4>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreServicio") %>'></asp:Label></h4>
                                <img class="img-fluid w-100 d-block imagenes" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" alt="Slide Image" style="margin: auto; max-height: 500px; min-height: 150px;">
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="swiper-slide">
                        <asp:Repeater runat="server" ID="repetidorServicio4">
                            <ItemTemplate>
                                <h4>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreServicio") %>'></asp:Label></h4>
                                <img class="img-fluid w-100 d-block imagenes" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" alt="Slide Image" style="margin: auto; max-height: 500px; min-height: 150px;">
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="swiper-slide">
                        <asp:Repeater runat="server" ID="repetidorServicio5">
                            <ItemTemplate>
                                <h4>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreServicio") %>'></asp:Label></h4>
                                <img class="img-fluid w-100 d-block imagenes" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" alt="Slide Image" style="margin: auto; max-height: 500px; min-height: 150px;">
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                </div>
                <div class="swiper-pagination"></div>
                <div class="swiper-button-prev"></div>
                <div class="swiper-button-next"></div>

            </div>
            <a class="btn btn-dark" role="button" href="VerMasServicios.aspx" id="btn_verserv" style="width: 150px; margin-top: 20px; margin-bottom: 10px;">Ver Más</a>
        </div>


    </section>







    <section class="text-center" id="Proyectos" style="margin-top: 100px;">
        <div class="container" style="max-width: 100vh;">
            <div class="text-center" style="width: 100%;"><span style="color: rgb(0,0,0); font-weight: bold; font-size: 35px;">Proyectos</span></div>
        </div>
        <div class="row clearmargin clearpadding row-image-txt" style="margin: auto; margin-top: 69px; max-width: 1000px;">
            <asp:Repeater runat="server" ID="repetidorPro1">
                <ItemTemplate>
                    <div class="col-xs-12 col-sm-6 col-md-6 clearmargin clearpadding col-sm-push-6">

                        <div></div>
                        <img class="img-fluid" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" style="max-height: 400px;" />

                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-sm-pull-6" style="padding: 20px;">
                        <h1>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreProyecto") %>'></asp:Label></h1>
                        <p>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("DescripcionPro") %>'></asp:Label>
                        </p>
                        <div style="text-align: center"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="row clearmargin clearpadding row-image-txt" style="max-width: 1000px; margin: auto;">
            <asp:Repeater runat="server" ID="repetidorPro2">
                <ItemTemplate>

                    <div class="col-xs-12 col-sm-6 col-md-6 col-sm-pull-6" style="padding: 20px;">
                        <h1>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreProyecto") %>'></asp:Label></h1>
                        <p>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("DescripcionPro") %>'></asp:Label>
                        </p>
                        <div style="text-align: center"></div>

                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 clearmargin clearpadding col-sm-push-6">

                        <div></div>
                        <img class="img-fluid" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" style="max-height: 400px;" />

                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
        <div class="row clearmargin clearpadding row-image-txt" style="max-width: 1000px; margin: auto;">
            <asp:Repeater runat="server" ID="repetidorPro3">
                <ItemTemplate>
                    <div class="col-xs-12 col-sm-6 col-md-6 clearmargin clearpadding col-sm-push-6">

                        <div></div>
                        <img class="img-fluid" src="data:image;base64,<%# Convert.ToBase64String((byte[])DataBinder.Eval(Container.DataItem,"Imagen"))%>" style="max-height: 400px;" />

                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6 col-sm-pull-6" style="padding: 20px;">
                        <h1>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("NombreProyecto") %>'></asp:Label></h1>
                        <p>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("DescripcionPro") %>'></asp:Label>
                        </p>
                        <div style="text-align: center"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <a class="btn btn-dark" role="button" href="VerMasProyectos.aspx" id="btn_verpro" style="width: 150px; margin-top: 40px;">Ver Más</a>
    </section>

    <div id="Contactanos" class="contact-clean" style="margin-top: 100px;">
        <form method="post" style="background-color: rgba(198,198,198,0);" runat="server">
            <h2 class="text-center" style="color: rgb(255,255,255);">CONTÁCTANOS</h2>
            <div class="form-group">
                <asp:TextBox runat="server" class="form-control" type="text" required="" ID="txt_nombre" placeholder="Nombre" Style="font-weight: bold;" />
            </div>
            <div class="form-group">
                <asp:TextBox runat="server" class="form-control" type="email" required="" ID="txt_correo" placeholder="Email" Style="font-weight: bold;" />
            </div>
            <div class="form-group">
                <asp:TextBox runat="server" class="form-control" TextMode="MultiLine" required="" ID="txt_mensaje" placeholder="Mensaje" Style="font-weight: bold;" />
            </div>
            <div class="form-group text-center">
                <asp:Button runat="server" class="btn btn-warning" type="submit" ID="btn_enviar" Text="Enviar" Style="background-color: #000000; color: #fff;" OnClick="btn_enviar_Click" />

            </div>
        </form>
    </div>

    <footer style="color: white; background-color: #212529;">
        <div class="container">
            <div class="row text-center">
                <div class="col-md">
                    <a href="Login.aspx">
                        <img id="iconousuario" class="img-fluid" src="assets/img/usericon2.png" style="width: 80px; height: 100px;" /></a>
                </div>
            </div>
        </div>
    </footer>







    <script src="assetsInicioUsuario/js/jquery.min.js"></script>
    <script src="assetsInicioUsuario/bootstrap/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/lightbox2/2.8.2/js/lightbox.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Swiper/3.3.1/js/swiper.jquery.min.js"></script>
    <script src="assets/js/Simple-Slider.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.4.1/jquery.easing.min.js"></script>
    <script src="assets/js/agency.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>

    <link rel="stylesheet" href="https://unpkg.com/@bootstrapstudio/bootstrap-better-nav/dist/bootstrap-better-nav.min.css">
</body>

</html>
