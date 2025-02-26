using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Articulo
    {

        [Key]
        public int IdArticulo { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        [Column(TypeName = ("decimal(18,2)"))]
        public decimal Precio { get; set; }
        public byte[] Imagen { get; set; } = new byte[0];
        public int Stock { get; set; }

    }
}
