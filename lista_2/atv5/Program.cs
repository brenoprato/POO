using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Digite o tamanho das listas (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("O tamanho deve ser positivo.");
                return;
            }

            List<double> l1 = new List<double>();
            List<double> l2 = new List<double>();

            Console.WriteLine("\nPreenchimento da Lista 1:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"L1[{i}]: ");
                l1.Add(Convert.ToDouble(Console.ReadLine()));
            }

            Console.WriteLine("\nPreenchimento da Lista 2:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"L2[{i}]: ");
                l2.Add(Convert.ToDouble(Console.ReadLine()));
            }

            double alpha;
            do
            {
                Console.Write("\nDigite o valor de alfa (entre 0 e 1): ");
                alpha = Convert.ToDouble(Console.ReadLine());
                if (alpha < 0 || alpha > 1)
                {
                    Console.WriteLine("Valor inválido! Alfa deve pertencer ao intervalo [0, 1].");
                }
            } while (alpha < 0 || alpha > 1);

            List<double> l3 = new List<double>();
            for (int i = 0; i < n; i++)
            {
                double val = alpha * l1[i] + (1 - alpha) * l2[i];
                l3.Add(val);
            }

            Console.WriteLine("\nLista 1: " + string.Join(", ", l1));
            Console.WriteLine("Lista 2: " + string.Join(", ", l2));
            Console.WriteLine($"Alfa: {alpha}");
            Console.WriteLine("Lista 3 (Soma Convexa): " + string.Join(", ", l3));
        }
    }
}
