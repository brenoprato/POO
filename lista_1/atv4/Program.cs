using System;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Digite x numeros separados por espaço (ex: 1 2 3 4 5.2 5):");
            string input = Console.ReadLine();
            string[] numerosStr = input.Split(' ');
            int maior = 0, menor = 0, media = 0;

            foreach (string n in numerosStr)
            {
                int num = Convert.ToInt32(n);
                if (num > maior)
                {
                    maior = num;
                }
                if (num < menor || menor == 0)
                {
                    menor = num;
                }
                media += num;
            }

            media /= numerosStr.Length;
            Console.WriteLine($"O maior número é: {maior}");
            Console.WriteLine($"O menor número é: {menor}");
            Console.WriteLine($"A média dos números é: {media:F2}");
        }
    }
}