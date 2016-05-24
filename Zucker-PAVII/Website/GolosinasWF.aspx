<%@ Page Title="Golosinas" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GolosinasWF.aspx.cs" Inherits="GolosinasWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <div class="form-group">
        <label for="txtIdGolosina">Id</label>
        <asp:TextBox runat="server" ID="txtIdGolosina" TextMode="Number" CssClass="form-control" placeholder="Ingrese id de la golosina"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvIdGolosina" ControlToValidate="txtIdGolosina" runat="server"
            ErrorMessage="Por favor ingrese un id de golosina" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtNombre">Nombre</label>
        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese nombre de la golosina"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" ControlToValidate="txtNombre" runat="server"
            ErrorMessage="Por favor ingrese el nombre de la golosina" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtDescripcion">Descripcion (Opcional)</label>
        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" placeholder="Ingrese Descripcion"></asp:TextBox>
    </div>
</asp:Content>

