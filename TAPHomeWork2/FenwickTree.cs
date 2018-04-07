using System;
using System.Collections.Generic;

namespace FenwickTree
{
    public class BIT
    {
        private int[] _BIT;
        private string[] _Binary;

        public BIT(int BITSize, string[] Binary)
        {
            _BIT = new int[BITSize + 1];
            _Binary = new string[Binary.Length];

            for (int i = 0; i < Binary.Length; i++)
            {
                _Binary[i] = Binary[i];
            }
           

            for (int i = 1; i < BITSize + 1; i++)
            {
                _BIT[i] = 0;
            }
        }

        public int lowbit(int Iterator)
        {
            return (Iterator & -(Iterator));
        }

        public void update(int Position, int Value)
        {
            for (int i = Position; i < _BIT.Length; i += lowbit(i)) {
                _BIT[i] += Value;             
            }
        }

        public void update2(int Position, int Value)

        {
            for (int i = Position; i < _BIT.Length; i += lowbit(i))
            {
                if(int.Parse(_Binary[Position-1]) == 0 && Value == 1)
                {
                    _BIT[i] += 1;
                }else if (int.Parse(_Binary[Position-1]) == 1 && Value == 0)
                {
                    _BIT[i] -= 1;
                }             
            }
        }

        public int SUM(int Position)
        {
            int Value = 0;
            for (int i = Position; i > 0; i -= lowbit(i))
            {
                Value += _BIT[i];
            }
            return Value;
        }

        public string getSUM(int From, int To, string Operator)
        {
            string bit = "";
            int SUMAcum;
            SUMAcum = SUM(To) - SUM(From - 1);

            switch (Operator)
            {
                case "AND":
                    if ((To - (From - 1)) - SUMAcum == 0)
                    {
                        bit = "1";
                    }
                    else
                    {
                        bit = "0";
                    }
                    break;
                case "OR":
                    if (SUMAcum > 0)
                    {
                        bit = "1";
                    }
                    else
                    {
                        bit = "0";
                    }
                    break;
                case "XOR":
                    if (SUMAcum % 2 != 0)
                    {
                        bit = "1";
                    }
                    else
                    {
                        bit = "0";
                    }
                    break;
            }

            return bit;
        }

        public void build(string[] Array)
        {
            for (int i = 0; i < Array.Length; i++) {
                update(i + 1, int.Parse(Array[i]));
            }
        }
    }

    class FenwickTree
    {
        static void Main(string[] args)
        {
            int TamanoArray = int.Parse(Console.ReadLine());
            string[] Array = Console.ReadLine().Split(' ');
            int BITSize = Array.Length;
            int TamanoArrayOperaciones = int.Parse(Console.ReadLine());
            string[] OperacionesArray;
            string LineaOperacion;
            int iterador;
            string Acumulado = "";

            List<BIT> bit = new List<BIT>();
            string Binary = string.Empty;
            string[] BinaryArray = new string[BITSize];

            for (int i = 0; i < 8; i++)
            {
                for (int k = 0; k < BITSize; k++)
                {
                    Binary = Convert.ToString(int.Parse(Array[k]), 2).PadLeft(8, '0');
                    var BinaryCharArray = Binary.ToCharArray();
                    BinaryArray[k] = BinaryCharArray[i].ToString();
                }

                bit.Add(new BIT(BITSize, BinaryArray));
                bit[i].build(BinaryArray);
            }

            List<int> Result = new List<int>();
            for (iterador = 0; iterador < TamanoArrayOperaciones; iterador++) {
                LineaOperacion = Console.ReadLine();
                OperacionesArray = LineaOperacion.Split(' ');

                if (OperacionesArray[0] != "UPDATE") {
                    for (int i = 0; i < 8; i++) {
                        Acumulado = Acumulado + bit[i].getSUM(int.Parse(OperacionesArray[1]) + 1, int.Parse(OperacionesArray[2]) + 1, OperacionesArray[0]);
                    }

                    Result.Add(Convert.ToInt32(Acumulado, 2));
                    Acumulado = "";
                }
                else {
                    Binary = Convert.ToString(int.Parse(OperacionesArray[2]), 2).PadLeft(8, '0');

                    for (int i = 0; i < 8; i++)
                    {
                        bit[i].update2(int.Parse(OperacionesArray[1]) + 1, int.Parse(Binary[i].ToString()));
                    }
                }
                
            }

            for (int i = 0; i < Result.Count; i++) {
                Console.WriteLine(Result[i]);
            }

            Console.Read();
        }

    }
}