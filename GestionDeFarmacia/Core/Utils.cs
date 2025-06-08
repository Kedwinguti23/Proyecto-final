using System;

namespace GestionDeFarmacia
{
    public static class Utils
    {
        public static int LeerEntero(string mensaje)
        {
            int valor;
            bool valido;

            do
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();
                valido = int.TryParse(entrada ?? "", out valor);

                if (!valido)
                {
                    Console.WriteLine("Entrada no válida. Intente de nuevo.\n");
                }
            } while (!valido);

            return valor;
        }

        public static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            bool valido;

            do
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();
                valido = decimal.TryParse(entrada ?? "", out valor);

                if (!valido)
                {
                    Console.WriteLine("Entrada no válida. Intente de nuevo.\n");
                }
            } while (!valido);

            return valor;
        }

        public static void Pausar()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        public static void LimpiarPantalla()
        {
            Console.Clear();
        }
    }
}
