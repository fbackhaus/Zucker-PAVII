<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ListadoDeEmpleados.aspx.cs" Inherits="ListadoDeEmpleados" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Listado de  Empleados</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <h1 style="text-align: center">Listado de Empleados</h1>
   
    <div class="form-group">
        <label for="ddlCargo">Cargo</label>
        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlCargo_SelectedIndexChanged" runat="server" ID="ddlCargo" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="ddlPedidos">Puede realizar pedidos?</label>
            <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlPedidos_SelectedIndexChanged" runat="server" ID="ddlPedidos" CssClass="form-control"></asp:DropDownList> 
    </div>
    <div class="form-group" id="divGrilla" runat="server">
        <asp:GridView ID="gvEmpleados" AutoGenerateColumns="False" runat="server" CssClass="table table-striped table-bordered table-condensed">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="numeroDNI" HeaderText="DNI" />
                <asp:BoundField DataField="nombreCargo" HeaderText="Cargo" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                <asp:BoundField DataField="nombrePedido" HeaderText="Puede realizar pedidos?" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>