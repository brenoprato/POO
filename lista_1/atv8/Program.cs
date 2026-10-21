using System;
using System.IO;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite a ordem das matrizes (n): ");
            int n = int.Parse(Console.ReadLine()!);

            Random rand = new Random();

            string[] linhasA = new string[n];
            string[] linhasB = new string[n];

            for (int i = 0; i < n; i++)
            {
                int[] linhaValoresA = new int[n];
                int[] linhaValoresB = new int[n];

                for (int j = 0; j < n; j++)
                {
                    linhaValoresA[j] = rand.Next(0, 100);
                    linhaValoresB[j] = rand.Next(0, 100);
                }

                linhasA[i] = string.Join(" ", linhaValoresA);
                linhasB[i] = string.Join(" ", linhaValoresB);
            }

            File.WriteAllLines("A.txt", linhasA);
            File.WriteAllLines("B.txt", linhasB);

            int[,] matrizA = LerMatriz("A.txt", n);
            int[,] matrizB = LerMatriz("B.txt", n);

            int[,] matrizC = new int[n, n];
            string[] linhasC = new string[n];

            for (int i = 0; i < n; i++)
            {
                int[] linhaValoresC = new int[n];
                for (int j = 0; j < n; j++)
                {
                    matrizC[i, j] = matrizA[i, j] + matrizB[i, j];
                    linhaValoresC[j] = matrizC[i, j];
                }
                linhasC[i] = string.Join(" ", linhaValoresC);
            }

            File.WriteAllLines("C.txt", linhasC);

            Console.WriteLine("\nMatriz A:");
            ExibirMatriz(matrizA);

            Console.WriteLine("\nMatriz B:");
            ExibirMatriz(matrizB);

            Console.WriteLine("\nMatriz C (A + B):");
            ExibirMatriz(matrizC);
        }

        static int[,] LerMatriz(string caminho, int n)
        {
            string[] linhas = File.ReadAllLines(caminho);
            int[,] matriz = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string[] partes = linhas[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; j++)
                {
                    matriz[i, j] = int.Parse(partes[j]);
                }
            }

            return matriz;
        }

        static void ExibirMatriz(int[,] matriz)
        {
            int n = matriz.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matriz[i, j],6}");
                }
                Console.WriteLine();
            }
        }
    }
}
