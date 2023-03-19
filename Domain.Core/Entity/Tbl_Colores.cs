using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entity
{
    [Table("Tbl_Colores")]
    public class Tbl_Colores
    {
        [Key]
        public int ID { get; set; }
        public string? Color { get; set; }
        public string? NombreColor { get; set; }
    }
}
