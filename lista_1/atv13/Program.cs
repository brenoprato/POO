using System;
using System.Diagnostics;

namespace MyApp
{
    internal class Program
    {
        // Rotação 90° horário utilizando matriz auxiliar: aux[j, n - 1 - i] = mat[i, j]
        static int[,] RotacionarComAuxiliar(int[,] mat)
        {
            int n = mat.GetLength(0);
            int[,] aux = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    aux[j, n - 1 - i] = mat[i, j];
                }
            }

            return aux;
        }

        // Rotação 90° horário in-place (sem alocação de matriz adicional)
        static void RotacionarInPlace(int[,] mat)
        {
            int n = mat.GetLength(0);

            // 1) Transposição da matriz
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int temp = mat[i, j];
                    mat[i, j] = mat[j, i];
                    mat[j, i] = temp;
                }
            }

            // 2) Inversão horizontal das colunas de cada linha
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = mat[i, j];
                    mat[i, j] = mat[i, n - 1 - j];
                    mat[i, n - 1 - j] = temp;
                }
            }
        }

        static void ImprimirMatriz(int[,] mat)
        {
            int n = mat.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mat[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int[,] exemplo = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Console.WriteLine("Matriz Original:");
            ImprimirMatriz(exemplo);

            int[,] rotAux = RotacionarComAuxiliar(exemplo);
            Console.WriteLine("\nRotacionada com Matriz Auxiliar:");
            ImprimirMatriz(rotAux);

            RotacionarInPlace(exemplo);
            Console.WriteLine("\nRotacionada In-Place:");
            ImprimirMatriz(exemplo);

            int[] tamanhos = { 100, 500, 1000 };
            Random rand = new Random();

            Console.WriteLine("\nComparação de Tempos:");
            Console.WriteLine("N\tAuxiliar (ms)\tIn-Place (ms)");

            foreach (int n in tamanhos)
            {
                int[,] m1 = new int[n, n];
                int[,] m2 = new int[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int v = rand.Next(0, 100);
                        m1[i, j] = v;
                        m2[i, j] = v;
                    }
                }

                Stopwatch sw1 = Stopwatch.StartNew();
                RotacionarComAuxiliar(m1);
                sw1.Stop();

                Stopwatch sw2 = Stopwatch.StartNew();
                RotacionarInPlace(m2);
                sw2.Stop();

                Console.WriteLine($"{n}\t{sw1.Elapsed.TotalMilliseconds:F4}\t\t{sw2.Elapsed.TotalMilliseconds:F4}");
            }
        }
    }
}
