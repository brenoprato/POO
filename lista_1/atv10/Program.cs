using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o número de linhas (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Digite o número de colunas (m): ");
            int m = int.Parse(Console.ReadLine());

            int[,] matriz = new int[n, m];
            Random rand = new Random();

            Console.WriteLine("\nMatriz:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matriz[i, j] = rand.Next(0, 100);
                    Console.Write(matriz[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n(a) Soma por linha:");
            for (int i = 0; i < n; i++)
            {
                int somaLinha = 0;
                for (int j = 0; j < m; j++)
                {
                    somaLinha += matriz[i, j];
                }
                Console.WriteLine($"Linha {i}: {somaLinha}");
            }

            Console.WriteLine("\n(b) Soma por coluna:");
            for (int j = 0; j < m; j++)
            {
                int somaColuna = 0;
                for (int i = 0; i < n; i++)
                {
                    somaColuna += matriz[i, j];
                }
                Console.WriteLine($"Coluna {j}: {somaColuna}");
            }

            int maior = matriz[0, 0];
            int linhaMaior = 0;
            int colunaMaior = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matriz[i, j] > maior)
                    {
                        maior = matriz[i, j];
                        linhaMaior = i;
                        colunaMaior = j;
                    }
                }
            }

            Console.WriteLine($"\n(c) Maior elemento: {maior} na posição [{linhaMaior}, {colunaMaior}]");
        }
    }
}
