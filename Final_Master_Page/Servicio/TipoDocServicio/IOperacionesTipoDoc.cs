using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Master_Page.Servicio.TipoDocServicio {
    public interface IOperacionesTipoDoc<T> {
        List<T> findAll();
    }
}