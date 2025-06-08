using System;

namespace GestionDeFarmacia.Models
{
    public class Pedido
    {
        // Identificador único del pedido
        public int Id { get; set; }

        // Receta médica asociada al pedido
        public RecetaMedica Receta { get; set; }

        // Fecha en que se procesó el pedido
        public DateTime FechaPedido { get; private set; }

        // Indica si el pedido ya fue procesado
        public bool Procesado { get; private set; }

        // Constructor
        public Pedido(int id, RecetaMedica receta)
        {
            Id = id;
            Receta = receta ?? throw new ArgumentNullException(nameof(receta));
            FechaPedido = DateTime.Now;
            Procesado = false;
        }

        // Marca el pedido como procesado
        public void Procesar()
        {
            Procesado = true;
            // Podrías descontar el stock de medicamentos aquí si no lo haces en SistemaFarmacia
        }

        // Devuelve la información del pedido para impresión
        public override string ToString()
        {
            return $"Pedido ID: {Id} | Fecha: {FechaPedido:G} | Procesado: {(Procesado ? "Sí" : "No")}\n{Receta}";
        }
    }
}

