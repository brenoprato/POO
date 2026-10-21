using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite a quantidade de nomes (M): ");
            int m = int.Parse(Console.ReadLine()!);

            string[] nomes = new string[m];

            for (int i = 0; i < m; i++)
            {
                Console.Write($"Digite o nome {i + 1}: ");
                nomes[i] = Console.ReadLine()!;
            }

            Console.Write("\nDigite o nome alvo: ");
            string alvo = Console.ReadLine()!;

            int contagem = 0;
            int indice = 0;

            Console.Write("Índices onde aparece: ");
            foreach (string nome in nomes)
            {
                if (nome == alvo)
                {
                    contagem++;
                    Console.Write(indice + " ");
                }
                indice++;
            }

            Console.WriteLine($"\nOcorrências: {contagem}");
        }
    }
}
