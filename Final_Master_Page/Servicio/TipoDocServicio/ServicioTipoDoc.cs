using Final_Master_Page.Datos;
using Final_Master_Page.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Master_Page.Servicio.TipoDocServicio {
    public class ServicioTipoDoc {
        TipoDocRepositorio tipoDocRepositorio = new TipoDocRepositorio();

        public List<TipoDocumentoModelo> obetenerTodosLosTiposDoc() {
            List<Documento_Tipo> documento_Tipos = tipoDocRepositorio.obtenerTiposDoc();
            List<TipoDocumentoModelo> tipoDocumentoModelos = new List<TipoDocumentoModelo>();

            foreach (Documento_Tipo dt in documento_Tipos) {
                tipoDocumentoModelos.Add(buildDocumentoModelo(dt));
            }
            return tipoDocumentoModelos;
        }

        private TipoDocumentoModelo buildDocumentoModelo(Documento_Tipo documento) {
            TipoDocumentoModelo tipoDocumentoModelo = new TipoDocumentoModelo();
            tipoDocumentoModelo.doctypeid = documento.doctypeid;
            tipoDocumentoModelo.descripcion = documento.descripcion;
            return tipoDocumentoModelo;
        }
    }
}