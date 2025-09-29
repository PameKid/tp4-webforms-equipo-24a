using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar(int idProducto) { 

        AccesoDatos accesoDatos = new AccesoDatos();
        List<Imagen> listaImagenes = new List<Imagen>();

            try
            {
                accesoDatos.setearConsulta ("select I.Id, IdArticulo, I.ImagenUrl from IMAGENES I where IdArticulo = @id");
                accesoDatos.setearParametro("@id", idProducto);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read()) {
                    Imagen imagenAuxiliar = new Imagen();

                    imagenAuxiliar.IDimagen = (int)accesoDatos.Lector["Id"];
                    imagenAuxiliar.NumeroArticulo = (int)accesoDatos.Lector["IdArticulo"];
                    imagenAuxiliar.UrlImagen = (string)accesoDatos.Lector["ImagenUrl"];

                    listaImagenes.Add(imagenAuxiliar);
                    
                }
                return listaImagenes;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        public void Agregar(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Imagenes (IdArticulo, ImagenURL) values (@Id,@url)");
                datos.setearParametro("@Id", imagen.NumeroArticulo);
                datos.setearParametro("@url", imagen.UrlImagen);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Eliminar(int idImagen)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {

                accesoDatos.setearConsulta("Delete from Imagenes where Id = @id");
                accesoDatos.setearParametro("@id", idImagen);
                accesoDatos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
