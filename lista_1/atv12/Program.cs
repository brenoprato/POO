using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite seu nome:");
            string nome = Console.ReadLine();
            Console.WriteLine($"Olá, {nome}! qual é sua linguagem de programação favorita?");
            string linguagem = Console.ReadLine();
            Console.WriteLine($"Legal, {nome}! {linguagem} é uma ótima linguagem.");
        }
    }
}