using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entity
{
    [Table("Tbl_Productos")]
    public class Tbl_Productos
    {
        [Key]
        public int ID { get; set; }
        public string? NombreProducto { get; set; }
        [ForeignKey("IDProducto")]
        public ICollection<Tbl_Productos_Colores>? ProductosColores { get; set; }
    }
}
