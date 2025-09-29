using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        [DisplayName("Código")]
        public string CodArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public Marca Marca { get; set; }

        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public decimal Precio {  get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; } 

 
        public List<Imagen> Imagenes { get; set; }  

        public string PrecioFormateado
        {
            get { return Precio.ToString("N2"); }
        }

        public int IdMarca
        {
            get { return Marca != null ? Marca.IdMarca : 0; }
        }

        public int IdCategoria
        {
            get { return Categoria != null ? Categoria.IdCategoria : 0; }
        }


    }
}
