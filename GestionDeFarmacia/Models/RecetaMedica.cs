using System.Collections.Generic;
using System.Text;

namespace GestionDeFarmacia.Models
{
    public class RecetaMedica
    {
        // Identificador único de la receta
        public int Id { get; set; }

        // Nombre del paciente asociado a la receta
        public string NombrePaciente { get; set; }

        // Lista de medicamentos recetados
        public List<Medicamento> Medicamentos { get; set; }

        // Constructor
        public RecetaMedica(int id, string nombrePaciente)
        {
            Id = id;
            NombrePaciente = nombrePaciente;
            Medicamentos = new List<Medicamento>();
        }

        // Agrega un medicamento a la receta
        public void AgregarMedicamento(Medicamento medicamento)
        {
            Medicamentos.Add(medicamento);
        }

        // Elimina un medicamento por ID
        public bool EliminarMedicamento(int idMedicamento)
        {
            var med = Medicamentos.Find(m => m.Id == idMedicamento);
            if (med != null)
            {
                Medicamentos.Remove(med);
                return true;
            }
            return false;
        }

        // Devuelve una representación legible de la receta
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Receta ID: {Id} | Paciente: {NombrePaciente}");
            sb.AppendLine("Medicamentos:");
            foreach (var med in Medicamentos)
            {
                sb.AppendLine($"- {med.Nombre} (ID: {med.Id})");
            }
            return sb.ToString();
        }
    }
}
