using Final_Master_Page.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Master_Page.Servicio.Login {
    public class LoginRepositorio {
        OperacionesBaseDeDatos operacionesBaseDeDatos = new OperacionesBaseDeDatos();

        public UsuarioLogin findByUserAndPassword(String nombreUsuario, String contrasenia) {
            return operacionesBaseDeDatos.obtenerUsuarioLogin(nombreUsuario, contrasenia);
        }
    }
}