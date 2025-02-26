using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }
        public Tienda Tiendas { get; set; } = new Tienda();
        public Articulo Articulos { get; set; } = new Articulo();
        public DateTime Fecha { get; set; }
        [ForeignKey("Tiendas")]
        public int IdTienda { get; set; }
        [ForeignKey("Articulos")]
        public int IdArticulo { get; set; }

    }
}
