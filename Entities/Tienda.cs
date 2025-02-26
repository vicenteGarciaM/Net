using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Tienda
    {
        [Key]
        public int IdTienda { get; set; }
        public string Sucursal { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

    }
}
