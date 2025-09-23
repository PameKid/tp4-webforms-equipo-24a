using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //guarda el conjunto de datos leido de la base de datos, es como una tabla virtual
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server =.\\SQLEXPRESS; database= PROMOS_DB; integrated security = true;");
            comando = new SqlCommand(); 

        }

        //Recibe la consulta SQL
        public void setearConsulta ( string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //Lee la bdd. Solo sirve para select
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Ejecuta las consultas: delete, update, insert
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    
        //Darle variables a la consulta sql 
        public void setearParametro(string nombre, object valor) 
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close(); 
            }
            conexion.Close();
        }
    }
}
