<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="SeleccionarProducto.aspx.cs" Inherits="tp_webform_equipo_24A.SeleccionarProducto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
    .btn-elegir {
        font-size: 0.85rem;
        padding: 6px 14px;
        width: auto;
        display: block;
        margin: 8px auto;
    }
</style>

    <h1>Productos</h1>

    <div class="row">

        <div class="col">
            <asp:Repeater ID="repRepetidor" runat="server" OnItemDataBound="RepeaterProducto_ItemDataBound">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("NombreArticulo") %></h5>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <p class="card-text"><strong>Precio: $ <%# Eval("Precio") %></strong></p>
                            </div>
                            <div id='carousel_<%# Eval("Id") %>' class="carousel slide carousel-fade">
                                <div class="carousel-inner">
                                    <asp:Repeater runat="server" ID="RepeaterImagen">
                                        <ItemTemplate>
                                            <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                                <asp:Image ID="Image" runat="server" CssClass="d-block w-100 img-carousel"
                                                    ImageUrl='<%#Eval("UrlImagen")%>' Style="max-height: 300px; object-fit: contain;" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <button class="carousel-control-prev" type="button" data-bs-target='#carousel_<%# Eval("Id") %>' data-bs-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Anterior</span>
                                </button>
                                <button class="carousel-control-next" type="button" data-bs-target='#carousel_<%# Eval("Id") %>' data-bs-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="visually-hidden">Siguiente</span>
                                </button>
                            </div>

                            <p></p>
                            <asp:Button
                                CssClass="btn btn-primary btn-elegir"
                                Text="Elijo este"
                                runat="server"
                                CommandArgument='<%#Eval("Id")%>'
                                CommandName="articuloId"
                                OnClick="elijoEste_Click"
                                ID="elijoEste" />
                        </div>
                    </div>
                    <br>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>




</asp:Content>
