using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexionDB_ODBC
{
   public class Persona
    {
        public int Id { get; set; }
        private string primerNombre;

        public string PrimerNombre
        {
            get { return primerNombre.ToUpper(); }
            set { primerNombre = value; }
        }

        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Rut { get; set; }
    }
}
