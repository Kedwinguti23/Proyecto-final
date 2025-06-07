using System;

namespace GestionDeFarmacia.Core
{
    public static class Utils
    {
        public static void Pausar()
        {
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadKey();
        }

        public static void LimpiarPantalla()
        {
            Console.Clear();
        }

        public static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write(" Entrada inválida. Intente de nuevo: ");
            }
            return valor;
        }

        public static decimal LeerDecimal(string mensaje)
        {
            decimal valor;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write(" Entrada inválida. Intente de nuevo: ");
            }
            return valor;
        }
    }
}