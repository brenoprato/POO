using System;
using System.Collections.Generic;

namespace atv6
{
    // Classe base abstrata
    public abstract class Forma
    {
        // Método abstrato que obriga implementação nas subclasses
        public abstract double Area();

        // Método concreto herdado por todas as formas, invocando Area() polimorficamente
        public void ExibirArea()
        {
            Console.WriteLine($"Área da forma: {Area():F2}");
        }
    }

    public class Quadrado : Forma
    {
        public double Lado { get; set; }

        public Quadrado(double lado)
        {
            Lado = lado;
        }

        // Sobrescrita obrigatória do método abstrato
        public override double Area()
        {
            return Lado * Lado;
        }
    }

    public class Circulo : Forma
    {
        public double Raio { get; set; }

        public Circulo(double raio)
        {
            Raio = raio;
        }

        // Sobrescrita obrigatória do método abstrato
        public override double Area()
        {
            return Math.PI * Raio * Raio;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Lista polimórfica tipada pela classe abstrata Forma
            List<Forma> list = new List<Forma>();

            list.Add(new Quadrado(10));
            list.Add(new Circulo(5));
            list.Add(new Quadrado(5));
            list.Add(new Circulo(4));

            // Execução polimórfica: cada elemento executa seu respectivo cálculo de Area()
            foreach (var forma in list)
            {
                forma.ExibirArea();
            }
        }
    }
}
