using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class FotoEmpresa
    {
        public int IdFoto { get; set; }
        public string NombreImagen { get; set; }
        public string Descripcion { get; set; }
        public Empresa Empresa { get; set; }
        public byte Imagen { get; set; }

        public FotoEmpresa()
        {
            this.init();
        }

        private void init()
        {
            IdFoto = 0;
            NombreImagen = string.Empty;
            Descripcion = string.Empty;
            Empresa = new Empresa();
            Imagen = 0;
        }
    }
}
