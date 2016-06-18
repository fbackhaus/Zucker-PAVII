<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="LoteDeProduccionWF.aspx.cs" Inherits="LoteDeProduccionWF" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Registrar Lote de Produccion</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">
    <h1 style="text-align: center">Registro de Empleados</h1>
     
    <div class="form-group">
        <label for="txtNumero">Numero de Lote</label>
        <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" placeholder="Ingrese numero de lote de produccion"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNumero" ControlToValidate="txtNumero" runat="server"
            ErrorMessage="Por favor ingrese el numero de lote de produccion" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
     
     <div class="form-group">
        <label for="txtFecha">Fecha de nacimiento</label>
        <asp:TextBox runat="server" ID="txtFecha" TextMode="Date" CssClass="form-control" placeholder="Ingrese la fecha de produccion"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFecha" ControlToValidate="txtFecha" runat="server"
            ErrorMessage="Por favor ingrese la fecha de produccion" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>

    </div>
    
     <div class="form-group">
        <label for="ddlEmpleado">Cargo</label>
     <asp:DropDownList runat="server" ID="ddlEmpleado" OnSelectedIndexChanged="ddlEmpleado_SelectedIndexChanged" CssClass="form-control" ></asp:DropDownList>
       </div>
     
   
      <div class="form-group">
        <asp:ValidationSummary ID="valResumen"
            runat="server" ValidationGroup="A" />
    </div>

     <div class="form-group" style="text-align:center">
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-success" OnClick="btnGuardar_Click" ValidationGroup="A" />
    <asp:Button ID="btnNuevo" runat="server" text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" ValidationGroup="B" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" ValidationGroup="A" />
    </div>

   <div class="form-group" id="divGrilla" runat="server">
        
        <asp:GridView ID="gvLotes" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanged="gvLotes_SelectedIndexChanged" CssClass="table table-striped table-bordered table-condensed">
            <Columns>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                <asp:BoundField DataField="Numero" HeaderText="Codigo de Lote" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha de Produccion" />
                <asp:BoundField DataField="Empleado" HeaderText="Empleado" />
               
            </Columns>
        </asp:GridView>

        </div>
    <div class="form-group" id="divExcepcion" runat="server" visible="false">
                        <label for="txtExcepcion">Por favor revise lo siguiente: </label>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="txtExcepcion" CssClass="form-control"></asp:TextBox>
                    </div>

 
    </asp:Content>
