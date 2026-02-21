namespace Entity_Framework.Models
{
    // Define el modelo Producto
    // Ejemplo: representa la estructura de un producto en la API

    public class Producto
    {
        public int Id { get; set; }
        // Identificador único del producto
        // Ejemplo: 1, 2, 3...

        public string Nombre { get; set; }
        // Nombre del producto
        // Ejemplo: "Laptop", "Mouse", "Teclado"

        public string Descripcion { get; set; }
        // Descripción del producto
        // Ejemplo: "Laptop gamer con 16GB RAM"

        public decimal Precio { get; set; }
        // Precio del producto
        // Ejemplo: 999.99

        public int Stock { get; set; }
        // Cantidad disponible en inventario
        // Ejemplo: 10 unidades

        public string Categoria { get; set; }
        // Categoría del producto
        // Ejemplo: "Electrónica", "Audio"

        public DateTime FechaCreacion { get; set; }
        // Fecha en que se creó el producto
        // Ejemplo: 2024-01-01
    }
}