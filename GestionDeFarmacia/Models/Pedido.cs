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
        public DateTime FechaPedido { get; set; }

        // Indica si el pedido ya fue procesado
        public bool Procesado { get; private set; }

        // Constructor
        public Pedido(int id, RecetaMedica receta)
        {
            Id = id;
            Receta = receta;
            FechaPedido = DateTime.Now;
            Procesado = false;
        }

        // Marca el pedido como procesado (lógica puede expandirse en SistemaFarmacia)
        public void Procesar()
        {
            Procesado = true;
            // Aquí podrías reducir el stock de los medicamentos si lo hacés desde SistemaFarmacia
        }

        // Devuelve la información del pedido para impresión
        public override string ToString()
        {
            return $"Pedido ID: {Id} | Fecha: {FechaPedido} | Procesado: {(Procesado ? "Sí" : "No")}\n{Receta}";
        }
    }
}
