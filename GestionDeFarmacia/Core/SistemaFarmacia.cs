using System;
using System.Collections.Generic;
using GestionDeFarmacia.Models;

namespace GestionDeFarmacia.Core
{
    public class SistemaFarmacia
    {
        private List<Medicamento> medicamentos;
        private List<RecetaMedica> recetas;
        private List<Pedido> pedidos;

        private int contadorMedicamentos = 1;
        private int contadorRecetas = 1;
        private int contadorPedidos = 1;

        public SistemaFarmacia()
        {
            medicamentos = new List<Medicamento>();
            recetas = new List<RecetaMedica>();
            pedidos = new List<Pedido>();
        }

        // CRUD DE MEDICAMENTOS
        public void CrearMedicamento()
        {
            Console.WriteLine("=== Registrar Medicamento ===");
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            int stock = Utils.LeerEntero("Stock: ");
            decimal precio = Utils.LeerDecimal("Precio: ");

            var nuevoMed = new Medicamento(contadorMedicamentos++, nombre, descripcion, stock, precio);
            medicamentos.Add(nuevoMed);

            Console.WriteLine(" Medicamento registrado con éxito.");
            Utils.Pausar();
        }

        public void ListarMedicamentos()
        {
            Console.WriteLine("=== Lista de Medicamentos ===");
            if (medicamentos.Count == 0)
            {
                Console.WriteLine("No hay medicamentos registrados.");
            }
            else
            {
                foreach (var med in medicamentos)
                {
                    Console.WriteLine(med);
                }
            }
            Utils.Pausar();
        }

        public void ActualizarMedicamento()
        {
            Console.WriteLine("=== Actualizar Medicamento ===");
            int id = Utils.LeerEntero("Ingrese el ID del medicamento: ");

            var med = medicamentos.Find(m => m.Id == id);
            if (med == null)
            {
                Console.WriteLine(" Medicamento no encontrado.");
            }
            else
            {
                Console.Write("Nuevo nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Nueva descripción: ");
                string descripcion = Console.ReadLine();

                int stock = Utils.LeerEntero("Nuevo stock: ");
                decimal precio = Utils.LeerDecimal("Nuevo precio: ");

                med.Actualizar(nombre, descripcion, stock, precio);
                Console.WriteLine(" Medicamento actualizado correctamente.");
            }
            Utils.Pausar();
        }

        public void EliminarMedicamento()
        {
            Console.WriteLine("=== Eliminar Medicamento ===");
            int id = Utils.LeerEntero("Ingrese el ID del medicamento: ");

            var med = medicamentos.Find(m => m.Id == id);
            if (med != null)
            {
                medicamentos.Remove(med);
                Console.WriteLine(" Medicamento eliminado.");
            }
            else
            {
                Console.WriteLine(" Medicamento no encontrado.");
            }
            Utils.Pausar();
        }

        // CRUD DE RECETAS MÉDICAS
        public void CrearReceta()
        {
            Console.WriteLine("=== Crear Receta Médica ===");
            Console.Write("Nombre del paciente: ");
            string nombrePaciente = Console.ReadLine();

            var receta = new RecetaMedica(contadorRecetas++, nombrePaciente);

            int cantidad = Utils.LeerEntero("¿Cuántos medicamentos desea agregar?: ");

            for (int i = 0; i < cantidad; i++)
            {
                int idMed = Utils.LeerEntero($"ID del medicamento #{i + 1}: ");
                var med = medicamentos.Find(m => m.Id == idMed);
                if (med != null)
                {
                    receta.AgregarMedicamento(med);
                }
                else
                {
                    Console.WriteLine($" Medicamento con ID {idMed} no encontrado.");
                }
            }

            recetas.Add(receta);
            Console.WriteLine(" Receta creada con éxito.");
            Utils.Pausar();
        }

        public void ListarRecetas()
        {
            Console.WriteLine("=== Lista de Recetas ===");
            if (recetas.Count == 0)
            {
                Console.WriteLine("No hay recetas registradas.");
            }
            else
            {
                foreach (var receta in recetas)
                {
                    Console.WriteLine(receta);
                    Console.WriteLine("-------------------------");
                }
            }
            Utils.Pausar();
        }

        public void ActualizarReceta()
        {
            Console.WriteLine("=== Actualizar Receta ===");
            int id = Utils.LeerEntero("Ingrese el ID de la receta: ");

            var receta = recetas.Find(r => r.Id == id);
            if (receta == null)
            {
                Console.WriteLine(" Receta no encontrada.");
            }
            else
            {
                Console.Write("Nuevo nombre del paciente: ");
                string nuevoNombre = Console.ReadLine();
                receta.NombrePaciente = nuevoNombre;
                Console.WriteLine(" Receta actualizada.");
            }
            Utils.Pausar();
        }

        public void EliminarReceta()
        {
            Console.WriteLine("=== Eliminar Receta ===");
            int id = Utils.LeerEntero("Ingrese el ID de la receta: ");

            var receta = recetas.Find(r => r.Id == id);
            if (receta != null)
            {
                recetas.Remove(receta);
                Console.WriteLine(" Receta eliminada.");
            }
            else
            {
                Console.WriteLine(" Receta no encontrada.");
            }

            Utils.Pausar();
        }

        // CRUD DE PEDIDOS
        public void CrearPedido()
        {
            Console.WriteLine("=== Crear Pedido ===");
            if (recetas.Count == 0)
            {
                Console.WriteLine(" No hay recetas disponibles. Debe crear una primero.");
            }
            else
            {
                int idReceta = Utils.LeerEntero("Ingrese el ID de la receta a procesar: ");
                var receta = recetas.Find(r => r.Id == idReceta);
                if (receta == null)
                {
                    Console.WriteLine(" Receta no encontrada.");
                }
                else
                {
                    var pedido = new Pedido(contadorPedidos++, receta);
                    pedidos.Add(pedido);
                    Console.WriteLine(" Pedido creado con éxito.");
                }
            }
            Utils.Pausar();
        }

        public void ListarPedidos()
        {
            Console.WriteLine("=== Lista de Pedidos ===");
            if (pedidos.Count == 0)
            {
                Console.WriteLine("No hay pedidos registrados.");
            }
            else
            {
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine(pedido);
                    Console.WriteLine("-------------------------");
                }
            }
            Utils.Pausar();
        }

        public void ProcesarPedido()
        {
            Console.WriteLine("=== Procesar Pedido ===");
            int id = Utils.LeerEntero("Ingrese el ID del pedido: ");

            var pedido = pedidos.Find(p => p.Id == id);
            if (pedido == null)
            {
                Console.WriteLine(" Pedido no encontrado.");
            }
            else if (pedido.Procesado)
            {
                Console.WriteLine(" El pedido ya fue procesado.");
            }
            else
            {
                pedido.Procesar();
                Console.WriteLine(" Pedido procesado correctamente.");
            }
            Utils.Pausar();
        }

        public void EliminarPedido()
        {
            Console.WriteLine("=== Eliminar Pedido ===");
            int id = Utils.LeerEntero("Ingrese el ID del pedido: ");

            var pedido = pedidos.Find(p => p.Id == id);
            if (pedido != null)
            {
                pedidos.Remove(pedido);
                Console.WriteLine(" Pedido eliminado.");
            }
            else
            {
                Console.WriteLine(" Pedido no encontrado.");
            }
            Utils.Pausar();
        }
    }
}
