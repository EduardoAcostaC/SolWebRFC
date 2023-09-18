using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class E_RFC
    {
        public int idRFC { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string rfc { get; set; }
        public bool activo { get; set; }
        public bool repetido { get; set; }

        public string nombreCompleto
        {
            get
            {
                return $"{nombre} {apellidoPaterno} {apellidoMaterno}";

            }
        }
    



        


    }
}
