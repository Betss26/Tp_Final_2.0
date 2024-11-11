using Final_Master_Page.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Master_Page.Servicio.TipoDocServicio {
    public class TipoDocRepositorio : IOperacionesTipoDoc<Documento_Tipo> {
        OperacionesBaseDeDatos operacionesBaseDeDatos = new OperacionesBaseDeDatos();

        public List<Documento_Tipo> findAll() {
            return operacionesBaseDeDatos.obtenerTodosLosTipoDoc();
        }

        public List<Documento_Tipo> obtenerTiposDoc() {
            return operacionesBaseDeDatos.obtenerTodosLosTipoDoc();
        }
    }
}