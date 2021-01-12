<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebMail.aspx.cs" Inherits="ProyectoFinal_HG.WebMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-5">
                    <asp:Label ID="Label1" runat="server" Text="Correo para confirmacion: "></asp:Label>
                    <asp:TextBox ID="txtTo" type="email" Class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="row">
                    <div class="col-md-5">
                        <asp:Button ID="btnEnviar" Class="btn-secondary" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
