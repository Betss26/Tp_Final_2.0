using Final_Master_Page.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Master_Page {
    public partial class Login : System.Web.UI.Page {
        readonly Servicio.Login.ServicioLogin servicioLogin = new Servicio.Login.ServicioLogin();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {

                lbl_mensaje_error.Visible = false;
            }
        }
        protected void btn_ingresar_Click(object sender, EventArgs e) {
            String nombreUsuario = txt_usuario.Text;
            String contrasenia = txt_contrasenia.Text;
            UsuarioLogin usuario = servicioLogin.obtenerUsuarioLogin(nombreUsuario, contrasenia);
            if (usuario != null) {
                Session["usuario"] = usuario.Usuario;
                Response.Redirect($"FormEstudiantes.aspx");
            } else {
                lbl_mensaje_error.Text = "Datos incorrectos.";
                lbl_mensaje_error.Visible = true;
            }
        }
    }
}