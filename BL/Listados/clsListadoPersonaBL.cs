using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using DAL;
using System.Collections.ObjectModel;

namespace BL.Listados
{
    public class clsListadoPersonaBL
    {

        /// <summary>
        /// Listado de persona
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<clsPersona> ListadoPersonasBL()
        {
            ObservableCollection<clsPersona> resultado;
            clsListadosPersonaDAL listado = new clsListadosPersonaDAL();
            resultado = listado.getListadoPersonasDAL();
            return resultado;
        } //Fin List

    }
}
