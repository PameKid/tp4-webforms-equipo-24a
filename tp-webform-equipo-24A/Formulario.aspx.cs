using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_webform_equipo_24A
{
    public partial class Formulario : System.Web.UI.Page
    {
        public string IdArticulo { get; set; }
        public string codigo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            IdArticulo = Session["idArticulo"] != null ? Session["idArticulo"].ToString() : "";
            codigo = Session["codigo"] != null ? Session["codigo"].ToString() : "";
            if(!IsPostBack) {
                txtDni.Text = "Ingrese su DNI";
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            Cliente nuevo = new Cliente();  
            ClienteNegocio negocio = new ClienteNegocio();

            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtCP.Text) ||
                !chkAcepto.Checked)
            {
                lblMensaje.Text = "Todos los campos son obligatorios.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            nuevo.Documento = txtDni.Text;
            nuevo.Nombre = txtNombre.Text;  
            nuevo.Apellido = txtApellido.Text;
            nuevo.Email = txtEmail.Text;
            nuevo.Direccion = txtDireccion.Text;
            nuevo.Ciudad = txtCiudad.Text;
            nuevo.CP = txtCP.Text;

            negocio.Agregar(nuevo);
            string script = @"alert('REGISTRO EXITOSO.'); 
                          window.location='CanjearVoucher.aspx';";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            ClienteNegocio nuevo = new ClienteNegocio();
            Cliente cliente = new Cliente();    
            cliente.Documento = txtDni.Text;

            if (nuevo.ObtenerPorDNI(cliente))
            {
                // Cliente ya existe 
                string script = @"alert('El DNI ya está registrado.'); 
                          window.location='CanjearVoucher.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

            }
        }
    }
}