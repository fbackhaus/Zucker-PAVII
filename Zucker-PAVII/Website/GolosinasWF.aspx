<%@ Page Title="Golosinas" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GolosinasWF.aspx.cs" Inherits="GolosinasWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">

    <div class="form-group">
        <label for="txtIdGolosina">Id</label>
        <asp:TextBox runat="server" ID="txtIdGolosina" TextMode="Number" CssClass="form-control" Enabled="false"></asp:TextBox>
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
        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" placeholder="Ingrese Descripcion"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="ddlMarca">Marca</label>
        <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rfvMarca" CssClass="form-control" InitialValue="-1" Display="Dynamic"
            ValidationGroup="A" ControlToValidate="ddlMarca" Text="*" ErrorMessage="Por favor seleccione la Marca de la golosina"></asp:RequiredFieldValidator>
    </div>
        <div class="form-group">
        <label for="ddlTipo">Tipo de Golosina</label>
        <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rfvTipo" CssClass="form-control" InitialValue="-1" Display="Dynamic"
            ValidationGroup="A" ControlToValidate="ddlTipo" Text="*" ErrorMessage="Por favor seleccione el tipo de la golosina"></asp:RequiredFieldValidator>
    </div>
    
    <div class="form-group">
        <label for="txtCodigoProducto">Codigo Producto</label>
        <asp:TextBox runat="server" ID="txtCodigoProducto" TextMode="Number" CssClass="form-control" placeholder="Ingrese Codigo del Producto"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCodigoProducto" ControlToValidate="txtCodigoProducto" runat="server"
            ErrorMessage="Por favor ingrese el Codigo del Producto" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtStock">Stock</label>
        <asp:TextBox runat="server" ID="txtStock" TextMode="Number" CssClass="form-control" placeholder="Ingrese stock"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvStock" ControlToValidate="txtStock" runat="server"
            ErrorMessage="Por favor ingrese el stock inicial" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtPrecioVta">Precio de Venta</label>
        <asp:TextBox runat="server" ID="txtPrecioVta" TextMode="Number" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPrecioVta" ControlToValidate="txtPrecioVta" runat="server"
            ErrorMessage="Por favor ingrese el Precio de Venta" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
    <div class="checkbox">
        <label>
            <asp:CheckBox runat="server" ID="chkEsPropia" Text="Propia" CssClass="form-control" />
        </label>
    </div>
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click" ValidationGroup="A" />
    <asp:Button ID="btnNuevo" runat="server" text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" ValidationGroup="B" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" ValidationGroup="A" />
</asp:Content>

