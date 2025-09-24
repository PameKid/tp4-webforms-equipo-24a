using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Voucher
    {
        public int IdVoucher { get; set; }

        public string CodigoVoucher {  get; set; }


        public DateTime DFechaCanje{ get; set; }


        public int IDArticulo {  get; set; }
    }
}
