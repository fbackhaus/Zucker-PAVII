<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ListadoClienteWF.aspx.cs" Inherits="ListadoClienteWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ListadosCliente</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <h1 style="text-align: center">LISTADO DE CLIENTES</h1>
    <div class="form-group">
        <label for="ddlLocalidad">LOCALIDAD</label>
        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlLocalidad_SelectedIndexChanged" runat="server" ID="ddlLocalidad" CssClass="form-control"></asp:DropDownList>
    </div>

    <div class="form-group">
        <label for="txtFechaFundacion">FECHA FUNDACION</label>
        <asp:TextBox TextMode="Date" runat="server" ID="txtFechaFundacion" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnFecha" runat="server" OnClick="btnFecha_Click" Text="Filtrar" />
    </div>
    
    
    <div class="form-group" id="divGrilla" runat="server">
        <asp:GridView ID="gvCliente" AutoGenerateColumns="False" runat="server" HeaderStyle-BackColor="LightGray" CssClass="table table-hover table-bordered table-condensed" BackColor="White">
            <Columns>
                <asp:BoundField DataField="cuit" HeaderText="CUIT" />
                <asp:BoundField DataField="razon_social" HeaderText="RAZON SOCIAL" />
                <asp:BoundField DataField="fecha_fundacion" HeaderText="FECHA DE FUNDACION" />
                <asp:BoundField DataField="email" HeaderText="EMAIL" />
                <asp:BoundField DataField="telefono" HeaderText="TELEFONO" />
                <asp:BoundField DataField="calle" HeaderText="CALLE" />
                <asp:BoundField DataField="numero" HeaderText="NUMERO" />
                <asp:BoundField DataField="piso" HeaderText="PISO" />
                <asp:BoundField DataField="nombreLocalidad" HeaderText="LOCALIDAD" />
                <asp:BoundField DataField="codigo_postal" HeaderText="CODIGO POSTAL" />
                <asp:BoundField DataField="nro_cuenta" HeaderText="CUENTA" />
                <asp:BoundField DataField="es_primera_vez" HeaderText="ES PRIMERA VEZ" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>