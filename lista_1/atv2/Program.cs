using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float n1, n2;
            Console.WriteLine("Digite o primeiro numero:");
            n1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo numero:");
            n2 = float.Parse(Console.ReadLine());

            Console.WriteLine($"A soma de {n1} e {n2} é: {n1 + n2} \n A subtração de {n1} e {n2} é: {n1 - n2} \n A multiplicação de {n1} e {n2} é: {n1 * n2} \n A divisão inteira é {n1} e {n2} é: {(int)n1 / (int)n2} \n A divisão real de {n1} e {n2} é: {n1 / n2:F2}");
        }
    }
}