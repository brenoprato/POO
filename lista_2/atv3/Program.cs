using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Digite a quantidade de valores (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("O valor de n deve ser positivo.");
                return;
            }

            List<double> valores = new List<double>();

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Digite o {i + 1}º valor: ");
                double valor = Convert.ToDouble(Console.ReadLine());
                valores.Add(valor);
            }

            double soma = 0;
            double menor = valores[0];
            double maior = valores[0];

            foreach (double v in valores)
            {
                soma += v;
                if (v < menor) menor = v;
                if (v > maior) maior = v;
            }

            double media = soma / valores.Count;

            Console.WriteLine("\nLista preenchida: " + string.Join(", ", valores));
            Console.WriteLine($"Soma dos valores: {soma}");
            Console.WriteLine($"Média dos valores: {media}");
            Console.WriteLine($"Menor valor: {menor}");
            Console.WriteLine($"Maior valor: {maior}");
        }
    }
}
