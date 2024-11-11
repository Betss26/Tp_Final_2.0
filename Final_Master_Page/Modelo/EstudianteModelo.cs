using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Master_Page.Modelo {
    public class EstudianteModelo :Persona {

        public int id {
            get; set;
        }

        public int edad {
            get; set;
        }

        public string telefono {
            get; set;
        }

        public System.DateTime fechaCreacion {
            get; set;
        }
        public Nullable<System.DateTime> fechaEliminacion {
            get; set;
        }

        public string estado {
            get; set;
        }

        public string direccion {
            get; set;
        }
        public int cantidadMaterias {
            get; set;
        }
        public int legajo {
            get; set;
        }

        public string nombreUsuario {
            get; set;
        }

        public string contrasenia {
            get; set;
        }

        public string numeroDoc {
            get; set;
        }

        public System.DateTime fechaNacimiento {
            get; set;
        }
    }

}