using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_webform_equipo_24A
{
    public partial class SeleccionarProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            List<Articulo> listaProducto = articuloNegocio.listarArticulos();
            dgvProducto.DataSource = listaProducto;
            dgvProducto.DataBind();

        
    }
    }
}