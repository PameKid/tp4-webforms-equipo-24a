using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class ClienteNegocio
    {
        public void Agregar(cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) values (@documento,@nombre,@apellido,@email,@direccion,@ciudad,@cp)");
                datos.setearParametro("@documento", cliente.Documento);
                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@apellido", cliente.Apellido);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@direccion", cliente.Direccion);
                datos.setearParametro("@ciudad", cliente.Ciudad);
                datos.setearParametro("@cp", cliente.CP);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public Boolean ObtenerPorDNI(string dni)
        {
            //cliente cliente = new cliente();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select * from Clientes where Documento = @dni");
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
