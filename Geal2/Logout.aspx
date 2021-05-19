<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="Geal2.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script language="javascript" type="text/javascript">
     javascript:window.history.forward(1);
     </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Logout</title>
    <link href="css/EstiloLogout.css" rel="stylesheet" />
     <style type="text/css">
         .auto-style1 {
             width: 500px;
             height: 120px;
         }
     </style>
</head>
<body>
     <form id="form1" runat="server" style="text-align:center; margin-top:200px;" >
   <div>
        <asp:Label ID="Label1" runat="server" Text="Sesión cerrada con éxito. " ForeColor="White" Font-Size="Large"></asp:Label>
       <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx" ForeColor="White"> Espere 5 segundos. Si no redirige a Login, haga click AQUI.</asp:HyperLink>
    </div>
    </form>
</body>
</html>
