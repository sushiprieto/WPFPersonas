using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class clsPersona
    {

        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNac { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        //Constructor por defecto
        public clsPersona()
        {

            id = 0;
            this.Nombre = "";
            this.Apellidos = "";
            this.FechaNac = new DateTime();
            this.Direccion = "";
            this.Telefono = "";

        }

        //Constructor con parametros
        public clsPersona(int id, string nombre, string apellidos, DateTime fechaNac, string direccion, string telefono)
        {
            this.id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.FechaNac = fechaNac;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }
    }//Fin class
}
