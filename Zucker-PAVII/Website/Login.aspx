<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <h1 style="text-align:center">Bienvenido a Distribuidora Zucker<asp:Label runat="server" id="lblUsuario"></asp:Label>!</h1>
    <div class="col-md-4"></div>
    <br />
    <br />
    <div style="position:center" class="col-md-4" runat="server" id="divLogin">
    <label>Usuario</label>
    <asp:TextBox CssClass="form-control" ID="txtUsuario" runat="server"></asp:TextBox>
    <br />
    <label>Clave</label>
    <asp:TextBox CssClass="form-control" ID="txtClave" textmode="Password" runat="server"></asp:TextBox>
    <br />
    <asp:Button CssClass="btn btn-success" ID="btnLogin" runat="Server" Text="Iniciar sesión" OnClick="btnLogin_Click" />
        </div>
    <div class="col-md-4"></div>
</asp:Content>

