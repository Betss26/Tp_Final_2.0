using Final_Master_Page.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Master_Page.Servicio.Login {
    public class ServicioLogin {
        readonly LoginRepositorio loginRepositorio = new LoginRepositorio();

        public UsuarioLogin obtenerUsuarioLogin(String nombreUsuario, String contrasenia) {
            return loginRepositorio.findByUserAndPassword(nombreUsuario, contrasenia);
        }
    }
}