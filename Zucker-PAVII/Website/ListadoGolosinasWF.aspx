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
    <div class="form-group">
        <label for="txtGolABuscar">Nombre de La Golosina:</label>
        <asp:TextBox runat="server" ID="txtGolABuscar" CssClass="form-control" placeholder="Ingrese Nombre de la Golosina"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-warning" OnClick="btnBuscar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-default" OnClick="btnLimpiar_Click"  />
        <asp:Label ID="lblGolNoEncontrada" Text="No se Encontro la Golosina Buscada" runat="server" Visible="false"></asp:Label>
    </div>
    <div class="form-group" id="divGrilla" runat="server">
        <asp:GridView ID="gvGolosinas" AutoGenerateColumns="False" runat="server" HeaderStyle-BackColor="LightGray" CssClass="table table-hover table-bordered table-condensed" BackColor="White">
            <Columns>
                <asp:BoundField DataField="nombreGol" HeaderText="Golosina" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad Producida" />

                
                
                
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

