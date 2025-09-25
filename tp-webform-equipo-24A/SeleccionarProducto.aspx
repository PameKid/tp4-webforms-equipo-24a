<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="SeleccionarProducto.aspx.cs" Inherits="tp_webform_equipo_24A.SeleccionarProducto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Hola</h1>
    
        <div>
            <asp:GridView  ID="dgvProducto" runat="server"></asp:GridView>
        </div>
       
    
</asp:Content>