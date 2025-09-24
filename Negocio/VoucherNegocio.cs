using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VoucherNegocio
    {
        public bool Estado()
        {
            return false;
        }

        public bool consultarVoucherDisponible(string codigoVoucher)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();

                datos.setearConsulta("select CodigoVoucher from Vouchers where CodigoVoucher = @cv and IdCliente is null ");
                datos.setearParametro("@cv", codigoVoucher);
                datos.ejecutarLectura();


                //si devuelve true es porque existe en la base de datos y tiene usuario null 
                if (datos.Lector.Read() == true)
                {
                    return true;
                }
                
                else { return false; }
            }
            catch (Exception ex)
            {

                throw ex ;
            }
            
        }
    }
}
