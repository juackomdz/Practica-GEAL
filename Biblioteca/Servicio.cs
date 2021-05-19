using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Servicio
    {
        public int IdServicio { get; set; }
        public string NombreServicio { get; set; }
        public string DescripcionServicio { get; set; }

        public Servicio()
        {
            this.init();
        }

        private void init()
        {
            IdServicio = 0;
            NombreServicio = string.Empty;
            DescripcionServicio = string.Empty;
        }
    }
}
