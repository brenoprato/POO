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
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Cria o vetor com 3 posicoes para referencias (todas inicialmente null)
            Q[] fracoes = new Q[3];

            // Instancia explicitamente cada objeto na Heap antes de utiliza-lo, evitando NullReferenceException
            fracoes[0] = new Q(1, 2);
            fracoes[1] = new Q(3, 4);
            fracoes[2] = new Q(5, 6);

            // Itera sobre o vetor e exibe os valores das fracoes
            for (int i = 0; i < fracoes.Length; i++)
            {
                Console.WriteLine($"Fracao {i + 1}: {fracoes[i].GetNumerador()}/{fracoes[i].GetDenominador()}");
            }
        }
    }
}
