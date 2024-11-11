using Final_Master_Page.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Master_Page.Servicio.Estudiantes {
    public class EstudianteRepositorio : IOperacionesEstudiante<Estudiante> {

        OperacionesBaseDeDatos operacionesBaseDeDatos = new OperacionesBaseDeDatos();

        public int create(Estudiante estudiante) {
            return operacionesBaseDeDatos.crearEstudiante(estudiante);
        }

        public int delete(int id) {
            return operacionesBaseDeDatos.eliminarEstudiante(id);
        }

        public Estudiante getOneById(int id) {
            return operacionesBaseDeDatos.obtenerEstudiantePorId(id);
        }

        public int update(Estudiante estudiante) {
            return operacionesBaseDeDatos.actualizarEstudiante(estudiante);
        }

        public List<Estudiante> findAll() {
            return operacionesBaseDeDatos.obtenerTodosLosestudiantes();
        }
    }
}