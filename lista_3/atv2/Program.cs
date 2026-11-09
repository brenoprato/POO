using System;

namespace MyApp
{
    public class Numero_Natural
    {
        protected int n;

        // Construtor que recebe um inteiro
        public Numero_Natural(int n)
        {
            set_n(n);
        }

        // Construtor que recebe um literal (string) representando um inteiro
        public Numero_Natural(string n)
        {
            int valor = int.Parse(n);
            set_n(valor);
        }

        public virtual void set_n(int n)
        {
            if (n > 0)
            {
                this.n = n;
            }
            else
            {
                Console.WriteLine("Valor inválido para número natural! Deve ser positivo.");
            }
        }

        public int get_n()
        {
            return this.n;
        }
    }

    public class Numero_Inteiro : Numero_Natural
    {
        public Numero_Inteiro(int n) : base(1)
        {
            set_n(n);
        }

        public Numero_Inteiro(string n) : base(1)
        {
            int valor = int.Parse(n);
            set_n(valor);
        }

        // Polimorfismo: aceita qualquer inteiro (positivo, negativo ou zero)
        public override void set_n(int n)
        {
            this.n = n;
        }
    }

    public class Numero_Racional
    {
        private Numero_Inteiro numerador;
        private Numero_Inteiro denominador;

        public Numero_Racional(Numero_Inteiro numerador, Numero_Inteiro denominador)
        {
            this.numerador = new Numero_Inteiro(0);
            this.denominador = new Numero_Inteiro(1);

            set_numerador(numerador);
            set_denominador(denominador);
        }

        public Numero_Inteiro get_numerador()
        {
            return this.numerador;
        }

        public void set_numerador(Numero_Inteiro numerador)
        {
            if (numerador != null)
            {
                this.numerador = numerador;
            }
        }

        public Numero_Inteiro get_denominador()
        {
            return this.denominador;
        }

        public void set_denominador(Numero_Inteiro denominador)
        {
            // Denominador não pode ser nulo nem assumir valor zero
            if (denominador != null && denominador.get_n() != 0)
            {
                this.denominador = denominador;
            }
            else
            {
                Console.WriteLine("Denominador inválido! Não pode ser nulo nem zero.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Teste Numero_Natural ---");
            Numero_Natural nat1 = new Numero_Natural(5);
            Numero_Natural nat2 = new Numero_Natural("10");
            Console.WriteLine("nat1: " + nat1.get_n());
            Console.WriteLine("nat2: " + nat2.get_n());

            Console.WriteLine("Tentando atribuir -3 a Numero_Natural:");
            nat1.set_n(-3);

            Console.WriteLine("\n--- Teste Numero_Inteiro ---");
            Numero_Inteiro inte1 = new Numero_Inteiro(-15);
            Numero_Inteiro inte2 = new Numero_Inteiro("0");
            Console.WriteLine("inte1: " + inte1.get_n());
            Console.WriteLine("inte2: " + inte2.get_n());

            Console.WriteLine("\n--- Teste Numero_Racional ---");
            Numero_Inteiro num = new Numero_Inteiro(3);
            Numero_Inteiro den = new Numero_Inteiro(4);
            Numero_Racional rac = new Numero_Racional(num, den);
            Console.WriteLine("Racional: " + rac.get_numerador().get_n() + " / " + rac.get_denominador().get_n());

            Console.WriteLine("Tentando definir denominador com zero:");
            rac.set_denominador(new Numero_Inteiro(0));
        }
    }
}
