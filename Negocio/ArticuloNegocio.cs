using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
     public class ArticuloNegocio
    {
        public List<Articulo> listarArticulos()
        { 
            List<Articulo> lista = new List<Articulo>();
            ImagenNegocio imgNeg = new ImagenNegocio();

            AccesoDatos datos = new AccesoDatos();

            try
            {

                //datos.setearConsulta("select * from Articulos a INNER JOIN IMAGENES I on a.Id=i.IdArticulo");
               datos.setearConsulta ("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion,  " +
                                      "m.Id AS IdMarca, m.Descripcion AS Marca," +
                                      " c.Id AS IdCategoria, c.Descripcion AS Categoria," +
                                      " a.Precio " +
                                      "FROM ARTICULOS a INNER JOIN MARCAS m ON a.IdMarca = m.Id INNER JOIN CATEGORIAS c ON a.IdCategoria = c.Id");
                
                   datos.ejecutarLectura();

                while (datos.Lector.Read()) 
                { 
                    Articulo articulo = new Articulo();
                    articulo.Marca = new Marca();
                    articulo.Categoria = new Categoria();

                    articulo.Id = datos.Lector.GetInt32(0);
                    articulo.NombreArticulo = datos.Lector["Nombre"].ToString();
                    articulo.Descripcion = datos.Lector["Descripcion"].ToString();
                    articulo.CodArticulo = datos.Lector["Codigo"].ToString();
                    articulo.Precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    articulo.Marca.Descripcion = datos.Lector["Marca"].ToString();
                    articulo.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    articulo.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = datos.Lector["Categoria"].ToString();

                    articulo.Imagenes = imgNeg.listar(articulo.Id);
                    

                    lista.Add(articulo);

                }
  
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
           
        }
        public void agregar (Articulo nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();

            try 
            {
                //Aca hago dos query, uno para insertar el articulo
                //En otro obtengo el MAX ID, osea teoricamente deberia ser el que recien agregué, y con ese ID inserto la imagen
                //Habria que ver si hay otra forma, por el momento lo pense asi
                datos.setearConsulta("insert into Articulos (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.setearParametro("@Codigo", nuevo.CodArticulo);
                datos.setearParametro("@Nombre", nuevo.NombreArticulo);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", nuevo.Categoria.IdCategoria);
                datos.setearParametro("@Precio", nuevo.Precio);
                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos.setearConsulta("INSERT INTO Imagenes (IdArticulo, ImagenUrl) " +
                     "VALUES ((SELECT MAX(Id) FROM Articulos), @UrlImagen)");
                datos.ejecutarAccion();
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
            finally 
            { 
                datos.cerrarConexion();
            }
    }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria , Precio = @Precio where Id = @Id;");
                datos.setearParametro("@Codigo", articulo.CodArticulo);
                datos.setearParametro("@Nombre", articulo.NombreArticulo);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", articulo.Categoria.IdCategoria);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@Id", articulo.Id);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar (int id )
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("Delete from Articulos where Id=@Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List <Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion,  " +
                                      "m.Id AS IdMarca, m.Descripcion AS Marca," +
                                      "c.Id AS IdCategoria, c.Descripcion AS Categoria," +
                                      "a.Precio," +
                                      "I.Imagenurl " +
                                      "FROM ARTICULOS a INNER JOIN MARCAS m ON a.IdMarca = m.Id INNER JOIN CATEGORIAS c ON a.IdCategoria = c.Id " +
                                      "INNER JOIN IMAGENES I on a.Id = I.IdArticulo and ";

                if (campo == "Codigo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "a.Codigo like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "a.Codigo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "a.Codigo like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "a.Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "a.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "a.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "a.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "a.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "a.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Marca = new Marca();
                    articulo.Categoria = new Categoria();

                    articulo.Id = datos.Lector.GetInt32(0);
                    articulo.CodArticulo = datos.Lector["Codigo"].ToString();
                    articulo.NombreArticulo = datos.Lector["Nombre"].ToString();
                    articulo.Descripcion = datos.Lector["Descripcion"].ToString();
                    articulo.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = datos.Lector["Marca"].ToString();
                    articulo.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = datos.Lector["Categoria"].ToString();
                    articulo.Precio = Convert.ToDecimal(datos.Lector["Precio"]);
                

                    lista.Add(articulo);

                }

                

                return lista;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
