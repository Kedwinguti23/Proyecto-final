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

        // ------------------ MEDICAMENTOS ------------------

        public void CrearMedicamento()
        {
            Console.WriteLine("=== Registrar Medicamento ===");
            Console.Write("Nombre: ");
            string? nombre = Console.ReadLine();

            Console.Write("Descripción: ");
            string? descripcion = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
            {
                Console.WriteLine(" Error: Nombre y descripción no pueden estar vacíos.");
                return;
            }

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
                return;
            }

            Console.Write("Nuevo nombre: ");
            string? nombre = Console.ReadLine();

            Console.Write("Nueva descripción: ");
            string? descripcion = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
            {
                Console.WriteLine(" Error: Nombre y descripción no pueden estar vacíos.");
                return;
            }

            int stock = Utils.LeerEntero("Nuevo stock: ");
            decimal precio = Utils.LeerDecimal("Nuevo precio: ");

            med.Actualizar(nombre, descripcion, stock, precio);
            Console.WriteLine(" Medicamento actualizado correctamente.");
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

        // ------------------ RECETAS ------------------

public void CrearReceta()
{
    Console.WriteLine("=== Crear Receta Médica ===");
    Console.Write("Nombre del paciente: ");
    string? nombrePaciente = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(nombrePaciente))
    {
        Console.WriteLine(" Nombre del paciente no válido.");
        return;
    }

    var receta = new RecetaMedica(contadorRecetas++, nombrePaciente);

    string agregarOtro;
    do
    {
        ListarMedicamentos();

        int idMed = Utils.LeerEntero("Ingrese el ID del medicamento: ");
        var med = medicamentos.Find(m => m.Id == idMed);

        if (med == null)
        {
            Console.WriteLine(" Medicamento no encontrado.");
        }
        else
        {
            int cantidad = Utils.LeerEntero("Cantidad: ");
            receta.AgregarMedicamento(med, cantidad);
        }

        Console.Write("¿Agregar otro medicamento? (s/n): ");
        agregarOtro = Console.ReadLine()?.ToLower();
    } while (agregarOtro == "s");

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
        Utils.Pausar();
        return;
    }

    Console.WriteLine("1. Agregar medicamento");
    Console.WriteLine("2. Eliminar medicamento");
    Console.Write("Opción: ");
    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            ListarMedicamentos();
            int idMed = Utils.LeerEntero("ID del medicamento: ");
            var med = medicamentos.Find(m => m.Id == idMed);

            if (med == null)
            {
                Console.WriteLine(" Medicamento no encontrado.");
            }
            else
            {
                int cantidad = Utils.LeerEntero("Cantidad: ");
                receta.AgregarMedicamento(med, cantidad);
                Console.WriteLine(" Medicamento agregado.");
            }
            break;

        case "2":
            int idEliminar = Utils.LeerEntero("ID del medicamento a eliminar: ");
            if (receta.EliminarMedicamento(idEliminar))
                Console.WriteLine(" Medicamento eliminado de la receta.");
            else
                Console.WriteLine(" Medicamento no estaba en la receta.");
            break;

        default:
            Console.WriteLine(" Opción inválida.");
            break;
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


        // ------------------ PEDIDOS ------------------

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
