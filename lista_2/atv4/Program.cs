using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            var rand = new Random();
            List<int> lista_original = new List<int>();

            for (int i = 0; i < 1000; i++)
                lista_original.Add(Math.Abs((int)(100 * (rand.NextDouble() * 2 - 1))));

            // Constrói a lista espelhada percorrendo a original de trás para frente
            List<int> lista_espelhada = new List<int>();
            for (int i = lista_original.Count - 1; i >= 0; i--)
            {
                lista_espelhada.Add(lista_original[i]);
            }

            Console.WriteLine($"Quantidade de elementos: {lista_original.Count}");
            Console.WriteLine("\nLista original:");
            Console.WriteLine(string.Join(", ", lista_original));

            Console.WriteLine("\nLista espelhada:");
            Console.WriteLine(string.Join(", ", lista_espelhada));
        }
    }
}
