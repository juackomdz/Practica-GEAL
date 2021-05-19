using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class FotoServicio
    {
        public int IdFoto { get; set; }
        public string NombreImagen { get; set; }
        public string Descripcion { get; set; }
        public Servicio Servicio { get; set; }
        public byte Imagen { get; set; }

        public FotoServicio()
        {
            this.init();
        }

        private void init()
        {
            IdFoto = 0;
            NombreImagen = string.Empty;
            Descripcion = string.Empty;
            Servicio = new Servicio();
            Imagen = 0;
        }
    }
}
