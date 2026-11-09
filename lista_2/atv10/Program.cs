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

            List<(int positivos, int negativos)> contagem = new List<(int positivos, int negativos)>();

            foreach (var sublista in lista_mestra)
            {
                int pos = 0;
                int neg = 0;

                foreach (double val in sublista)
                {
                    if (val > 0)
                        pos++;
                    else if (val < 0)
                        neg++;
                }

                contagem.Add((pos, neg));
            }

            Console.WriteLine("Contagem de positivos e negativos para cada lista k:");
            for (int k = 0; k < contagem.Count; k++)
            {
                Console.WriteLine($"Lista {k + 1:D3}: Positivos = {contagem[k].positivos}, Negativos = {contagem[k].negativos}");
            }
        }
    }
}
