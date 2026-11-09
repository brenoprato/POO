using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            var rand = new Random();
            List<int> lista_exercicio_2 = new List<int>();

            for (int i = 0; i < 1000; i++)
                lista_exercicio_2.Add(Math.Abs((int)(100 * (rand.NextDouble() * 2 - 1))));

            List<int> pares = new List<int>();
            List<int> impares = new List<int>();

            foreach (int n in lista_exercicio_2)
            {
                if (n % 2 == 0)
                {
                    pares.Add(n);
                }
                else
                {
                    impares.Add(n);
                }
            }

            Console.WriteLine($"Total na lista original: {lista_exercicio_2.Count}");
            Console.WriteLine($"Total de pares: {pares.Count}");
            Console.WriteLine($"Total de ímpares: {impares.Count}");

            Console.WriteLine("\nElementos pares:");
            Console.WriteLine(string.Join(", ", pares));

            Console.WriteLine("\nElementos ímpares:");
            Console.WriteLine(string.Join(", ", impares));
        }
    }
}
