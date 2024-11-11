using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Master_Page.Servicio.Estudiantes {
    internal interface IOperacionesEstudiante<T> {
        T getOneById(int id);
        int create(T entidad);
        int update(T entidad);
        int delete(int id);
        List<T> findAll();
    }
}
