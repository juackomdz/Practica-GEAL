using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuario
    {   public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public Usuario()
        {
            this.init();
        }

        private void init()
        {
            IdUsuario = 0;
            Correo = string.Empty;
            Contraseña = string.Empty;
        }
    }
}
