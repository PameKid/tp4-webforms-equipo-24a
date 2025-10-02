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
            Response.Write("idArticulo: " + Session["idArticulo"] + "<br>");
            Response.Write("codigo: " + Session["codigo"]);
            if (!IsPostBack)
            {
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

            if (string.IsNullOrWhiteSpace(codigo) || string.IsNullOrWhiteSpace(IdArticulo))
            {
                string script2 = @"alert('Te falta el voucher o seleccionar articulo.'); 
                          window.location='CanjearVoucher.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script2, true);
            }

            negocio.Agregar(nuevo, codigo, IdArticulo);
            string script = @"alert('REGISTRO EXITOSO.'); 
                          window.location='CanjearVoucher.aspx';";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            // Si borraron el DNI limpiamos los campos y volvemos a activar botones
            if (string.IsNullOrEmpty(dni))
            {
                LimpiarCampos();
            }

            ClienteNegocio nuevo = new ClienteNegocio();
            Cliente cliente = new Cliente();
            cliente.Documento = txtDni.Text;

            if (nuevo.ObtenerPorDNI(cliente))
            {
                // Cliente ya existe 
                //string script = @"alert('El DNI ya está registrado.'); 
                //          window.location='CanjearVoucher.aspx';";
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.CP;

                DeshabilitarCampos();

            }
            else
            {
                LimpiarCampos();
                HabilitarCampos();
            }


        }

        protected void LimpiarCampos()
        {
            TextBox[] campos = { txtNombre, txtApellido, txtEmail, txtDireccion, txtCiudad, txtCP };

            foreach (var campo in campos)
            {
                campo.Text = "";
                campo.Enabled = true;
            }

            btnAceptar.Enabled = true;
            chkAcepto.Enabled = true;
            lblMensaje.Text = "";
            return;
        }

        protected void DeshabilitarCampos()
        {
            // Deshabilitamos campos para que no puedan ingresar datos
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtEmail.Enabled = false;
            txtDireccion.Enabled = false;
            txtCiudad.Enabled = false;
            txtCP.Enabled = false;

            // Deshabilitamos los botones
            btnAceptar.Enabled = false;
            chkAcepto.Enabled = false;
        }

        protected void HabilitarCampos()
        {
            // habilitamos campos para que puedan ingresar datos
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtEmail.Enabled = true;
            txtDireccion.Enabled = true;
            txtCiudad.Enabled = true;
            txtCP.Enabled = true;

            // habilitamos los botones
            btnAceptar.Enabled = true;
            chkAcepto.Enabled = true;
        }
    }
}