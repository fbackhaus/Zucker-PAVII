<%@ Page Language="C#" AutoEventWireup="true" 
    MasterPageFile="~/MasterPage.master" CodeFile ="ClienteWF.aspx.cs" Inherits="ClienteWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cliente</title>
</asp:Content> 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!--<div class="form-group">
        <label for="txtIdCliente">(*)ID: </label>
        <asp:TextBox runat="server" Enabled="false" ID="txtIdCliente" TextMode="Number" CssClass="form-control"></asp:TextBox>
       
    </div> -->
    
    <div class="form-group">
        <label for="txtRazonSocial"> (*)RAZON SOCIAL: </label>
        <asp:TextBox runat="server" ID="txtRazonSocial" CssClass="form-control"  MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvRazonSocial" runat="server" ControlToValidate="txtRazonSocial" ErrorMessage="Por favor, ingrese la Razon Social" Text="(!!!)" ValidationGroup="A" SetFocusOnError="True" />
    </div>
    
    <div class="form-group">
        <label for="txtCUIT"> (*)CUIT: </label>
        <asp:TextBox runat="server" ID="txtCUIT" CssClass="form-control" placeholder="__-__.___.___-_" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCUIT" runat="server" ControlToValidate="txtCUIT" ErrorMessage="Por favor, ingrese un CUIT" Text="(!!!)" ValidationGroup="A" SetFocusOnError="True" />
        <asp:RegularExpressionValidator ID="revCUIT" runat="server" ControlToValidate="txtCUIT" ErrorMessage="CUIT Inválido" Text="!!!" ValidationGroup="A" ValidationExpression="\d{2}-\d{8}-\d{1}" SetFocusOnError="True" />
    </div>

    <div class="form-group">
        <label>DOMICILIO</label>
         <br />
        
        <label for="txtCalle"> (*)CALLE: </label>
        <asp:TextBox runat="server" ID="txtCalle" CssClass="form-control" MaxLength="50" Width="300px" Rows="3"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCalle" runat="server" ControlToValidate="txtCalle" ErrorMessage="Por favor, ingrese una calle" Text="!!!" ValidationGroup="A" SetFocusOnError="True" />
        <!-- FALTAN Nº, Piso (no obligatorio), Dpto (no obligatorio), Cód Postal, Localidad(uso FK)-->
         <br />
        <label for="txtNro"> (*)Nº: </label>
        <asp:TextBox runat="server" ID="txtNro" CssClass="form-control" TextMode="Number" placeholder="Ingrese el numero del domicilio" MaxLength="4" Width="134px" Rows="3"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNro" runat="server" ControlToValidate="txtNro" ErrorMessage="Por favor, ingrese una calle" Text="(!!!)" ValidationGroup="A" SetFocusOnError="True" />
        <asp:RangeValidator ID="rvNro" runat="server" ControlToValidate="txtNro" Type="Integer" MaximumValue="9999" MinimumValue="1" ErrorMessage="Ingrese numero de domicilio" ValidationGroup="A" SetFocusOnError="True" />
         <br />
        <label for="txtPiso"> PISO: </label>
        <asp:TextBox runat="server" ID="txtPiso" CssClass="form-control" TextMode="Number" placeholder="Ingrese el Piso del edificio" MaxLength="3" Width="134px" Rows="3"></asp:TextBox>
         <br />
        <label for="txtDpto"> DPTO: </label>
        <asp:TextBox runat="server" ID="txtDpto" CssClass="form-control" placeholder="Ingrese el Numero del departamento" MaxLength="3" Width="134px" Rows="3"></asp:TextBox>
         <br />
        <label for="txtPiso"> (*)CP: </label>
        <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" TextMode="Number" placeholder="Ingrese Codigo Postal" MaxLength="5" Width="134px" Rows="3"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCP" runat="server" ControlToValidate="txtCP" ErrorMessage="Por favor, ingrese un CP" Text="(!!!)" ValidationGroup="A" SetFocusOnError="True" />
         <br />
        <label for =" ddlLocalidad">(*)LOCALIDAD: </label>
        <asp:DropDownList ID="ddlLocalidad" runat="server" CssClass="form-control" ></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="rfvLocalidad" CssClass="form-control" InitialValue="-1" Display="Dynamic" ValidationGroup="A" ControlToValidate="ddlLocalidad" Text="!!!" ErrorMessage="Por favor, seleccione una Localidad" SetFocusOnError="True"></asp:RequiredFieldValidator> 

        
    </div>

    <div class="form-group">
        <label for="txtTelefono"> (*)TELEFONO: </label>
        <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" TextMode="Phone"  placeholder="Ingrese el numero de telefono fijo" MaxLength="12"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvTelefono" ControlToValidate="txtTelefono" ErrorMessage="Por favor, ingrese un numero de telefono" Text="(!!!)" ValidationGroup="A" SetFocusOnError="True" />
        <asp:RegularExpressionValidator ID="revTelefono" runat="server"  ControlToValidate="txtTelefono"   ErrorMessage="Telefono Inválido" Text="!!!" ValidationGroup="A" ValidationExpression="^\d{4}-\d{7}$" SetFocusOnError="True"/>
        <!-- FALTA CAMBIAR EL FORMATO DEL TELEFONO -->
    </div>

    <div class="form-group">
        <label for="txtEmail"> (*)E-MAIL: </label>
        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Ingrese e-mail" MaxLength="25" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" ErrorMessage="Ingrese e-mail" SetFocusOnError="true" text="!!!" ValidationGroup="A" />
        <asp:RegularExpressionValidator runat="server" ID="revEmail" ControlToValidate="txtEmail" ErrorMessage="E-mail invalido" Text="(!!!)" ValidationGroup="A" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"  SetFocusOnError="True" />
        <!-- TRATAR DE HACER UN DROPDOWNLIST CON LOS @hotmail.com @yahoo.com.ar @gmail.com etc -->
    </div>
     
    <div class="form-group">
        <label for="txtFechaFundacion"> (*)FECHA DE FUNDACION: </label>
        <asp:TextBox runat="server" ID="txtFechaFundacion" CssClass="form-control" placeholder="Seleccione una fecha de fundacion (dd/mm/aa)" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvFechaFundacion" ControlToValidate="txtFechaFundacion" ErrorMessage="Ingrese fecha" SetFocusOnError="true" text="(!!!)" ValidationGroup="A" />
        <asp:RangeValidator runat="server" ID="rvFechafundacion" Type="Date" ControlToValidate="txtFechaFundacion" ErrorMessage="Fecha Incorrecta" MinimumValue="1700-01-01" MaximumValue="2016-06-15"  SetFocusOnError="true" Text="(!!!)" ValidationGroup="A" />
        <!-- Aparece el calendario -->
    </div>
 
    <!-- NUMERO DE CUENTA(usa FK) -->
    <div class="form-group">
        <label for="txtNroCuenta">(*)NUEVO NUMERO DE CUENTA: </label>
        <asp:TextBox runat="server" ID="txtNroCuenta" CssClass="form-control" placeholder="Ingrese nro de Cuenta" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvNroCuenta" ControlToValidate="txtNroCuenta" ErrorMessage="Ingrese Cuenta" SetFocusOnError="true" text="!!!" ValidationGroup="A" />
    </div>

    <div class="form-group">
        <label>
            <asp:CheckBox ID="cbPrimeraCompra" runat="server" Text="¿Es la primera vez que compra?" />
        </label>
    </div>

    <div class="form-group">
        <asp:ValidationSummary ID="vsResumen" runat="server" ValidationGroup="A" />
    </div>
    <br />
    <br />
    <div class="form-group" style="text-align:center">
    <asp:Button ID="btnGuardar" runat="server" Cssclass="btn btn-success" Text="GUARDAR"  OnClick="btnGuardar_Click" ValidationGroup="A" />
    <asp:Button ID="btnNuevo" Text="LIMPIAR/NUEVO"  runat="server" Cssclass="btn btn-default" OnClick="btnNuevo_Click" ValidationGroup="B" />
    <asp:Button ID="btmEliminar" Text="BORRAR" runat="server" CssClass="btn btn-danger" OnClick= "btmEliminar_Click" ValidationGroup="A" OnClientClick="return confirm('¿Seguro desea borrar?');" />

    </div>
    <br />
    <br />

    <div class="grid" id="divGrilla" runat="server">
        <asp:GridView ID="gvClientes" AutoGenerateColumns="false" runat="server" CssClass="table table-hover table-bordered table-condensed" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged">
            <Columns>
                <asp:CommandField SelectText="SELECCIONAR" ShowSelectButton="true" />
                <asp:BoundField DataField="cuit" HeaderText="NRO. CUIT" />
                <asp:BoundField DataField="razon_social" HeaderText="RAZON SOCIAL" />
                <asp:BoundField DataField="nro_cuenta" HeaderText="NRO. CUENTA" />
                <asp:BoundField DataField="id_cliente" HeaderText="ID CLIENTE" />
                <asp:BoundField DataField="nombreLocalidad" HeaderText="LOCALIDAD" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

