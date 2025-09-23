using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;


namespace Negocio

{
    public class CategoriaNegocio
    {

        public List<Categoria> Listar()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion From Categorias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria catAuxiliar = new Categoria();
                    catAuxiliar.IdCategoria = (int)datos.Lector["Id"];
                    catAuxiliar.Descripcion = (string)datos.Lector["Descripcion"];

                    listaCategorias.Add(catAuxiliar);

                }

                return listaCategorias;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Agregar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Categorias (Descripcion) values (@desc)");
                datos.setearParametro("@desc", categoria.Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
           
        }


        public void Modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Categorias set Descripcion = @desc where ID = @id");
                datos.setearParametro("@desc", categoria.Descripcion);
                datos.setearParametro("@id", categoria.IdCategoria);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Eliminar (int idCategoria)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                
                accesoDatos.setearConsulta("Delete from Categorias where Id = @id");
                accesoDatos.setearParametro("@id", idCategoria);
                accesoDatos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
