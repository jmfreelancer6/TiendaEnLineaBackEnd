namespace API.Dtos
{
    public class ProductoDto
    {
        public int ID { get; set; }
        public string? NombreProducto { get; set; }
        public ICollection<ProductoColoresDto>? ProductosColores { get; set; }
    }
}
