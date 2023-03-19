namespace API.Dtos
{
    public class ProductoColoresDto
    {
        public int ID { get; set; }
        public int IDColor { get; set; }
        public ColoresDto? Colores { get; set; }
        public int IDProducto { get; set; }
        public decimal Precio { get; set; }
    }
}
