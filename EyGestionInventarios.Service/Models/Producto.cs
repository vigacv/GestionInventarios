using System;
using System.Collections.Generic;

#nullable disable

namespace EyGestionInventarios.Service.Models
{
    public partial class Producto
    {
        public string CodArt { get; set; }
        public string Nombre { get; set; }
        public string DescArt { get; set; }
        public int? Cant { get; set; }
    }
}
