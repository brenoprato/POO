using System;

namespace MyApp
{
    public class Numero_Natural
    {
        protected int n;

        public Numero_Natural(int n)
        {
            set_n(n);
        }

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
            if (denominador != null && denominador.get_n() != 0)
            {
                this.denominador = denominador;
            }
            else
            {
                Console.WriteLine("Denominador inválido! Não pode ser nulo nem zero.");
            }
        }

        // Apresenta numerador / denominador
        public void show()
        {
            Console.WriteLine($"{this.numerador.get_n()} / {this.denominador.get_n()}");
        }

        // Sobrecarga da soma de dois números racionais: (a1*b2 + a2*b1) / (b1*b2)
        public static Numero_Racional operator +(Numero_Racional r1, Numero_Racional r2)
        {
            int a1 = r1.numerador.get_n();
            int b1 = r1.denominador.get_n();
            int a2 = r2.numerador.get_n();
            int b2 = r2.denominador.get_n();

            int novoNum = (a1 * b2) + (a2 * b1);
            int novoDen = b1 * b2;

            return new Numero_Racional(new Numero_Inteiro(novoNum), new Numero_Inteiro(novoDen));
        }

        // Sobrecarga de igualdade: frações a1/b1 e a2/b2 são iguais se a1*b2 == a2*b1
        public static bool operator ==(Numero_Racional? r1, Numero_Racional? r2)
        {
            if (ReferenceEquals(r1, r2)) return true;
            if (r1 is null || r2 is null) return false;

            return r1.numerador.get_n() * r2.denominador.get_n() ==
                   r2.numerador.get_n() * r1.denominador.get_n();
        }

        public static bool operator !=(Numero_Racional? r1, Numero_Racional? r2)
        {
            return !(r1 == r2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Numero_Racional outro)
            {
                return this == outro;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (numerador.get_n() * 397) ^ denominador.get_n();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Numero_Racional r1 = new Numero_Racional(new Numero_Inteiro(1), new Numero_Inteiro(2));
            Numero_Racional r2 = new Numero_Racional(new Numero_Inteiro(1), new Numero_Inteiro(3));
            Numero_Racional r3 = new Numero_Racional(new Numero_Inteiro(2), new Numero_Inteiro(4));

            Console.Write("r1 = ");
            r1.show();

            Console.Write("r2 = ");
            r2.show();

            Console.Write("r3 = ");
            r3.show();

            // Teste da soma
            Numero_Racional soma = r1 + r2;
            Console.Write("\nr1 + r2 = ");
            soma.show();

            // Teste da igualdade
            Console.WriteLine($"\nr1 == r2? {r1 == r2}");
            Console.WriteLine($"r1 == r3? {r1 == r3} (pois 1/2 equivale a 2/4)");
            Console.WriteLine($"r1 != r2? {r1 != r2}");
        }
    }
}
