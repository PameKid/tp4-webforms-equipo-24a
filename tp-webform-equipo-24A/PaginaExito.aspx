<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PaginaExito.aspx.cs" Inherits="tp_webform_equipo_24A.PaginaExito" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="text-center">


        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css">

            <div class="text-center">
                <i class="bi bi-check-circle-fill text-success" style="font-size: 5rem;"></i>
                <h2 class="mt-3 text-success">¡Registro correcto!</h2>
            </div>

        
    </div>




    <asp:Button ID="btnRegresar" class="btn btn-primary" OnClick="btnRegresar_Click"  runat="server" Text="Regresar" />

</asp:Content>
