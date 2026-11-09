using System;

namespace MyApp
{
    internal class Q
    {
        private int Numerador;
        private int Denominador;

        public Q(int numerador, int denominador)
        {
            SetNumerador(numerador);
            SetDenominador(denominador);
        }

        public void SetNumerador(int n)
        {
            Numerador = n;
        }

        public int GetNumerador()
        {
            return Numerador;
        }

        public void SetDenominador(int n)
        {
            if (n != 0)
            {
                Denominador = n;
            }
            else
            {
                throw new Exception("Nao eh possivel definir denominador nulo.");
            }
        }

        public int GetDenominador()
        {
            return Denominador;
        }

        // Sobrescrita de ToString para permitir exibicao da fracao (item a)
        public override string ToString()
        {
            return $"{Numerador}/{Denominador}";
        }

        // Sobrecarga do operador + para permitir q1 + q2 (item b e e)
        public static Q operator +(Q a, Q b)
        {
            int num = a.Numerador * b.Denominador + b.Numerador * a.Denominador;
            int den = a.Denominador * b.Denominador;
            return new Q(num, den);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanciacao de q1 e q2
            Q q1 = new Q(1, 2);
            Q q2 = new Q(1, 1);

            // q3 agora e instanciado com new, tornando-se de fato um objeto (item d)
            Q q3 = new Q(3, 4);

            // Exibicao via ToString sobrescrito (item a)
            Console.WriteLine($"ToString: {q1}");

            // Exibicao fracionaria correta via getters respeitando encapsulamento (item c)
            Console.WriteLine($"Getters: {q1.GetNumerador()} / {q1.GetDenominador()}");

            // Soma utilizando o operador sobrecarregado + (item b)
            Console.WriteLine($"Soma (q1 + q2): {q1 + q2}");

            // Instanciacao de q4 protegida por try/catch para tratar a excecao de denominador nulo (item e)
            try
            {
                Console.WriteLine("Tentando instanciar q4 com denominador nulo...");
                Q q4 = new Q(1, 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excecao capturada: {ex.Message}");
            }
        }
    }
}
