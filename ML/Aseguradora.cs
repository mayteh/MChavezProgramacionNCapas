using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Aseguradora
    {
        public int IdUsuario { get; set; }
        public int IdAseguradora { get; set; }
        public string NombreAseguradora { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public List<object> Aseguradoras { get; set; }

        //Propiedades de navegacion

        public ML.Usuario Usuario { get; set; }
    }
}
