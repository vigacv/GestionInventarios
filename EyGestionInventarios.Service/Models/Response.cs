using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EyGestionInventarios.Service.Models
{
    public class Response
    {
        public string Estado { set; get; }

        public string Mensaje { set; get; }

        public string Error { set; get; }
    }
}
