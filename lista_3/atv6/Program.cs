using System;
using System.Collections.Generic;

namespace MyApp
{
    public class Carta
    {
        private string valor = "";
        private string naipe = "";
        private double peso;

        public Carta(string valor, string naipe, double peso)
        {
            set_valor(valor);
            set_naipe(naipe);
            set_peso(peso);
        }

        public string get_valor() => this.valor;
        public string GetValor() => this.valor;
        public void set_valor(string valor)
        {
            List<string> permitidos = new List<string>
            {
                "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"
            };

            if (permitidos.Contains(valor))
            {
                this.valor = valor;
            }
        }
        public void SetValor(string valor) => set_valor(valor);

        public string get_naipe() => this.naipe;
        public string GetNaipe() => this.naipe;
        public void set_naipe(string naipe)
        {
            List<string> permitidos = new List<string>
            {
                "Paus", "Copas", "Espadas", "Ouros"
            };

            if (permitidos.Contains(naipe))
            {
                this.naipe = naipe;
            }
        }
        public void SetNaipe(string naipe) => set_naipe(naipe);

        public double get_peso() => this.peso;
        public double GetPeso() => this.peso;
        public void set_peso(double peso)
        {
            if (peso >= 0)
            {
                this.peso = peso;
            }
        }
        public void SetPeso(double peso) => set_peso(peso);

        public static bool operator >(Carta c1, Carta c2) => c1.peso > c2.peso;
        public static bool operator <(Carta c1, Carta c2) => c1.peso < c2.peso;
        public static bool operator ==(Carta? c1, Carta? c2)
        {
            if (ReferenceEquals(c1, c2)) return true;
            if (c1 is null || c2 is null) return false;
            return c1.peso == c2.peso;
        }
        public static bool operator !=(Carta? c1, Carta? c2) => !(c1 == c2);

        public override bool Equals(object? obj)
        {
            if (obj is Carta outra) return this == outra;
            return false;
        }

        public override int GetHashCode() => peso.GetHashCode();
    }

    public class Baralho
    {
        protected List<string> valores_validos;
        protected List<string> naipes_validos;
        protected List<Carta> cartas;
        protected int quantidade_baralhos;

        public Baralho()
        {
            this.valores_validos = new List<string>
            {
                "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"
            };
            this.naipes_validos = new List<string>
            {
                "Paus", "Copas", "Espadas", "Ouros"
            };
            this.quantidade_baralhos = 1;
            this.cartas = new List<Carta>();
            constroi_baralho();
        }

        public Baralho(List<string> valores_validos, List<string> naipes_validos, int quantidade_baralhos = 1)
        {
            this.valores_validos = valores_validos;
            this.naipes_validos = naipes_validos;
            this.quantidade_baralhos = quantidade_baralhos;
            this.cartas = new List<Carta>();
            constroi_baralho();
        }

        public List<string> get_valores_validos() => this.valores_validos;
        public void set_valores_validos(List<string> valores) => this.valores_validos = valores;

        public List<string> get_naipes_validos() => this.naipes_validos;
        public void set_naipes_validos(List<string> naipes) => this.naipes_validos = naipes;

        public List<Carta> get_cartas() => this.cartas;
        public void set_cartas(List<Carta> cartas) => this.cartas = cartas;

        // Calcula o peso referente ao valor da carta (A=1, J=11, Q=12, K=13)
        protected virtual double calcula_peso(string valor)
        {
            if (valor == "A") return 1;
            if (valor == "J") return 11;
            if (valor == "Q") return 12;
            if (valor == "K") return 13;
            return double.Parse(valor);
        }

        // Confecciona todas as cartas possíveis com seus respectivos pesos
        public virtual void constroi_baralho()
        {
            this.cartas.Clear();
            for (int k = 0; k < this.quantidade_baralhos; k++)
            {
                for (int i = 0; i < this.valores_validos.Count; i++)
                {
                    string valor = this.valores_validos[i];
                    double peso = calcula_peso(valor);
                    for (int j = 0; j < this.naipes_validos.Count; j++)
                    {
                        string naipe = this.naipes_validos[j];
                        this.cartas.Add(new Carta(valor, naipe, peso));
                    }
                }
            }
        }

        public void embaralha()
        {
            Random rand = new Random();
            for (int i = this.cartas.Count - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                Carta temp = this.cartas[i];
                this.cartas[i] = this.cartas[j];
                this.cartas[j] = temp;
            }
        }

        public void mostra_cartas()
        {
            if (this.cartas.Count == 0)
            {
                Console.WriteLine("O baralho está vazio.");
                return;
            }

            for (int i = 0; i < this.cartas.Count; i++)
            {
                Carta c = this.cartas[i];
                Console.WriteLine($"{c.get_valor()} de {c.get_naipe()} (Peso: {c.get_peso()})");
            }
            Console.WriteLine($"Total: {this.cartas.Count} cartas.\n");
        }

        public Carta? retira_carta_aleatoria()
        {
            if (this.cartas.Count == 0)
            {
                return null;
            }

            Random rand = new Random();
            int idx = rand.Next(0, this.cartas.Count);
            Carta escolhida = this.cartas[idx];
            this.cartas.RemoveAt(idx);
            return escolhida;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> naipes = new List<string> { "Paus", "Copas", "Espadas", "Ouros" };

            // Baralho Italiano: sem 8, 9 e 10 (40 cartas)
            List<string> valoresItaliano = new List<string> { "A", "2", "3", "4", "5", "6", "7", "J", "Q", "K" };
            Baralho baralhoItaliano = new Baralho(valoresItaliano, naipes);

            // Baralho Inglês: todas as 13 cartas (52 cartas)
            List<string> valoresIngles = new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            Baralho baralhoIngles = new Baralho(valoresIngles, naipes);

            // Baralho Inglês Duplo: dois baralhos ingleses (104 cartas)
            Baralho baralhoInglesDuplo = new Baralho(valoresIngles, naipes, 2);

            Console.WriteLine("================ BARALHO ITALIANO ================");
            baralhoItaliano.mostra_cartas();

            Console.WriteLine("================ BARALHO INGLÊS ================");
            baralhoIngles.mostra_cartas();

            Console.WriteLine("================ BARALHO INGLÊS DUPLO ================");
            baralhoInglesDuplo.mostra_cartas();
        }
    }
}
