using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_RFC
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

        public List<E_RFC> ObtenerTodos()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            List<E_RFC> lista = new List<E_RFC>();
            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("spObtenerTodos", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    E_RFC obj = new E_RFC();
                    obj.idRFC = Convert.ToInt32(reader["idRFC"]);
                    obj.nombre = reader["nombre"].ToString();
                    obj.apellidoPaterno = reader["apellidoPaterno"].ToString();
                    obj.apellidoMaterno = reader["apellidoMaterno"].ToString();
                    obj.fechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                    obj.rfc = reader["rfc"].ToString();

                    lista.Add(obj);
                }
                conexion.Close();
                return lista;
            } 
            catch (Exception ex)
            {
                conexion.Close();
                throw ex; 
            }
        }

        public int ObtenerCantidad()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            int contador = 0;
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("spObtenerTodos", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    E_RFC obj = new E_RFC();
                    obj.idRFC = Convert.ToInt32(reader["idRFC"]);
                    obj.nombre = reader["nombre"].ToString();
                    obj.apellidoPaterno = reader["apellidoPaterno"].ToString();
                    obj.apellidoMaterno = reader["apellidoMaterno"].ToString();
                    obj.fechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                    obj.rfc = reader["rfc"].ToString();

                    contador += 1;
                }
                conexion.Close();
                return contador;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }


        public void AgregarRFC(E_RFC obj)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("spAgregarRFC", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@nombre", obj.nombre);
                comando.Parameters.AddWithValue("@apellidoPaterno", obj.apellidoPaterno);
                comando.Parameters.AddWithValue("@apellidoMaterno", obj.apellidoMaterno);
                comando.Parameters.AddWithValue("@fechaNacimiento", obj.fechaNacimiento);
                comando.Parameters.AddWithValue("@rfc", obj.rfc);

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public E_RFC ObtenerPorID(int idRFC)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("spObtenerPorId", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idRFC", idRFC);

                SqlDataReader reader = comando.ExecuteReader();

                reader.Read();

                E_RFC obj = new E_RFC();
                obj.idRFC = Convert.ToInt32(reader["idRFC"]);
                obj.nombre = reader["nombre"].ToString();
                obj.apellidoPaterno = reader["apellidoPaterno"].ToString();
                obj.apellidoMaterno = reader["apellidoMaterno"].ToString();
                obj.fechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                obj.rfc = reader["rfc"].ToString();

                conexion.Close();
                return obj;
            }
            catch (Exception ex)
            {

                conexion.Close();
                throw ex;
            }
        }

        public void GuardarEdicion(E_RFC obj)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("spEditarRFC", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@idRFC", obj.idRFC);
                comando.Parameters.AddWithValue("@nombre", obj.nombre);
                comando.Parameters.AddWithValue("@apellidoPaterno", obj.apellidoPaterno);
                comando.Parameters.AddWithValue("@apellidoMaterno", obj.apellidoMaterno);
                comando.Parameters.AddWithValue("@fechaNacimiento", obj.fechaNacimiento);
                comando.Parameters.AddWithValue("@rfc", obj.rfc);

                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public void EliminarRFC(int id)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("spBorrarRFC", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idRFC", id);

                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }
        
        public List<E_RFC> BuscarRFC(string texto)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            List<E_RFC> lista = new List<E_RFC>();
            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("spBuscarRFC", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", "%" +  texto + "%");

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    E_RFC obj = new E_RFC();
                    obj.idRFC = Convert.ToInt32(reader["idRFC"]);
                    obj.nombre = reader["nombre"].ToString();
                    obj.apellidoPaterno = reader["apellidoPaterno"].ToString();
                    obj.apellidoMaterno = reader["apellidoMaterno"].ToString();
                    obj.fechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"]);
                    obj.rfc = reader["rfc"].ToString();

                    lista.Add(obj);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }
    }
}
