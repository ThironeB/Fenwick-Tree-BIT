using System;

namespace FenwickTree
{

    public class BIT
    {
        private int[,] _BIT;

        public BIT()
        {
            _BIT = new int[,] { { } };
        }

        public int[,] get()
        {
            return _BIT;
        }

        public int lowbit(int Iterator)
        {
            return (Iterator & -(Iterator));
        }

        public void update(int Position, int Value)
        {
            for (int i = Position; i < _BIT.GetLength(0); i += lowbit(i)) {
                _BIT[i, 0] &= Value;
                _BIT[i, 1] |= Value;
                _BIT[i, 2] ^= Value;
            }
        }

        public void getSOR(int Position)
        {
            int Value = 0;
            for (int i = Position; i > 0; i -= lowbit(i))
            {
                Value ^= _BIT[i, 2];
            }
            Console.WriteLine(Value);
            Console.ReadLine();
        }

        public void build(string[] Array)
        {
            _BIT = new int[Array.Length + 1,3];

            for (int i = 0; i < Array.Length; i++) {
                update(i + 1, int.Parse(Array[i]));
                //Console.WriteLine(_BIT[i + 1, 0] + " " + _BIT[i + 1, 1] + " " + _BIT[i + 1, 2]);
            }

            //Console.ReadLine();
        }
    }

    class FenwickTree
    {
        static bool ValidacionTamanoArray(int TamanoArray)
        {
            if (TamanoArray <= 0 || TamanoArray > Math.Pow(10, 5)) {
                Console.WriteLine("Tamaño de arreglo es menor o igual a 0 o mayor a 10^5.\nPress any key to exit.");
                Console.ReadKey();
                return true;
            }
            return false;
        }

        static bool ValidacionArray(string[] Array, int TamanoArray)
        {
            int iterador;
            if (Array.Length > TamanoArray || Array.Length < TamanoArray || Array.Length <= 0)
            {
                Console.WriteLine("Error en entrada de valores.\nPress any key to exit.");
                Console.ReadKey();
                return true;
            }
            else
            {
                for (iterador = 0; iterador < Array.Length; iterador++)
                {
                    if (int.Parse(Array[iterador]) < 0 || int.Parse(Array[iterador]) > 255)
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

            BIT bit = new BIT();

            bit.build(Array);
            bit.getSOR(4);

        }

    }
}
