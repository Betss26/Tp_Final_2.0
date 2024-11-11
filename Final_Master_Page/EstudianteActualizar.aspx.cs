using Final_Master_Page.Modelo;
using Final_Master_Page.Servicio.Estudiantes;
using Final_Master_Page.Servicio.TipoDocServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Master_Page {
    public partial class EstudianteActualizar : System.Web.UI.Page {
        readonly ServicioEstudiante servicioEstudiante = new ServicioEstudiante();
        readonly ServicioTipoDoc servicioTipoDoc = new ServicioTipoDoc();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {

                lbl_mensaje_error.Visible = false;
                lbl_mensaje_exito.Visible = false;
                lbl_id.Visible = false;

                string id = Request.QueryString["id"];
                string userName = Request.QueryString["user"];
                lbl_id.Text = id;
                txt_usuario.Text = userName;

                llenarDatosEstudiante(Convert.ToInt16(id));
                drop_tipoDoc(Drop_docType);
                verificarUsuario();
            }
        }
        protected void btn_actualizar_estudiante_Click(object sender, EventArgs e) {

        }

        protected void btn_confirmar_estudiante_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                EstudianteModelo estudianteModelo = new EstudianteModelo();
                estudianteModelo.id = Convert.ToInt16(lbl_id.Text);
                estudianteModelo.nombre = txt_nombre.Text;
                estudianteModelo.apellido = txt_pellido.Text;
                estudianteModelo.numeroDoc = txt_numDoc.Text;
                estudianteModelo.tipoDocId = Drop_docType.Text;
                estudianteModelo.direccion = txt_direccion.Text;
                estudianteModelo.telefono = txt_telefono.Text;
                estudianteModelo.estado = txt_estado.Text;
                estudianteModelo.nombreUsuario = txt_usuario.Text;
                estudianteModelo.cantidadMaterias = Convert.ToInt16(txt_cantMaterias.Text);
                estudianteModelo.contrasenia = txt_contrasenia.Text;
                estudianteModelo.edad = Convert.ToInt16(txt_edad.Text);
                estudianteModelo.fechaNacimiento = DateTime.Parse(txt_cumpleanios.Text);

                int result = servicioEstudiante.actualizarEstudiante(estudianteModelo);

                if (result == 1) {
                    lbl_mensaje_error.Visible = false;
                    lbl_mensaje_exito.Visible = true;
                    lbl_mensaje_exito.Text = "Exito! Estudiante actualizado.";
                }
                if (result == 0) {
                    lbl_mensaje_error.Visible = true;
                    lbl_mensaje_error.Text = "Error! Estudiante no actualizado";
                }
                if (result == 2) {
                    lbl_mensaje_exito.Visible = false;
                    lbl_mensaje_error.Visible = true;
                    lbl_mensaje_error.Text = "Error! El usuario ya existe";
                }
            }
        }

        protected void btn_vovler_Click(object sender, EventArgs e) {
            Response.Redirect("FormEstudiantes.aspx");
        }

        private void llenarDatosEstudiante(int id) {
            if (id > 0) {
                try {
                    EstudianteModelo estudiante = servicioEstudiante.obtenerEstudiantePorId(id);

                    txt_nombre.Text = estudiante.nombre;
                    txt_pellido.Text = estudiante.apellido;
                    txt_numDoc.Text = estudiante.numeroDoc.ToString();
                    Drop_docType.Text = estudiante.tipoDocId;
                    txt_usuario.Text = estudiante.nombreUsuario;
                    txt_contrasenia.Text = estudiante.contrasenia;
                    txt_telefono.Text = estudiante.telefono;
                    txt_cumpleanios.Text = Convert.ToString(estudiante.fechaNacimiento);
                    txt_estado.Text = estudiante.estado;
                    txt_direccion.Text = estudiante.direccion;
                    txt_cantMaterias.Text = estudiante.cantidadMaterias.ToString();
                    txt_legajo.Text = Convert.ToString(estudiante.legajo);
                    txt_edad.Text = Convert.ToString(estudiante.edad);

                } catch (Exception e) {
                    lbl_mensaje_error.Visible = true;
                    lbl_mensaje_error.Text = "Ha ocurrido un error en llenarDatosEstudiante()";
                }
            }
        }

        public void drop_tipoDoc(DropDownList dropDownList) {
            dropDownList.ClearSelection();
            dropDownList.Items.Clear();
            dropDownList.AppendDataBoundItems = true;
            dropDownList.Items.Add("Elige un tipo de documento");
            dropDownList.Items[0].Value = "0";
            dropDownList.DataSource = servicioTipoDoc.obetenerTodosLosTiposDoc();
            dropDownList.DataTextField = "descripcion";
            dropDownList.DataValueField = "doctypeid";
            dropDownList.DataBind();
        }

        protected void fecha_ServerValidacion(object source, ServerValidateEventArgs args) {
            DateTime fechaActual = DateTime.Now;
            int anios = fechaActual.Year - DateTime.Parse(args.Value).Year;

            args.IsValid = anios >= 16;
        }

        protected void edad_ServerValidacion(object source, ServerValidateEventArgs args) {
            DateTime fechaActual = DateTime.Now;
            int añosTranscurridos = fechaActual.Year - DateTime.Parse(args.Value).Year;

            args.IsValid = añosTranscurridos == Convert.ToInt32(txt_edad.Text);
        }

        private void verificarUsuario() {
            if (Session["usuario"] == null) {
                Response.Redirect($"Login.aspx");
            }
        }
    }
}