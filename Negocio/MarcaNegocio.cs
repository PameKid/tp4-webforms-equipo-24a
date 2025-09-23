using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class MarcaNegocio
    {

        public List<Marca> Listar()
        {
            List<Marca> listaMarcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();  

            try
            {
                datos.setearConsulta( "Select Id, Descripcion From Marcas");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Marca marcaAuxiliar = new Marca();
                    marcaAuxiliar.IdMarca = (int)datos.Lector["Id"];
                    marcaAuxiliar.Descripcion = (string)datos.Lector["Descripcion"];

                    listaMarcas.Add(marcaAuxiliar);
                }
               
                return listaMarcas;
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

        public void agregar (Marca nuevaMarca)  
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO MARCAS (Descripcion) VALUES ('" + nuevaMarca.Descripcion + "')");
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

        public void modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE MARCAS SET DESCRIPCION = '" + marca.Descripcion + "' WHERE ID = " + marca.IdMarca);
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

        public void eliminar(int id )
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM MARCAS WHERE ID = " + id);
                datos.ejecutarAccion(); 
            }
            catch (Exception ex)
            {
                throw ex ;
            }
            finally
            {
                datos.cerrarConexion(); 
            }

        }
    }
}
