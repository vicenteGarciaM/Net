using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public Cliente Clientes { get; set; } = new Cliente();
        public Articulo Articulos { get; set; } = new Articulo();
        public DateTime Fecha { get; set; }
        [ForeignKey("Clientes")]
        public int IdCliente { get; set; } 
        [ForeignKey("Articulos")]
        public int IdArticulo { get; set; }

    }
}
