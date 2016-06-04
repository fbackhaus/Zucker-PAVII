﻿<%@ Page Title="Empleados" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmpleadosWF.aspx.cs" Inherits="EmpleadosWF" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">

     <div class="form-group">
        <label for="txtIdEmpleado">Id</label>
        <asp:TextBox runat="server" ID="txtIdEmpleado" TextMode="Number" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvIdEmpleado" ControlToValidate="txtIdEmpleado" runat="server"
            ErrorMessage="Por favor ingrese un ID de Empleado" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
    <div class="form-group">
        <label for="txtNombre">Nombre</label>
        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" placeholder="Ingrese nombre del empleado"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNombre" ControlToValidate="txtNombre" runat="server"
            ErrorMessage="Por favor ingrese el nombre del empleado" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
     <div class="form-group">
        <label for="lblApellido">Apellido</label>
        <asp:TextBox runat="server" ID="txtApellido"  CssClass="form-control" placeholder="Ingrese el apellido del empleado"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtApellido" runat="server"
            ErrorMessage="Por favor ingrese el apellido del empleado" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
     <div class="form-group">
        <label for="lblfechaNac">Fecha de nacimiento</label>
        <asp:TextBox runat="server" ID="txtFechaNac" TextMode="Date" CssClass="form-control" placeholder="Ingrese la fecha de nacimiento del empleado"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtFechaNac" runat="server"
            ErrorMessage="Por favor ingrese la fecha de nacimiento del empleado" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
     <div class="form-group">
        <label for="lblDNI">Documento</label>
        <asp:TextBox runat="server" ID="txtDNI" TextMode="Number" CssClass="form-control" placeholder="Ingrese DNI del empleado"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtDNI" runat="server"
            ErrorMessage="Por favor ingrese el DNI del empleado" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
     <div class="form-group">
        <label for="lblCargo">Cargo</label>
     <asp:DropDownList runat="server" ID="ddlCargo" CssClass="form-control" ></asp:DropDownList>
       </div>
     <div class="form-group">
        <label for="lblCuenta">N° Cuenta</label>
        <asp:TextBox runat="server" ID="txtCuenta" TextMode="Number" CssClass="form-control" placeholder="Ingrese numero de cuenta del empleado"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtCuenta" runat="server"
            ErrorMessage="Por favor ingrese el numero de cuenta del empleado" Text="*" ValidationGroup="A" ></asp:RequiredFieldValidator>
    </div>
    <div class="checkbox">
        <label>
            <asp:CheckBox runat="server" ID="chkPedidos" Text="Puede realizar Pedidos" CssClass="form-control" />
        </label>
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
        <asp:GridView ID="grdEmpleados" AutoGenerateColumns="False" runat="server" OnSelectedIndexChanged="grdEmpleados_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                <asp:BoundField DataField="Id_Empleado" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Fecha_Nacimiento" HeaderText="Fecha de Nacimiento" />
                <asp:BoundField DataField="DNI" HeaderText="DNI" />
                <asp:BoundField DataField="Id_Cargo" HeaderText="Cargo" />
                <asp:BoundField DataField="Puede_realidar_pedidos" HeaderText="Puede realizar pedidos?" />
              </Columns>
        </asp:GridView>

        </div>
    <div class="form-group" id="divExcepcion" runat="server" visible="false">
                        <label for="txtExcepcion">Por favor revise lo siguiente: </label>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="txtExcepcion" CssClass="form-control"></asp:TextBox>
                    </div>

  
    


    </asp:Content>