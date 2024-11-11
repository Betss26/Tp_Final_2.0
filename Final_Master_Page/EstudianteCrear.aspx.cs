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
    public partial class EstudianteCrear : System.Web.UI.Page {
        readonly ServicioEstudiante servicioEstudiante = new ServicioEstudiante();
        readonly ServicioTipoDoc servicioTipoDoc = new ServicioTipoDoc();
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                lbl_mensaje_error.Visible = false;
                lbl_mensaje_exito.Visible = false;
                string id = Request.QueryString["id"];

                txt_usuario.Text = id;
                drop_tipoDoc(Drop_docType);
                verificarUsuario();
            }
        }

        protected void btn_crear_estudiante_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                EstudianteModelo estudianteModelo = new EstudianteModelo();
                estudianteModelo.nombre = txt_nombre.Text;
                estudianteModelo.apellido = txt_pellido.Text;
                estudianteModelo.numeroDoc = txt_numDoc.Text;
                estudianteModelo.direccion = txt_direccion.Text;
                estudianteModelo.telefono = txt_telefono.Text;
                estudianteModelo.estado = txt_estado.Text;
                estudianteModelo.nombreUsuario = txt_usuario.Text;
                estudianteModelo.edad = Convert.ToInt16(txt_edad.Text);
                estudianteModelo.fechaNacimiento = DateTime.Parse(txt_cumpleanios.Text);// recibo 2024-02-23

                estudianteModelo.legajo = Convert.ToInt32(txt_legajo.Text);
                estudianteModelo.tipoDocId = Drop_docType.Text;

                estudianteModelo.contrasenia = txt_contrasenia.Text;
                estudianteModelo.cantidadMaterias = Convert.ToInt16(txt_cantMaterias.Text);

                int resultado = servicioEstudiante.crearEstudiante(estudianteModelo);
                if (resultado > 0) {
                    btn_crear_estudiante.Enabled = false;
                    lbl_mensaje_exito.Visible = true;
                    lbl_mensaje_exito.Text = "Exito! Se ha creado el estudiante";
                } else {
                    lbl_mensaje_error.Visible = true;
                    lbl_mensaje_error.Text = "Error! Se ha producido un error al crear un estudiante.";
                }
            }
        }

        protected void btn_vovler_Click(object sender, EventArgs e) {
            Response.Redirect($"FormEstudiantes.aspx");
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
            TimeSpan edad = DateTime.Today - DateTime.Parse(args.Value);
            int anios = Convert.ToInt32(edad.TotalDays / 365.25);

            args.IsValid = anios >= 18;
        }

        protected void edad_ServerValidacion(object source, ServerValidateEventArgs args) {
            TimeSpan edad = DateTime.Today - DateTime.Parse(args.Value);
            // int anios = Convert.ToInt32(edad.TotalDays / 365.25);

            double anios = edad.TotalDays / 365.25;
            double aux = Math.Floor(anios);
            args.IsValid = aux == Convert.ToInt32(txt_edad.Text);
        }

        private void verificarUsuario() {
            if (Session["usuario"] == null) {
                Response.Redirect($"Login.aspx");
            }
        }
    }
}