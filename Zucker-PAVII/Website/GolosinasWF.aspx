<%@ Page Title="Golosinas" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GolosinasWF.aspx.cs" Inherits="GolosinasWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Nueva Golosina</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <h1 style="text-align: center; color:black;">Registro de Nueva Golosina</h1>
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
        <asp:RequiredFieldValidator runat="server" ID="rfvMarca" CssClass="form-control" InitialValue="0" Display="Dynamic"
            ValidationGroup="A" ControlToValidate="ddlMarca" Text="*" ErrorMessage="Por favor seleccione la Marca de la golosina"></asp:RequiredFieldValidator>
    </div>
        <div class="form-group">
        <label for="ddlTipo">Tipo de Golosina</label>
        <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-control"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rfvTipo" CssClass="form-control" InitialValue="0" Display="Dynamic"
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
        <asp:CompareValidator ID="cvStock" runat="server" ControlToValidate="txtStock" Operator="GreaterThan" ValueToCompare="0" ValidationGroup="A"
             Text="*" ErrorMessage="El stock ingresado es invalido"></asp:CompareValidator>
    </div>
    <div class="form-group">
        <label for="txtPrecioVta">Precio de Venta</label>
        <asp:TextBox runat="server" ID="txtPrecioVta" TextMode="Number" CssClass="form-control" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPrecioVta" ControlToValidate="txtPrecioVta" runat="server"
            ErrorMessage="Por favor ingrese el Precio de Venta" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cvPrecio" ErrorMessage="El precio ingresado es invalido" Text="*" ValidationGroup="A" runat="server" ControlToValidate="txtPrecioVta" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
    </div>
    <div class="checkbox">
        <label>
            <asp:CheckBox runat="server" ID="chkEsPropia" Text="Propia" CssClass="form-control" />
        </label>
    </div>
    <div class="form-group">
        <asp:ValidationSummary ID="valResumen"
            runat="server" ValidationGroup="A" />
    </div>
    <div class="form-group" style="text-align:center">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click" ValidationGroup="A"/>
    <asp:Button ID="btnNuevo" runat="server" text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" ValidationGroup="B" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" ValidationGroup="A" OnClientClick="return confirm('Esta seguro que desea eliminar la golosina?');" />
    </div>
    <div class="form-group">
        <label for="txtGolABuscar">Nombre de La Golosina:</label>
        <asp:TextBox runat="server" ID="txtGolABuscar" CssClass="form-control" placeholder="Ingrese Nombre de la Golosina"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-warning" OnClick="btnBuscar_Click" />
    </div>
    <div class="grid" id="divGrilla" runat="server">
        <asp:GridView ID="gvGolosinas" AutoGenerateColumns="False" runat="server" HeaderStyle-BackColor="LightGray" CssClass="table table-hover table-bordered table-condensed" BackColor="White" OnSelectedIndexChanged="gvGolosinas_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-info" SelectText="Editar" ShowSelectButton="true" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="NombreMarca" HeaderText="Marca" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                <asp:BoundField DataField="NombreTipoGolosina" HeaderText="Tipo de Golosina" />
                <asp:BoundField DataField="Precio_Vta" HeaderText="Precio de Venta" />
                <asp:BoundField DataField="Es_Propia" HeaderText="Es Propia?" />
                <asp:BoundField DataField="Codigo_Producto" HeaderText="Codigo del Producto" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="form-group" id="divExcepcion" runat="server" visible="false">
                        <label for="txtExcepcion">Por favor revise lo siguiente: </label>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="txtExcepcion" CssClass="form-control"></asp:TextBox>
                    </div>

</asp:Content>

