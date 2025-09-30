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
       
        public List<Articulo> listaProducto;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            if (!IsPostBack)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Articulo articulo = new Articulo();

                listaProducto = articuloNegocio.listarArticulos();
                repRepetidor.DataSource = listaProducto;
                repRepetidor.DataBind();
                repRepetidor.ItemDataBound += RepeaterProducto_ItemDataBound;
            }
        }

        protected void RepeaterProducto_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Articulo articulo = (Articulo)e.Item.DataItem;

                Repeater rptImagenes = (Repeater)e.Item.FindControl("RepeaterImagen");
                if (rptImagenes != null && articulo.Imagenes != null)
                {
                    rptImagenes.DataSource = articulo.Imagenes;
                    rptImagenes.DataBind();
                }
            }
        }

        protected void elijoEste_Click(object sender, EventArgs e)
        {
            string codigo = string.Empty;   

            // Recupero el codigo del voucher de la pagina anterior
            if (Request.QueryString["codigo"] != null)
            {
                 codigo = Request.QueryString["codigo"].ToString();
            }
            else
            {
                Response.Redirect("PaginaError.aspx");

            }

            string valor = ((Button)sender).CommandArgument;
            Session.Add("idArticulo", valor);
            Session["codigo"] = codigo;
            Response.Redirect("Formulario.aspx", false);

        }
    }
}
       
            
    
