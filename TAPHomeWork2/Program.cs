using System;

namespace TAPHomeWork2
{
    class Program
    {
        static bool ValidacionTamanoArray(int TamanoArray)
        {
            if (TamanoArray <= 0 | TamanoArray > Math.Pow(10, 5)) {
                Console.WriteLine("Tamaño de arreglo es menor o igual a 0 o mayor a 10^5.\nPress any key to exit.");
                Console.ReadKey();
                return true;
            }
            return false;
        }

        static bool ValidacionArray(string[] Array, int TamanoArray)
        {
            int iterador;
            if (Array.Length > TamanoArray | Array.Length < TamanoArray | Array.Length <= 0)
            {
                Console.WriteLine("Error en entrada de valores.\nPress any key to exit.");
                Console.ReadKey();
                return true;
            }
            else
            {
                for (iterador = 0; iterador < Array.Length; iterador++)
                {
                    if (int.Parse(Array[iterador]) < 0 | int.Parse(Array[iterador]) > 255)
                    {
                        Console.WriteLine("Hay un valor que es menor a 0 o mayor a 255.\nPress any key to exit.");
                        Console.ReadKey();
                        return true;
                    }
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            int TamanoArray = int.Parse(Console.ReadLine());

            if (ValidacionTamanoArray(TamanoArray)) {
                return;
            }

            string[] Array = Console.ReadLine().Split(' ');

            if (ValidacionArray(Array, TamanoArray)) {
                return;
            }       

            int TamanoArrayOperaciones = int.Parse(Console.ReadLine());
            string[] OperacionesArray = new string[TamanoArrayOperaciones];
            string LineaOperacion;
            int iterador;

            for (iterador = 0; iterador < TamanoArrayOperaciones; iterador++) {
                LineaOperacion = Console.ReadLine();
                OperacionesArray[iterador] = LineaOperacion;
            }

        }

    }
}
