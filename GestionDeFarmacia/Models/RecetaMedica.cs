using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionDeFarmacia.Models
{
    public class RecetaMedica
    {
        public int Id { get; set; }

        // Validación para que nunca sea nulo
        public string NombrePaciente { get; set; }

        // Diccionario que asocia cada medicamento con su cantidad
        public Dictionary<Medicamento, int> Medicamentos { get; }

        public RecetaMedica(int id, string nombrePaciente)
        {
            Id = id;
            NombrePaciente = nombrePaciente ?? throw new ArgumentNullException(nameof(nombrePaciente));
            Medicamentos = new Dictionary<Medicamento, int>();
        }

        // Agrega un medicamento con su cantidad correspondiente
        public void AgregarMedicamento(Medicamento medicamento, int cantidad)
        {
            if (medicamento == null) throw new ArgumentNullException(nameof(medicamento));
            if (cantidad <= 0) throw new ArgumentException("La cantidad debe ser mayor a cero.", nameof(cantidad));

            if (Medicamentos.ContainsKey(medicamento))
            {
                Medicamentos[medicamento] += cantidad;
            }
            else
            {
                Medicamentos.Add(medicamento, cantidad);
            }
        }

        // Elimina un medicamento por su ID
        public bool EliminarMedicamento(int idMedicamento)
        {
            var med = Medicamentos.Keys.FirstOrDefault(m => m.Id == idMedicamento);
            if (med != null)
            {
                Medicamentos.Remove(med);
                return true;
            }
            return false;
        }

        // Muestra la información completa de la receta médica
        public override string ToString()
        {
            if (Medicamentos.Count == 0)
            {
                return $"ID Receta: {Id}\nPaciente: {NombrePaciente}\nMedicamentos: Sin medicamentos asignados.";
            }

            string detalleMedicamentos = string.Join("\n", Medicamentos.Select(kvp =>
                $"- {kvp.Key.Nombre} ({kvp.Key.Descripcion}) × {kvp.Value}"));

            return $"ID Receta: {Id}\n" +
                   $"Paciente: {NombrePaciente}\n" +
                   $"Medicamentos:\n{detalleMedicamentos}";
        }
    }
}
