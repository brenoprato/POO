using System;
using System.Globalization;
using System.IO;

namespace MyApp
{
    internal class Program
    {
        static double[,] Normalizar(double[,] matriz)
        {
            int linhas = matriz.GetLength(0);
            int colunas = matriz.GetLength(1);
            double[,] normalizada = new double[linhas, colunas];

            for (int coluna = 0; coluna < colunas; coluna++)
            {
                double minimo = matriz[0, coluna];
                double maximo = matriz[0, coluna];

                for (int linha = 1; linha < linhas; linha++)
                {
                    if (matriz[linha, coluna] < minimo)
                        minimo = matriz[linha, coluna];

                    if (matriz[linha, coluna] > maximo)
                        maximo = matriz[linha, coluna];
                }

                for (int linha = 0; linha < linhas; linha++)
                {
                    // Quando a coluna é constante, não existe divisão por zero.
                    if (maximo == minimo)
                        normalizada[linha, coluna] = 0;
                    else
                        normalizada[linha, coluna] =
                            2 * ((matriz[linha, coluna] - minimo) / (maximo - minimo)) - 1;
                }
            }

            return normalizada;
        }

        static void SalvarCsv(string nomeArquivo, double[,] matriz)
        {
            string conteudo = "";
            int linhas = matriz.GetLength(0);
            int colunas = matriz.GetLength(1);

            for (int linha = 0; linha < linhas; linha++)
            {
                for (int coluna = 0; coluna < colunas; coluna++)
                {
                    if (coluna > 0)
                        conteudo += ",";

                    conteudo += matriz[linha, coluna]
                        .ToString("F6", CultureInfo.InvariantCulture);
                }

                conteudo += Environment.NewLine;
            }

            File.WriteAllText(nomeArquivo, conteudo);
        }

        static void Imprimir(string titulo, double[,] matriz)
        {
            Console.WriteLine(titulo);

            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                    Console.Write($"{matriz[linha, coluna],10:F3}");

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        static int LerInteiroPositivo(string mensagem)
        {
            int valor;

            do
            {
                Console.Write(mensagem);
                valor = int.Parse(Console.ReadLine() ?? "0");
            } while (valor <= 0);

            return valor;
        }

        static double LerReal(string mensagem)
        {
            Console.Write(mensagem);
            string entrada = Console.ReadLine() ?? "0";

            // Permite que o usuário digite tanto 1.5 quanto 1,5.
            entrada = entrada.Replace(',', '.');
            return double.Parse(entrada, CultureInfo.InvariantCulture);
        }

        static void Main(string[] args)
        {
            int linhas = LerInteiroPositivo("Número de linhas: ");
            int colunas = LerInteiroPositivo("Número de colunas: ");
            double[,] matriz = new double[linhas, colunas];

            for (int linha = 0; linha < linhas; linha++)
            {
                for (int coluna = 0; coluna < colunas; coluna++)
                {
                    matriz[linha, coluna] =
                        LerReal($"Matriz[{linha}, {coluna}]: ");
                }
            }

            double[,] normalizada = Normalizar(matriz);

            Imprimir("Matriz original:", matriz);
            Imprimir("Matriz normalizada:", normalizada);

            SalvarCsv("matriz_original.csv", matriz);
            SalvarCsv("matriz_normalizada.csv", normalizada);

            Console.WriteLine("Arquivos salvos:");
            Console.WriteLine("matriz_original.csv");
            Console.WriteLine("matriz_normalizada.csv");
        }
    }
}
