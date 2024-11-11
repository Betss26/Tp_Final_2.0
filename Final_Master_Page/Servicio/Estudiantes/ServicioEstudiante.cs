using Final_Master_Page.Datos;
using Final_Master_Page.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Master_Page.Servicio.Estudiantes {
    public class ServicioEstudiante {
        readonly EstudianteRepositorio estudianteRepositorio = new EstudianteRepositorio();

        public List<EstudianteModelo> obtenerEstudiantes() {
            List<Estudiante> estudiantes = estudianteRepositorio.findAll();
            List<EstudianteModelo> estudiantesModelo = new List<EstudianteModelo>();

            foreach (Estudiante st in estudiantes) {
                estudiantesModelo.Add(buildEstudianteModelo(st));
            }
            return estudiantesModelo;
        }

        public int eliminarEstudiante(int id) {

            return estudianteRepositorio.delete(id);
        }

        public int crearEstudiante(EstudianteModelo estudianteModelo) {
            Estudiante nuevoEstudiante = buildEstudiante(estudianteModelo);
            nuevoEstudiante.created = DateTime.Now;
            return estudianteRepositorio.create(nuevoEstudiante);
        }

        public int actualizarEstudiante(EstudianteModelo estudianteModelo) {
            Estudiante estudiante = buildEstudiante(estudianteModelo);
            estudiante.Id = estudianteModelo.id;
            return estudianteRepositorio.update(estudiante);
        }

        public EstudianteModelo obtenerEstudiantePorId(int id) {
            return buildEstudianteModelo(estudianteRepositorio.getOneById(id));
        }

        public static EstudianteModelo buildEstudianteModelo(Estudiante st) {
            EstudianteModelo estudiante = new EstudianteModelo();
            estudiante.id = st.Id;
            estudiante.nombre = st.name;
            estudiante.apellido = st.lastname;
            estudiante.tipoDocId = st.Documento_Tipo.doctypeid;
            estudiante.numeroDoc = st.docnumber;
            estudiante.nombreUsuario = st.Usuario.username;
            estudiante.contrasenia = st.Usuario.password;
            estudiante.edad = st.age;
            estudiante.telefono = st.phone;
            estudiante.fechaNacimiento = DateTime.Parse(st.birthdate);
            estudiante.legajo = Convert.ToInt32(st.numberFile);

            if (st.birthdate != null) {
                DateTime date = DateTime.Parse(st.birthdate);
                estudiante.fechaNacimiento = date;
            }
            estudiante.estado = st.status;
            estudiante.direccion = st.address;
            estudiante.cantidadMaterias = st.subjectQuantity;

            return estudiante;
        }

        public static Estudiante buildEstudiante(EstudianteModelo estudianteModelo) {
            Estudiante estudiante = new Estudiante();
            estudiante.name = estudianteModelo.nombre;
            estudiante.lastname = estudianteModelo.apellido;

            estudiante.doctype = estudianteModelo.tipoDocId;

            Usuario usuario = new Usuario();
            usuario.password = estudianteModelo.contrasenia;
            usuario.username = estudianteModelo.nombreUsuario;
            estudiante.Usuario = usuario;

            estudiante.doctype = estudianteModelo.tipoDocId;
            estudiante.phone = estudianteModelo.telefono;
            estudiante.created = DateTime.Now;

            estudiante.status = estudianteModelo.estado;
            estudiante.address = estudianteModelo.direccion;
            estudiante.subjectQuantity = estudianteModelo.cantidadMaterias;
            estudiante.age = estudianteModelo.edad;
            estudiante.docnumber = estudianteModelo.numeroDoc;

            estudiante.birthdate = Convert.ToString(estudianteModelo.fechaNacimiento);
            estudiante.numberFile = Convert.ToString(estudianteModelo.legajo);

            return estudiante;
        }
    }
}