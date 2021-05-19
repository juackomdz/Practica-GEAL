using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Cliente
    {
        public string RutCliente { get; set; }
        public string NombreCliente { get; set; }
        public string Contacto1 { get; set; }
        public string Fono1 { get; set; }
        public string Correo1 { get; set; }
        public string Contacto2 { get; set; }
        public string Fono2 { get; set; }
        public string Correo2 { get; set; }

        public Cliente()
        {
            this.init();
        }

        private void init()
        {
            RutCliente = string.Empty;
            NombreCliente = string.Empty;
            Contacto1 = string.Empty;
            Fono1 = string.Empty;
            Correo1 = string.Empty;
            Contacto2 = string.Empty;
            Fono2 = string.Empty;
            Correo2 = string.Empty;
        }
    }
}
