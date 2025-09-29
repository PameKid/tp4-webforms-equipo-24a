using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Imagen
    {
       public int IDimagen { get; set; }
       public int NumeroArticulo {  get; set; }
       public string UrlImagen { get; set; }
    }
}
