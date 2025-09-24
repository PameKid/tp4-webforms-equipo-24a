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

                return true;
            }
            catch (Exception ex)
            {

                throw ex ;
            }
            
        }
    }
}
