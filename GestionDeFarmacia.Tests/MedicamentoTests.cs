using NUnit.Framework;
using GestionDeFarmacia.Models;

namespace GestionDeFarmacia.Tests
{
    [TestFixture]
    public class MedicamentoTests
    {
        [Test]
        public void CrearMedicamento_DeberiaAsignarValoresCorrectos()
        {
            var medicamento = new Medicamento(1, "Paracetamol", "Analgésico", 50, 2.5m);

            Assert.That(medicamento.Id, Is.EqualTo(1));
            Assert.That(medicamento.Nombre, Is.EqualTo("Paracetamol"));
            Assert.That(medicamento.Descripcion, Is.EqualTo("Analgésico"));
            Assert.That(medicamento.Stock, Is.EqualTo(50));
            Assert.That(medicamento.Precio, Is.EqualTo(2.5m));
        }

        [Test]
        public void Actualizar_DeberiaModificarPropiedades()
        {
            var medicamento = new Medicamento(1, "Ibuprofeno", "Analgésico", 20, 3.0m);

            medicamento.Actualizar("Ibuprofeno 400", "Antiinflamatorio", 100, 5.5m);

            Assert.That(medicamento.Nombre, Is.EqualTo("Ibuprofeno 400"));
            Assert.That(medicamento.Descripcion, Is.EqualTo("Antiinflamatorio"));
            Assert.That(medicamento.Stock, Is.EqualTo(100));
            Assert.That(medicamento.Precio, Is.EqualTo(5.5m));
        }
    }
}
