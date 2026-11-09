using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            var rand = new Random();
            List<List<double>> lista_mestra = new List<List<double>>();

            int numero_de_listas = 100;
            int tamanho = 10;

            for (int k = 0; k < numero_de_listas; k++)
            {
                var lista = new List<double>();
                for (int i = 0; i < tamanho; i++)
                    lista.Add(Math.Round((rand.NextDouble() * 2 - 1) * 100) / 100);
                lista_mestra.Add(lista);
            }

            // Inicializa com o primeiro elemento da primeira lista
            double maior = lista_mestra[0][0];
            double menor = lista_mestra[0][0];

            foreach (var sublista in lista_mestra)
            {
                foreach (double val in sublista)
                {
                    if (val > maior)
                    {
                        maior = val;
                    }
                    if (val < menor)
                    {
                        menor = val;
                    }
                }
            }

            Console.WriteLine($"Total de sublistas: {lista_mestra.Count}");
            Console.WriteLine($"Elementos por sublista: {tamanho}");
            Console.WriteLine($"Maior elemento entre todas as listas: {maior}");
            Console.WriteLine($"Menor elemento entre todas as listas: {menor}");
        }
    }
}
