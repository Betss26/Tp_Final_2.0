using Final_Master_Page.Servicio.Estudiantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Master_Page {
    public partial class FormEstudiantes : System.Web.UI.Page {
        ServicioEstudiante servicioEstudiante = new ServicioEstudiante();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                lbl_borrar_error.Visible = false;
                lbl_borrar_exito.Visible = false;

                LlenarGridEstudiantes(grid_estudiantes);
                verificarUsuario();
            }
        }

        private void LlenarGridEstudiantes(GridView grid) {
            grid.DataSource = servicioEstudiante.obtenerEstudiantes();
            grid.DataBind();
        }

        protected void grid_estudiantes_SelectedIndexChanged(object sender, EventArgs e) {
            System.Diagnostics.Debug.WriteLine("grid_estudiantes_SelectedIndexChanged");
        }

        protected void grid_estudiantes_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            if (servicioEstudiante.eliminarEstudiante(Convert.ToInt32(e.Keys["id"])) > 0) {
                lbl_borrar_exito.Visible = true;
                lbl_borrar_exito.Text = "Exito al borrar.";
                LlenarGridEstudiantes(grid_estudiantes);
            } else {
                lbl_borrar_error.Visible = true;
                lbl_borrar_error.Text = "Error! no se ha borrado el estudiante.";
            }
        }

        protected void grid_estudiantes_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            string id = Convert.ToString(e.Keys["id"]);
            string nombreUsuario = Convert.ToString(e.Keys["nombreUsuario"]);
            Response.Redirect($"EstudianteActualizar.aspx?id={id}&userId={nombreUsuario}");
        }

        protected void btn_crear_estudiante_Click(object sender, EventArgs e) {
            Response.Redirect($"EstudianteCrear.aspx");
        }

        protected void btn_editar_Click(object sender, EventArgs e) {

        }

        protected void grid_estudiantes_RowCancelingEdit(object sender, EventArgs e) {

        }

        protected void verificarUsuario() {
            if (Session["usuario"] == null) {
                Response.Redirect($"Login.aspx");
            }
        }
    }
}