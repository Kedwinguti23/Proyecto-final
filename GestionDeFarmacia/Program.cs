using GestionDeFarmacia.Core;

namespace GestionDeFarmacia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SistemaFarmacia sistema = new SistemaFarmacia();
            bool salir = false;

            while (!salir)
            {
                Utils.LimpiarPantalla();
                Console.WriteLine("=== GESTIÓN DE FARMACIA ===");
                Console.WriteLine("1. CRUD Medicamentos");
                Console.WriteLine("2. CRUD Recetas Médicas");
                Console.WriteLine("3. CRUD Pedidos");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1": SubMenuMedicamentos(sistema); break;
                    case "2": SubMenuRecetas(sistema); break;
                    case "3": SubMenuPedidos(sistema); break;
                    case "0": salir = true; break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        Utils.Pausar();
                        break;
                }
            }

            Console.WriteLine(" Hasta luego. Gracias por usar el sistema. Bendiciones!");
        }

        static void SubMenuMedicamentos(SistemaFarmacia sistema)
        {
            Utils.LimpiarPantalla();
            Console.WriteLine("=== CRUD MEDICAMENTOS ===");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": sistema.CrearMedicamento(); break;
                case "2": sistema.ListarMedicamentos(); break;
                case "3": sistema.ActualizarMedicamento(); break;
                case "4": sistema.EliminarMedicamento(); break;
            }
        }

        static void SubMenuRecetas(SistemaFarmacia sistema)
        {
            Utils.LimpiarPantalla();
            Console.WriteLine("=== CRUD RECETAS MÉDICAS ===");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": sistema.CrearReceta(); break;
                case "2": sistema.ListarRecetas(); break;
                case "3": sistema.ActualizarReceta(); break;
                case "4": sistema.EliminarReceta(); break;
            }
        }

        static void SubMenuPedidos(SistemaFarmacia sistema)
        {
            Utils.LimpiarPantalla();
            Console.WriteLine("=== CRUD PEDIDOS ===");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Procesar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1": sistema.CrearPedido(); break;
                case "2": sistema.ListarPedidos(); break;
                case "3": sistema.ProcesarPedido(); break;
                case "4": sistema.EliminarPedido(); break;
            }
        }
    }
}