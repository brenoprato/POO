using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            const int nElementos = 10;
            Random rand = new Random();

            List<int> lista = new List<int>();

            for (int k = 0; k < nElementos; k++)
            {
                lista.Add(rand.Next(0, 100));
            }

            int i, j;

            do
            {
                Console.Write($"Digite i (0 até {nElementos - 1}): ");
                i = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Digite j (0 até {nElementos - 1}), com i < j: ");
                j = Convert.ToInt32(Console.ReadLine());

                if (i < 0 || j >= nElementos || i >= j)
                {
                    Console.WriteLine("Valores inválidos. É necessário que 0 <= i < j < 10.");
                }

            } while (i < 0 || j >= nElementos || i >= j);

            List<int> listaSwap = new List<int>(lista);
            (listaSwap[i], listaSwap[j]) = (listaSwap[j], listaSwap[i]);

            List<int> listaInvertida = new List<int>(lista);
            listaInvertida.Reverse(i, j - i + 1);

            List<int> listaInserida = new List<int>(lista);
            listaInserida.Insert(i, lista[j]);
            listaInserida.Insert(i + 1, lista[i]);

            Console.WriteLine("\nLista original: " +
                string.Join(", ", lista));

            Console.WriteLine("Lista com elementos trocados: " +
                string.Join(", ", listaSwap));

            Console.WriteLine("Lista com elementos invertidos: " +
                string.Join(", ", listaInvertida));

            Console.WriteLine("Lista com elementos inseridos: " +
                string.Join(", ", listaInserida));
        }
    }
}