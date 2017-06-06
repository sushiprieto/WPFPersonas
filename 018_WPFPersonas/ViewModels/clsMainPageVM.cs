
using System;
using System.Collections.Generic;
using System.Linq;
using ENT;
using BL;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using BL.Listados;
using BL.Manejadoras;
using System.Windows;

namespace UI.ViewModels
{
    public class clsMainPageVM: clsVMBase
    {

        #region "Atributos"

        private clsPersona _personaSeleccionada;
        private ObservableCollection<clsPersona> _listado;

        private Visibility visibilidad;
        private Visibility visibilidadDeshacer;

        private bool estoyEditando;

        private DelegateCommand _eliminarCommand;
        private DelegateCommand _guardarCommand;
        private DelegateCommand _nuevoCommand;
        private DelegateCommand _deshacerCommand;

        #endregion

        #region "Constructores"

        public clsMainPageVM()
        {
            clsListadoPersonaBL lista = new clsListadoPersonaBL();
            _listado = lista.ListadoPersonasBL();
            _eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
            _guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecute);
            _nuevoCommand = new DelegateCommand(NuevoCommand_Execute, NuevoCommand_CanExecute);
            visibilidadDeshacer = Visibility.Collapsed;
        }

        #endregion

        #region "Propiedades"

        public clsPersona personaSeleccionada
        {
            get
            {
                return _personaSeleccionada;
            }
            set
            {
                _personaSeleccionada = value;
                _eliminarCommand.RaiseCanExecuteChanged();
                NotifyPropertyChanged("personaSeleccionada");
            }
        }
        public ObservableCollection<clsPersona> listado
        {
            get
            {
                return _listado;
            }
        }

        public Visibility Visibilidad
        {
            get
            {
                return visibilidad;
            }
            set
            {
                visibilidad = value;
                NotifyPropertyChanged("Visibilidad");
            }
        }

        public Visibility VisibilidadDeshacer
        {
            get
            {
                return visibilidadDeshacer;
            }
            set
            {
                visibilidadDeshacer = value;
                NotifyPropertyChanged("VisibilidadDeshacer");
            }
        }

        #endregion

        #region "Métodos"

        public DelegateCommand eliminarCommand
        {
            get
            {
                //_eliminarCommand = new DelegateCommand(EliminarCommand_Executed, EliminarCommand_CanExecute);
                return _eliminarCommand;
            }
        }

        public DelegateCommand guardarCommand
        {
            get
            {
                //_guardarCommand = new DelegateCommand(GuardarCommand_Executed, GuardarCommand_CanExecute);
                //return _guardarCommand;
                return _guardarCommand;
            }
        }

        public DelegateCommand nuevoCommand
        {
            get
            {
                return _nuevoCommand;
            }
        }

        public DelegateCommand deshacerCommand
        {
            get
            {
                return _deshacerCommand;
            }
        }

        /// <summary>
        /// Command executed
        /// Codigo para borrar una persona
        /// </summary>
        private void EliminarCommand_Executed()
        {
            //listado.Remove(personaSeleccionada);

            clsManejadoraPersonaBL miManejadora = new clsManejadoraPersonaBL();
            clsListadoPersonaBL miListado = new clsListadoPersonaBL();

            try
            {
                //if(MessageBox.Show("¿Desea borrar?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Warning))

                miManejadora.deletePersonaBL(personaSeleccionada.id);
                _listado = miListado.ListadoPersonasBL();
                NotifyPropertyChanged("listado");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error con la BBDD " + e);
            }
        }

        /// <summary>
        /// Command CanExecuted
        /// Codigo para borrar una persona
        /// </summary>
        /// <returns></returns>
        private bool EliminarCommand_CanExecute()
        {
            bool puedeBorrar = false;
            if (personaSeleccionada != null)
                puedeBorrar = true;
            return puedeBorrar;
        }

        /// <summary>
        /// Command executed
        /// Codigo para guardar una persona
        /// </summary>
        private void GuardarCommand_Executed()
        {

            clsManejadoraPersonaBL miManejadora = new clsManejadoraPersonaBL();
            clsListadoPersonaBL miListado = new clsListadoPersonaBL();

            //Cambiamos la visibilidad de la lista
            Visibilidad = Visibility.Visible;

            try
            {
                //Si ha pulsado "nuevo" 
                if (_personaSeleccionada.id != 0)
                {

                    miManejadora.updatePersonaBL(_personaSeleccionada);

                }
                else
                {

                    VisibilidadDeshacer = Visibility.Collapsed;
                    miManejadora.insertPersonaBL(_personaSeleccionada);

                }

                //Actualizamos la lista
                _listado = miListado.ListadoPersonasBL();
                NotifyPropertyChanged("listado");

            }
            catch (Exception e)
            {
                MessageBox.Show("Error con la BBDD " + e);
            }
        }

        /// <summary>
        /// Command CanExecuted
        /// Codigo para guardar una persona
        /// </summary>
        /// <returns></returns>
        private bool GuardarCommand_CanExecute()
        {
            //bool puedeGuardar = false;
            //if (personaSeleccionada != null)
            //    puedeGuardar = true;
            //return puedeGuardar;
            return true;
        }

        private bool NuevoCommand_CanExecute()
        {
            return true;
        }

        private void NuevoCommand_Execute()
        {
            //Cambiamos la visibilidad de la lista
            Visibilidad = Visibility.Collapsed;
            VisibilidadDeshacer = Visibility.Visible;
            personaSeleccionada = new clsPersona();
            NotifyPropertyChanged("PersonaSeleccionada");
        }

        #endregion

    }
}

