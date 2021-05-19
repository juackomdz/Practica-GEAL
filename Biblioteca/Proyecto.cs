using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Proyecto
    {
        public int IdProyecto { get; set; }
        public string NombreProyecto { get; set; }
        public string Descripcion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public Cliente Cliente { get; set; }
        

        public Proyecto()
        {
            this.init();
        }

        private void init()
        {
            IdProyecto = 0;
            NombreProyecto = string.Empty;
            Descripcion = string.Empty;
            FechaInicio = string.Empty;
            FechaFin = string.Empty;
            Cliente = new Cliente();
            
        }
    }
}
