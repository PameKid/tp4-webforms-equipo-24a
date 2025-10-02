<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" MasterPageFile="~/Master.Master" Inherits="tp_webform_equipo_24A.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Ingresá tus datos</h2>
    <div class="row"></div>
        <div class="col-2"></div>
        <div class="col">
            
        <div class="form-group">
        <label for="txtDni">DNI</label>
        <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDni_TextChanged" />
        <asp:RegularExpressionValidator ErrorMessage="Solo numeros" ControlToValidate="txtDni" ValidationExpression="^[0-9]+$" runat="server" ForeColor="Red" Display="Dynamic"/>
    </div>

    <div class="form-group">
        <label for="txtNombre">Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        <asp:RegularExpressionValidator ErrorMessage="Solo letras permitidas" ControlToValidate="txtNombre" ValidationExpression="^[a-zA-Z]+$" runat="server" 
 ForeColor="Red" Display="Dynamic" />
    </div>

    <div class="form-group">
        <label for="txtApellido">Apellido</label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
        <asp:RegularExpressionValidator ErrorMessage="Solo letras permitidas" ControlToValidate="txtApellido" ValidationExpression="^[a-zA-Z]+$" runat="server" 
ForeColor="Red" Display="Dynamic" />
    </div>

    <div class="form-group">
        <label for="txtEmail">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" type="email" />
        <asp:RegularExpressionValidator ErrorMessage="Formato incorrecto" ControlToValidate="txtEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" runat="server" 
            ForeColor="Red" Display="Dynamic"/>
    </div>

    <div class="form-group">
        <label for="txtDireccion">Dirección</label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
        <asp:Label ID="lblDireccionError" runat="server" CssClass="error" Text="Falta dirección." Visible="false"></asp:Label>
        <asp:RegularExpressionValidator ErrorMessage="Formato incorrecto" ControlToValidate="txtDireccion" ValidationExpression="^[A-Za-záéíóúÁÉÍÓÚñÑ\s]+ \d{1,5}$" runat="server" 
    ForeColor="Red" Display="Dynamic"/>
    </div>

    <div class="form-group">
        <label for="txtCiudad">Ciudad</label>
        <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
        <asp:RegularExpressionValidator ErrorMessage="Formato incorrecto" ControlToValidate="txtCiudad" ValidationExpression="^[A-Za-záéíóúÁÉÍÓÚñÑ0-9\s]+$" runat="server" 
ForeColor="Red" Display="Dynamic"/>
    </div>

    <div class="form-group">
        <label for="txtCP">CP</label>
        <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" />
        <asp:RegularExpressionValidator ErrorMessage="Solo numeros" ControlToValidate="txtCP" ValidationExpression="^[0-9]+$" runat="server" ForeColor="Red" Display="Dynamic"/>
    </div>

    <div class="form-group">
        <asp:CheckBox ID="chkAcepto" runat="server" Text="Acepto los términos y condiciones." />
    </div>

    <div class="form-group">
    <asp:Button ID="btnAceptar" runat="server" OnClick="btnParticipar_Click" Text="Participar!" CssClass="btn btn-primary"/>
    </div>

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />


        </div>
        <div class="col-2"></div>



    
</asp:Content>