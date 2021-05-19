using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Empresa
    {
        public string RutEmpresa { get; set; }
        public string NombreEmpresa { get; set; }
        public string DescripcionEmpresa { get; set; }

        public Empresa()
        {
            this.init();
        }

        private void init()
        {
            RutEmpresa = string.Empty;
            NombreEmpresa = string.Empty;
            DescripcionEmpresa = string.Empty;
        }
    }
}
