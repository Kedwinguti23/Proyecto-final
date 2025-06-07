using NUnit.Framework;
using GestionDeFarmacia.Models;
using System;

namespace GestionDeFarmacia.Tests
{
    [TestFixture]
    public class PedidoTests
    {
        [Test]
        public void CrearPedido_DeberiaInicializarCorrectamente()
        {
            var receta = new RecetaMedica(1, "Mario Hernández");
            var pedido = new Pedido(1, receta);

            Assert.That(pedido.Id, Is.EqualTo(1));
            Assert.That(pedido.Receta, Is.SameAs(receta));
            Assert.That(pedido.Procesado, Is.False);
            Assert.That(pedido.FechaPedido, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(5)));
        }

        [Test]
        public void Procesar_DeberiaCambiarEstadoAProcesado()
        {
            var receta = new RecetaMedica(2, "Gloria Pérez");
            var pedido = new Pedido(2, receta);

            pedido.Procesar();

            Assert.That(pedido.Procesado, Is.True);
        }

        [Test]
        public void Procesar_DosVeces_NoLanzaExcepcion()
        {
            var receta = new RecetaMedica(3, "Luis Araujo");
            var pedido = new Pedido(3, receta);

            pedido.Procesar();
            pedido.Procesar(); // Segunda vez

            Assert.That(pedido.Procesado, Is.True);
        }
    }
}
