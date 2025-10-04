<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CanjearVoucher.aspx.cs" Inherits="tp_webform_equipo_24A.CanjearVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <h1>Portal de canje de Voucher</h1>
    <div class="row">
        <div class="col-4">

            <div class="mb-3">
                <label class="form-label">Código de Voucher</label>
                <asp:TextBox ID="txtVoucher" class="form-control" runat="server"></asp:TextBox>
            </div>


            <asp:Button ID="btnCanjear" class="btn btn-primary" OnClick="btnCanjear_Click" runat="server" Text="Canjear" />

        </div>
    </div>

</asp:Content>
