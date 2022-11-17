using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCRUD.Models
{
    public class Trabajador
    {

        public int TrabajadorCodigo { get; set; }
        public string TrabajadorNombre { get; set; }
        public string TrabajadorApellidoPaterno { get; set; }
        public string TrabajadorApellidoMaterno { get; set; }
        public string TrabajadorFechaDeNacimiento { get; set; }
        public string TrabajadorTipoDeDocumento { get; set; }
        public string TrabajadorNumeroDeDocumento { get; set; }
        public string TrabajadorSueldo { get; set; }
        public string TrabajadorEstado { get; set; }
        public string TrabajadorCamposDeAuditoria { get; set; }

    }
}
