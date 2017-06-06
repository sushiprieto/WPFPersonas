using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;

namespace DAL.Manejadoras
{
    public class clsManejadoraPersonaDAL
    {

        private clsMyConnection miConexion;

        public clsManejadoraPersonaDAL()
        {
            miConexion = new clsMyConnection();
        }

        /// <summary>
        /// Función que permite añadir un elemento a la tabla persona
        /// </summary>
        /// <pre></pre>
        /// <returns></returns>
        public int insertarPersonaDAL(clsPersona persona)
        {
            int resultado = 0;

            SqlCommand miComando = new SqlCommand();

            //Añadimos los datos al comando
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.VarChar).Value = persona.FechaNac;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;

            try
            {

                miConexion.getConnection();

                miComando.CommandText = "Insert Into personas(nombre,apellidos,fechaNac,direccion,telefono) VALUES "
                    + "(@nombre,@apellidos,@fechaNac,@direccion,@telefono)";
                miComando.Connection = miConexion.connection;
                resultado = miComando.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                miConexion.closeConnection();
            }

            return resultado;

        }//fin insertar personaDAL

        /// <summary>
        /// Borra una persona cogiendo su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int deletepersonaDAL(int id)
        {

            int resultado = 0;
            SqlCommand miComando = new SqlCommand();

            try
            {
                miConexion.getConnection();
                miComando.Connection = miConexion.connection;
                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                miComando.CommandText = "Delete From personas where IdPersona=@id";
                miComando.Connection = miConexion.connection;
                resultado = miComando.ExecuteNonQuery();

            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                miConexion.closeConnection();
            }

            return resultado;

        }

        /// <summary>
        /// actualiza la persona
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int updatePersonaDAL(clsPersona persona)
        {

            int resultado = 0;
            SqlCommand miCommand = new SqlCommand();

            try
            {
                miConexion.getConnection();
                miCommand.Connection = miConexion.connection;
                miCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.id;
                miCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                miCommand.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
                miCommand.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = persona.FechaNac;
                miCommand.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                miCommand.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;

                miCommand.CommandText = "Update personas set nombre=@nombre,apellidos=@apellidos," +
                    "fechaNac=@fechaNac,direccion=@direccion,telefono=@telefono Where IDPersona=@id";
                resultado = miCommand.ExecuteNonQuery();
                resultado = resultado + 1;
                resultado--;
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                miConexion.closeConnection();
            }
            return resultado;

        }

        /// <summary>
        /// Vuelve a mostrar la lista de personas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsPersona selectPersonaDAL(int id)
        {
            clsPersona personita = new clsPersona();
            SqlCommand miCommand = new SqlCommand();
            SqlDataReader lector;
            try
            {
                miConexion.getConnection();
                miCommand.Connection = miConexion.connection;
                miCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                miCommand.CommandText = "Select nombre,apellidos,fechaNac,direccion,telefono from personas where IDPersona=@id";
                lector = miCommand.ExecuteReader();

                lector.Read();
                personita.id = id;
                personita.Nombre = (String)lector["nombre"];
                personita.Apellidos = (String)lector["apellidos"];
                personita.FechaNac = (DateTime)lector["fechaNac"];
                personita.Direccion = (String)lector["direccion"];
                personita.Telefono = (String)lector["telefono"];
            }
            catch (SqlException)
            {
                throw;
            }
            finally
            {
                miConexion.closeConnection();
            }

            return personita;
        }

    }
}
