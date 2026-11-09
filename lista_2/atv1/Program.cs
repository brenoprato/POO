using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            var rand = new Random();
            List<double> lista_exercicio_1 = new List<double>();

            for (int i = 0; i < 1000; i++)
                lista_exercicio_1.Add(rand.NextDouble() * 2 - 1); // entre -1 e 1

            // Inicializa maior e menor com o primeiro elemento da lista
            double maior = lista_exercicio_1[0];
            double menor = lista_exercicio_1[0];

            foreach (double x in lista_exercicio_1)
            {
                if (x > maior)
                {
                    maior = x;
                }
                if (x < menor)
                {
                    menor = x;
                }
            }

            Console.WriteLine($"Total de elementos: {lista_exercicio_1.Count}");
            Console.WriteLine($"Maior elemento: {maior}");
            Console.WriteLine($"Menor elemento: {menor}");
        }
    }
}
