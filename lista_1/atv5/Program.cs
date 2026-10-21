using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            int [] vec = new int[n];

            for (int i = 0; i < n; i++)
            {
                vec[i] = i * i;
            }   

            foreach (int i in vec)
            {
                Console.Write(i + " ");
            }

            int soma_impar = 0;

            Console.WriteLine("\nApenas os pares: ");

            foreach (int i in vec)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }else
                {
                    soma_impar += i;
                }
            }

            Console.WriteLine("\nSoma dos impares: " + soma_impar);
        }
    }
}
