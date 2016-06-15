<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoGolosinasWF.aspx.cs" Inherits="ListadoGolosinasWF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Listado de  Golosinas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <h1 style="text-align: center">Listado de Golosinas</h1>
    <div class="form-group">
        <label for="ddlMarca">Marca</label>
        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" runat="server" ID="ddlMarca" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="ddlTipo">Tipo de Golosina</label>
        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" runat="server" ID="ddlTipo" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="ddlPropia">Es Propia?</label>
            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlEsPropia_SelectedIndexChanged" runat="server" ID="ddlEsPropia" CssClass="form-control" />
    </div>
    <div class="form-group" id="divGrilla" runat="server">
        <asp:GridView ID="gvGolosinas" AutoGenerateColumns="False" runat="server" HeaderStyle-BackColor="LightGray" CssClass="table table-hover table-bordered table-condensed" BackColor="White">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="NombreMarca" HeaderText="Marca" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                <asp:BoundField DataField="NombreTipoGolosina" HeaderText="Tipo de Golosina" />
                <asp:BoundField DataField="Precio_Vta" HeaderText="Precio de Venta" />
                <asp:BoundField DataField="NombreEsPropia" HeaderText="Es Propia?" />
                <asp:BoundField DataField="Codigo_Producto" HeaderText="Codigo del Producto" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

