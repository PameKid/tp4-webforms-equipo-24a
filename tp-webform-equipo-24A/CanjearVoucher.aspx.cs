using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace tp_webform_equipo_24A
{
    public partial class CanjearVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCanjear_Click(object sender, EventArgs e)
        {
            string codigo = txtVoucher.Text;
            VoucherNegocio voucher = new VoucherNegocio();
           
            bool disponible = voucher.consultarVoucherDisponible(codigo);

            if(disponible == true)
            {
                Response.Redirect("paginasiguientePris");
            }

            else { Response.Redirect("paginaerror");
            }
        }
    }
}