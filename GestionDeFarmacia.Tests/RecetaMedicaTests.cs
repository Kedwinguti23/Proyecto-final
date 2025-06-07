using NUnit.Framework;
using GestionDeFarmacia.Models;

namespace GestionDeFarmacia.Tests
{
    [TestFixture]
    public class RecetaMedicaTests
    {
        [Test]
        public void CrearReceta_DeberiaInicializarCorrectamente()
        {
            var receta = new RecetaMedica(1, "Juan Pérez");

            Assert.That(receta.Id, Is.EqualTo(1));
            Assert.That(receta.NombrePaciente, Is.EqualTo("Juan Pérez"));
            Assert.That(receta.Medicamentos, Is.Not.Null);
            Assert.That(receta.Medicamentos.Count, Is.EqualTo(0));
        }

        [Test]
        public void AgregarMedicamento_DeberiaAumentarLista()
        {
            var receta = new RecetaMedica(1, "Ana Torres");
            var medicamento = new Medicamento(1, "Amoxicilina", "Antibiótico", 30, 4.5m);

            receta.AgregarMedicamento(medicamento);

            Assert.That(receta.Medicamentos.Count, Is.EqualTo(1));
            Assert.That(receta.Medicamentos[0], Is.SameAs(medicamento));
        }

        [Test]
        public void EliminarMedicamento_Existente_DeberiaRemover()
        {
            var receta = new RecetaMedica(1, "Carlos Méndez");
            var med = new Medicamento(1, "Paracetamol", "Analgésico", 25, 2.0m);
            receta.AgregarMedicamento(med);

            bool eliminado = receta.EliminarMedicamento(1);

            Assert.That(eliminado, Is.True);
            Assert.That(receta.Medicamentos.Count, Is.EqualTo(0));
        }

        [Test]
        public void EliminarMedicamento_NoExistente_DeberiaRetornarFalse()
        {
            var receta = new RecetaMedica(1, "Laura García");

            bool eliminado = receta.EliminarMedicamento(99);

            Assert.That(eliminado, Is.False);
        }
    }
}
