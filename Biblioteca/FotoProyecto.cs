using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca
{
    public class FotoProyecto
    {
        public int IdFoto { get; set; }
        public string NombreImagen { get; set; }
        public string Descripcion { get; set; }
        public Proyecto Proyecto { get; set; }
        public byte Imagen { get; set; }

        public FotoProyecto()
        {
            this.init();
        }

        private void init()
        {
            IdFoto = 0;
            NombreImagen = string.Empty;
            Descripcion = string.Empty;
            Proyecto = new Proyecto();
            Imagen = 0;
        }
    }
}
