using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            int n_elementos = 10;
            var rand = new Random();
            List<int> n1 = new List<int>();
            List<int> n2 = new List<int>();
            
            for (int i = 0; i < n_elementos; i++)
            {
                n1.Add(rand.Next(0, 100));
                n2.Add(rand.Next(0, 100));
            }

            Console.WriteLine($"Digite um ponto de corte entre 0 e {n1.Count - 1}:");
            int corte = Convert.ToInt32(Console.ReadLine());

            List<int> n1_cut = new List<int>();
            List<int> n2_cut = new List<int>();

            for (int i = 0; i < n_elementos; i++)
            {
                if (i < corte)
                {
                    n1_cut.Add(n1[i]);
                    n2_cut.Add(n2[i]);
                } else 
                {
                    n1_cut.Add(n2[i]);
                    n2_cut.Add(n1[i]);
                }
            }

            Console.WriteLine("Lista 1 original: " + string.Join(", ", n1));
            Console.WriteLine("Lista 2 original: " + string.Join(", ", n2));
            Console.WriteLine("Lista 1 cortada: " + string.Join(", ", n1_cut));
            Console.WriteLine("Lista 2 cortada: " + string.Join(", ", n2_cut));

        }
    }
}