using System;
using System.IO;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite a quantidade de linhas (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Digite o tamanho máximo das linhas (m): ");
            int m = int.Parse(Console.ReadLine());

            int[][] jagged = new int[n][];
            Random rand = new Random();
            string[] linhasCsv = new string[n];

            // Gera e preenche a jagged array com tamanhos aleatórios no intervalo [1, m]
            Console.WriteLine("\nJagged array original:");
            for (int i = 0; i < n; i++)
            {
                int tamanho = rand.Next(1, m + 1);
                jagged[i] = new int[tamanho];

                for (int j = 0; j < tamanho; j++)
                {
                    jagged[i][j] = rand.Next(0, 101);
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine();
                linhasCsv[i] = string.Join(",", jagged[i]);
            }

            // Grava a matriz denteada no formato CSV
            File.WriteAllLines("jagged.csv", linhasCsv);

            // Lê o arquivo gerado e valida se confere com os dados originais
            string[] linhasLidas = File.ReadAllLines("jagged.csv");
            bool iguais = true;

            if (linhasLidas.Length != n)
            {
                iguais = false;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    string[] valoresStr = linhasLidas[i].Split(',');
                    if (valoresStr.Length != jagged[i].Length)
                    {
                        iguais = false;
                        break;
                    }

                    for (int j = 0; j < valoresStr.Length; j++)
                    {
                        if (int.Parse(valoresStr[j]) != jagged[i][j])
                        {
                            iguais = false;
                            break;
                        }
                    }
                }
            }

            if (iguais)
            {
                Console.WriteLine("\nOs dados do arquivo jagged.csv correspondem à jagged array original.");
            }
            else
            {
                Console.WriteLine("\nOs dados do arquivo não correspondem à original.");
            }
        }
    }
}
