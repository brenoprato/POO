using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Carta
    {
        private string valor;
        private string naipe;
        private double peso;

        public Carta(string valor, string naipe, double peso)
        {
            SetValor(valor);
            SetNaipe(naipe);
            SetPeso(peso);
        }

        public string GetValor()
        {
            return this.valor;
        }

        public void SetValor(string valor)
        {
            List<string> valoresValidos = new List<string> 
            { 
                "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" 
            };

            if (valoresValidos.Contains(valor))
            {
                this.valor = valor;
            }
        }

        public string GetNaipe()
        {
            return this.naipe;
        }

        public void SetNaipe(string naipe)
        {
            List<string> naipesValidos = new List<string> 
            { 
                "Paus", "Copas", "Espadas", "Ouros" 
            };

            if (naipesValidos.Contains(naipe))
            {
                this.naipe = naipe;
            }
        }

        public double GetPeso()
        {
            return this.peso;
        }

        public void SetPeso(double peso)
        {
            if (peso > 0)
            {
                this.peso = peso;
            }
        }

        public static bool operator >(Carta c1, Carta c2)
        {
            return c1.peso > c2.peso;
        }

        public static bool operator <(Carta c1, Carta c2)
        {
            return c1.peso < c2.peso;
        }

        public static bool operator ==(Carta c1, Carta c2)
        {
            return c1.peso == c2.peso;
        }

        public static bool operator !=(Carta c1, Carta c2)
        {
            return c1.peso != c2.peso;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Carta c1 = new Carta("A", "Espadas", 10);
            Carta c2 = new Carta("K", "Copas", 8);

            Console.WriteLine(c1.GetValor() + " de " + c1.GetNaipe() + " | Peso: " + c1.GetPeso());
            Console.WriteLine(c2.GetValor() + " de " + c2.GetNaipe() + " | Peso: " + c2.GetPeso());

            Console.WriteLine("c1 > c2: " + (c1 > c2));
            Console.WriteLine("c1 < c2: " + (c1 < c2));
            Console.WriteLine("c1 == c2: " + (c1 == c2));
        }
    }
}
