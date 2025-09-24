<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" MasterPageFile="~/Master.Master" Inherits="tp_webform_equipo_24A.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Ingresá tus datos</h2>
    <div class="row"></div>
        <div class="col-2"></div>
        <div class="col">

        <div class="form-group">
        <label for="txtDni">DNI</label>
        <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtDni_TextChanged" />
    </div>

    <div class="form-group">
        <label for="txtNombre">Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label for="txtApellido">Apellido</label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label for="txtEmail">Email</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" type="email" />
    </div>

    <div class="form-group">
        <label for="txtDireccion">Dirección</label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
        <asp:Label ID="lblDireccionError" runat="server" CssClass="error" Text="Falta dirección." Visible="false"></asp:Label>
    </div>

    <div class="form-group">
        <label for="txtCiudad">Ciudad</label>
        <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
    </div>

    <div class="form-group">
        <label for="txtCP">CP</label>
        <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" />
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