<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="LoteDeProduccionWF.aspx.cs" Inherits="LoteDeProduccionWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <h1 style="text-align: center; color:black;">Nuevo lote de producción</h1>

    <div class="form-group">
        <label for="txtNumLote">N° Lote</label>
        <asp:TextBox ID="txtNumLote" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLote" runat="server" ControlToValidate="txtNumLote" Text="*" ErrorMessage="Por favor ingrese N° de Lote"
          ValidationGroup="A"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <label for="txtFecha">Fecha de Producción</label>
        <asp:TextBox ID="txtFecha" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFecha" runat="server" ControlToValidate="txtFecha" Text="*" ErrorMessage="Por favor ingrese Fecha"
          ValidationGroup="A"></asp:RequiredFieldValidator>
    </div>

    <div class="form-group">
        <label for="txtGolosina">Buscar golosina:</label>
        <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" placeholder="Ingrese Nombre de la Golosina"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-warning" OnClick="btnBuscar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-default" OnClick="btnLimpiar_Click" />
        <asp:Label ID="lblNoEncontrada" Text="No se Encontro la golosina buscada" runat="server" Visible="false"></asp:Label>
        <h3 style="text-align:center; color:black">Golosinas propias: </h3>


        <asp:GridView runat="server" ID="gvGolosinas" AutoGenerateColumns="false" HeaderStyle-BackColor="LightGray" CssClass="table table-hover table-bordered table-condensed" BackColor="White" OnRowDataBound="gvGolosinas_RowDataBound" OnSelectedIndexChanged="gvGolosinas_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-success" SelectText="Agregar" ShowSelectButton="true"/>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="NombreMarca" HeaderText="Marca" />
                <asp:BoundField DataField="Stock" HeaderText="Stock Actual" />
                <asp:BoundField DataField="NombreTipoGolosina" HeaderText="Tipo de Golosina" />
                <asp:BoundField DataField="Precio_Vta" HeaderText="Precio de Venta" />
                <asp:BoundField DataField="NombreEsPropia" HeaderText="Es Propia?" />
                <asp:BoundField DataField="Codigo_Producto" HeaderText="Codigo del Producto" />
                <asp:TemplateField HeaderText="Cantidad" >
                    <ItemTemplate>
                     <asp:DropDownList runat="server" ID="ddlCantidad" CssClass="form-control" OnSelectedIndexChanged="ddlCantidad_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>   
            </Columns>
        </asp:GridView>
        
     
    </div>

    <div class="form-group">
        <h3 id="tituloMP" runat="server" visible="false" style="text-align:center; color:black">Golosinas a cargar</h3>
        <asp:GridView runat="server" ID="gvACargar" AutoGenerateColumns="false" HeaderStyle-BackColor="LightGray" CssClass="table table-hover table-bordered table-condensed" BackColor="White"  OnSelectedIndexChanged="gvACargar_SelectedIndexChanged" >
            <Columns>
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-danger" SelectText="Quitar" ShowSelectButton="true" />
                <asp:BoundField DataField="Id_golosina" HeaderText="Codigo del Producto" />
                <asp:BoundField DataField="NombreGol" HeaderText="Nombre" />
                <asp:BoundField DataField="Stock" HeaderText="Stock Futuro" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            </Columns>
        </asp:GridView>
        
    </div>
    <div class="form-group" style="text-align:center">
        <asp:Button ValidationGroup="A" CausesValidation="true" runat="server" ID="btnConfirmar" OnClick="btnConfirmar_Click" Text="Confirmar" CssClass="btn btn-success"/>
        <asp:Button ID="btnNuevo" runat="server" text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" />
    </div>
    <asp:ValidationSummary runat="server" ID="vsLote" ValidationGroup="A" />
  </asp:Content>

   
