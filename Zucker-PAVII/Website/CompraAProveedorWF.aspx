<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CompraAProveedorWF.aspx.cs" Inherits="CompraAProveedorWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <h1 style="text-align: center; color:black;">Nueva Compra a Proveedor</h1>
    <div class="form-group">
        <label for="txtFechaCompra">Fecha de Compra</label>
        <asp:TextBox ID="txtFechaCompra" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="ddlProveedor">Proveedor</label>
        <asp:DropDownList AutoPostBack="true" runat="server" ID="ddlProveedor" CssClass="form-control" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="txtMPABuscar">Nombre de La Materia Prima:</label>
        <asp:TextBox runat="server" ID="txtMPABuscar" CssClass="form-control" placeholder="Ingrese Nombre de la Materia Prima"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-default" OnClick="btnBuscar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-default" OnClick="btnLimpiar_Click" />
        <asp:Label ID="lblMPNoEncontrada" Text="No se Encontro la Materia Prima Buscada" runat="server" Visible="false"></asp:Label>
        <h3 style="text-align:center; color:black">Materias Primas del Proveedor</h3>
        <asp:GridView runat="server" ID="gvMateriasPrimas" AutoGenerateColumns="false" HeaderStyle-BackColor="LightGray" CssClass="table table-hover table-bordered table-condensed" BackColor="White" OnRowDataBound="gvMateriasPrimas_RowDataBound" OnSelectedIndexChanged="gvMateriasPrimas_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-success" SelectText="Agregar" ShowSelectButton="true"/>
                <asp:BoundField DataField="nombre_materia_prima" HeaderText="Materia Prima"/>
                <asp:BoundField DataField="codigo_mp" HeaderText="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="nombre_proveedor" HeaderText="Proveedor" />
                <asp:BoundField DataField="cuit" HeaderText="Cuit" />
                <asp:BoundField DataField="monto_unitario" HeaderText="Monto Unitario" />
                <asp:BoundField DataField="stock" HeaderText="Stock Actual" />
                <asp:TemplateField HeaderText="Cantidad" >
                    <ItemTemplate>
                     <asp:DropDownList runat="server" ID="ddlCantidad" CssClass="form-control" OnSelectedIndexChanged="ddlCantidad_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>   
            </Columns>
        </asp:GridView>
        
     
    </div>
    <div class="form-group">
        <h3 id="tituloMP" runat="server" visible="false" style="text-align:center; color:black">Materias Primas a Comprar</h3>
        <asp:GridView runat="server" ID="gvCompra" AutoGenerateColumns="false" HeaderStyle-BackColor="LightGray" CssClass="table table-hover table-bordered table-condensed" BackColor="White"  OnSelectedIndexChanged="gvCompra_SelectedIndexChanged" >
            <Columns>
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" SelectText="Quitar" ShowSelectButton="true" />
                <asp:BoundField DataField="nombre_materia_prima" HeaderText="Materia Prima" />
                <asp:BoundField DataField="codigo_mp" HeaderText="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="nombre_proveedor" HeaderText="Proveedor" />
                <asp:BoundField DataField="cuit" HeaderText="Cuit" />
                <asp:BoundField DataField="monto_unitario" HeaderText="Monto Unitario" />
                <asp:BoundField DataField="stock" HeaderText="Stock Futuro" />
                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
            </Columns>
        </asp:GridView>
        <label for="txtMonto">Monto Total</label>
        <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
    </div>
    <div class="form-group" style="text-align:center">
        <asp:Button runat="server" ID="btnConfirmar" OnClick="btnConfirmar_Click" Text="Confirmar" CssClass="btn btn-success"/>
        <asp:Button ID="btnNuevo" runat="server" text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" />
    </div>
</asp:Content>

