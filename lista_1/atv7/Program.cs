using System;

namespace MyApp
{
    internal class Program
    {
        static int BuscaLinearFor(int[] vec, int alvo)
        {
            for (int i = 0; i < vec.Length; i++)
            {
                if (vec[i] == alvo)
                {
                    return i;
                }
            }
            return -1;
        }

        static int BuscaLinearForeach(int[] vec, int alvo)
        {
            int indice = 0;
            foreach (int valor in vec)
            {
                if (valor == alvo)
                {
                    return indice;
                }
                indice++;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int[] vetor = { 12, 45, 7, 23, 89, 5, 34, 70 };

            Console.WriteLine("Vetor: " + string.Join(", ", vetor));

            Console.Write("Digite o número para buscar: ");
            int alvo = int.Parse(Console.ReadLine()!);

            int posFor = BuscaLinearFor(vetor, alvo);
            int posForeach = BuscaLinearForeach(vetor, alvo);

            Console.WriteLine($"\nBusca com for: índice {posFor}");
            Console.WriteLine($"Busca com foreach: índice {posForeach}");
        }
    }
}
