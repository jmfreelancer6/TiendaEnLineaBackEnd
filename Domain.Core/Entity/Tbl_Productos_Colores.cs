using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entity
{
    [Table("Tbl_Productos_Colores")]
    public class Tbl_Productos_Colores
    {
        [Key]
        public int ID { get; set; }
        public int IDColor { get; set; }
        [ForeignKey("IDColor")]
        public Tbl_Colores? Colores { get; set; }
        public int IDProducto { get; set; }
        public decimal Precio { get; set; }
    }
}
