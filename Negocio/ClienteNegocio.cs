using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class ClienteNegocio
    {
        public void Agregar(Cliente cliente, String voucher, string codArticulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                if (ObtenerPorDNI(cliente) == false)
                {
                    //datos.setearConsulta("insert into Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) values (@documento,@nombre,@apellido,@email,@direccion,@ciudad,@cp)");
                    datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) " +
                        "VALUES (@documento, @nombre, @apellido, @email, @direccion, @ciudad, @cp)");

                    datos.setearParametro("@documento", cliente.Documento);
                    datos.setearParametro("@nombre", cliente.Nombre);
                    datos.setearParametro("@apellido", cliente.Apellido);
                    datos.setearParametro("@email", cliente.Email);
                    datos.setearParametro("@direccion", cliente.Direccion);
                    datos.setearParametro("@ciudad", cliente.Ciudad);
                    datos.setearParametro("@cp", cliente.CP);
                    datos.ejecutarAccion();
                    datos.cerrarConexion();

                    datos.setearConsulta("UPDATE Vouchers SET IdCliente = (SELECT MAX(Id) FROM Clientes), FechaCanje = GETDATE(), IdArticulo = @IdArticulo " +
                    "WHERE CodigoVoucher = @voucher AND IdCliente IS NULL");
                    datos.setearParametro("@voucher", voucher);
                    datos.setearParametro("@IdArticulo", codArticulo);
                    datos.ejecutarAccion();
                }

                else 
                {
                    datos.setearConsulta("UPDATE Vouchers SET IdCliente = @idCliente, FechaCanje = GETDATE(), IdArticulo = @IdArticulo " +
                    "WHERE CodigoVoucher = @voucher");
                    datos.setearParametro("@voucher", voucher);
                    datos.setearParametro("@IdArticulo", codArticulo);
                    datos.setearParametro("@idCliente", cliente.ID);
                    datos.ejecutarAccion();

                }
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

        //Modicar el metodo de obtener por dni 


        public bool ObtenerPorDNI(Cliente cliente)
        {
            //cliente cliente = new cliente();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP from Clientes\r\n where Documento = @dni");
                datos.setearParametro("@dni", cliente.Documento);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cliente.ID = int.Parse(datos.Lector["id"].ToString());
                    cliente.Documento = datos.Lector["Documento"].ToString();
                    cliente.Nombre = datos.Lector["Nombre"].ToString();
                    cliente.Apellido = datos.Lector["Apellido"].ToString();
                    cliente.Email = datos.Lector["Email"].ToString();
                    cliente.Direccion = datos.Lector["Direccion"].ToString();
                    cliente.Ciudad = datos.Lector["Ciudad"].ToString();
                    cliente.CP = datos.Lector["CP"].ToString();

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
