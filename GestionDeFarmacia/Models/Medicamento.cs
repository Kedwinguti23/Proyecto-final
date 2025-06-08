namespace GestionDeFarmacia.Models
{
    public class Medicamento
    {
        // Identificador único del medicamento
        public int Id { get; set; }

        // Nombre del medicamento
        public string Nombre { get; set; }

        // Breve descripción (presentación, uso, etc.)
        public string Descripcion { get; set; }

        // Cantidad disponible en inventario
        public int Stock { get; set; }

        // Precio unitario del medicamento
        public decimal Precio { get; set; }

        // Constructor para inicializar un medicamento con datos completos
        public Medicamento(int id, string nombre, string descripcion, int stock, decimal precio)
        {
            Id = id;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            Stock = stock;
            Precio = precio;
        }

        // Método para modificar los datos del medicamento
        public void Actualizar(string nombre, string descripcion, int stock, decimal precio)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            Stock = stock;
            Precio = precio;
        }

        // Devuelve una cadena legible con la información del medicamento
        public override string ToString()
        {
            return $"[ID: {Id}] {Nombre} - {Descripcion} | Stock: {Stock} | Precio: ${Precio:F2}";
        }
    }
}
