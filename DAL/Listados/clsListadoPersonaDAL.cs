using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ENT;

namespace DAL
{
    public class clsListadosPersonaDAL
    {
        /// <summary>
        /// lista de persona
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<clsPersona> getListadoPersonasDAL()
        {

            clsPersona oPersona;
            ObservableCollection<clsPersona> lista = new ObservableCollection<clsPersona>();
            clsMyConnection miConexion = new clsMyConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            

            try
            {

                miConexion.getConnection();
                miComando.CommandText = "Select IDPersona,nombre,apellidos,fechaNac,direccion,telefono From personas";
                miComando.Connection = miConexion.connection;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.id = (int)miLector["IDPersona"];
                        oPersona.Nombre = (string)miLector["nombre"];
                        oPersona.Apellidos = (string)miLector["apellidos"];
                        oPersona.FechaNac = (DateTime)miLector["fechaNac"];
                        oPersona.Direccion = (string)miLector["direccion"];
                        oPersona.Telefono = (string)miLector["telefono"];

                        lista.Add(oPersona);
                    } //Fin while

                    //miLector.Close();

                } //Fin if

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                miConexion.closeConnection();
            }
            return lista;

        }

    }//Fin class
}
