using Microsoft.AspNetCore.Mvc;
using Entity_Framework.Models;
// Importa herramientas para crear APIs y usar el modelo Producto

namespace Entity_Framework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // Define que es un controlador API
    // Ejemplo: la ruta será /api/productos

    public class ProductosController : ControllerBase
    {
        private static List<Producto> productos = GenerarProductos();
        // Lista en memoria con productos
        // Ejemplo: simula una base de datos sin usar SQL

        private static List<Producto> GenerarProductos()
        {
            var lista = new List<Producto>();
            var random = new Random();
            // Se usa Random para generar datos aleatorios

            string[] categorias = { "Electrónica", "Audio", "Almacenamiento", "General" };
            // Lista de categorías disponibles

            for (int i = 1; i <= 50; i++)
            {
                lista.Add(new Producto
                {
                    Id = i,
                    Nombre = "Producto " + i,
                    Descripcion = "Descripción del producto " + i,
                    Precio = random.Next(50, 1500),
                    Stock = random.Next(1, 100),
                    Categoria = categorias[random.Next(categorias.Length)],
                    FechaCreacion = DateTime.Now.AddDays(-random.Next(1, 1000))
                });
                // Ejemplo: crea productos como "Producto 1", "Producto 2", etc.
            }

            return lista;
            // Devuelve la lista completa de productos
        }

        // ***********EJERCICIO 1**************
        // Crea un endpoint tipo GET → Devuelve todos los productos

        [HttpGet]
        public ActionResult<List<Producto>> ObtenerTodos()
        {
            return productos;
        }
        // Endpoint GET /api/productos
        // Ejemplo: devuelve todos los productos ("Dame todo")


        // ***********EJERCICIO 2*************
        // Recorre todos los productos y toma solo el Nombre

        [HttpGet("nombres")]
        public ActionResult<List<string>> ObtenerNombres()
        {
            var nombres = productos.Select(p => p.Nombre).ToList();
            return nombres;
        }
        // Endpoint GET /api/productos/nombres
        // Ejemplo: devuelve solo los nombres


        // ***********EJERCICIO 3*************
        // Filtra productos con precio mayor a 1000 (uso de Where)

        [HttpGet("caros")]
        public ActionResult<List<Producto>> ProductosCaros()
        {
            return productos.Where(p => p.Precio > 1000).ToList();
        }
        // Endpoint GET /api/productos/caros
        // Ejemplo: devuelve productos caros


        // ********* EJERCICIO 4 ************
        // Ordena los productos por precio (de menor a mayor)

        [HttpGet("ordenados")]
        public ActionResult<List<Producto>> OrdenadosPorPrecio()
        {
            return productos.OrderBy(p => p.Precio).ToList();
        }
        // Endpoint GET /api/productos/ordenados
        // Ejemplo: productos ordenados por precio


        // **********EJERCICIO 5 **************
        // Agrupa los productos por categoría (uso de GroupBy)

        [HttpGet("por-categoria")]
        public ActionResult AgruparPorCategoria()
        {
            var resultado = productos
                .GroupBy(p => p.Categoria)
                .Select(g => new
                {
                    Categoria = g.Key,
                    Cantidad = g.Count()
                });

            return Ok(resultado);
        }
        // Endpoint GET /api/productos/por-categoria
        // Ejemplo: muestra cuántos productos hay por categoría
    }
}