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
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) {
                txtDni.Text = "Ingrese su DNI";
            }
        }

        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            cliente nuevo = new cliente();  
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
           

            if (nuevo.ObtenerPorDNI(dni))
            {
                // Cliente ya existe 
                string script = @"alert('El DNI ya está registrado.'); 
                          window.location='CanjearVoucher.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

            }
        }
    }
}