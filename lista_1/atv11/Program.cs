using System;
using System.IO;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite a dimensão n da matriz quadrada: ");
            int n = int.Parse(Console.ReadLine());

            int[,] matriz = new int[n, n];
            Random rand = new Random();
            string textoArquivo = "";

            Console.WriteLine("\nMatriz gerada:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matriz[i, j] = rand.Next(1, 10);
                    Console.Write(matriz[i, j] + "\t");
                    textoArquivo += matriz[i, j] + " ";
                }
                Console.WriteLine();
                textoArquivo += "\n";
            }

            File.WriteAllText("matriz_magica.txt", textoArquivo);

            // Calcula a soma da primeira linha como referência
            int somaReferencia = 0;
            for (int j = 0; j < n; j++)
            {
                somaReferencia += matriz[0, j];
            }

            bool ehMagica = true;

            // Valida a soma de cada linha e de cada coluna
            for (int i = 0; i < n; i++)
            {
                int somaLinha = 0;
                int somaColuna = 0;

                for (int j = 0; j < n; j++)
                {
                    somaLinha += matriz[i, j];
                    somaColuna += matriz[j, i];
                }

                if (somaLinha != somaReferencia || somaColuna != somaReferencia)
                {
                    ehMagica = false;
                }
            }

            // Valida as diagonais principal e secundária
            int somaDiagPrincipal = 0;
            int somaDiagSecundaria = 0;

            for (int i = 0; i < n; i++)
            {
                somaDiagPrincipal += matriz[i, i];
                somaDiagSecundaria += matriz[i, n - 1 - i];
            }

            if (somaDiagPrincipal != somaReferencia || somaDiagSecundaria != somaReferencia)
            {
                ehMagica = false;
            }

            if (ehMagica)
            {
                Console.WriteLine("\nA matriz É uma matriz mágica!");
            }
            else
            {
                Console.WriteLine("\nA matriz NÃO é uma matriz mágica.");
            }
        }
    }
}
