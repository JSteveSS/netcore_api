using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCRUD.Models
{
    public class Trabajador
    {

        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string fecha_nacimiento { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string sueldo { get; set; }
        public string estado { get; set; }
        public string campos_auditoria { get; set; }

    }
}
