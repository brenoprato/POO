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
            this.cartas = new List<Carta>();
            constroi_baralho();
        }

        public Baralho(List<string> valores_validos, List<string> naipes_validos)
        {
            this.valores_validos = valores_validos;
            this.naipes_validos = naipes_validos;
            this.cartas = new List<Carta>();
            constroi_baralho();
        }

        public List<string> get_valores_validos() => this.valores_validos;
        public void set_valores_validos(List<string> valores) => this.valores_validos = valores;

        public List<string> get_naipes_validos() => this.naipes_validos;
        public void set_naipes_validos(List<string> naipes) => this.naipes_validos = naipes;

        public List<Carta> get_cartas() => this.cartas;
        public void set_cartas(List<Carta> cartas) => this.cartas = cartas;

        // Confecciona todas as cartas possíveis a partir de valores_validos e naipes_validos
        public virtual void constroi_baralho()
        {
            this.cartas.Clear();
            for (int i = 0; i < this.valores_validos.Count; i++)
            {
                for (int j = 0; j < this.naipes_validos.Count; j++)
                {
                    this.cartas.Add(new Carta(this.valores_validos[i], this.naipes_validos[j], 1.0));
                }
            }
        }

        // Embaralha aleatoriamente as cartas utilizando Fisher-Yates
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

        // Retira e retorna uma carta aleatória do baralho
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
            Baralho b = new Baralho();

            Console.WriteLine("=== Baralho Recém-Criado ===");
            b.mostra_cartas();

            Console.WriteLine("=== Embaralhando Baralho ===");
            b.embaralha();
            b.mostra_cartas();

            Console.WriteLine("=== Retirando 3 cartas aleatórias ===");
            for (int i = 1; i <= 3; i++)
            {
                Carta? retirada = b.retira_carta_aleatoria();
                if (retirada != null)
                {
                    Console.WriteLine($"Carta {i} retirada: {retirada.get_valor()} de {retirada.get_naipe()}");
                }
            }

            Console.WriteLine($"\nRestaram {b.get_cartas().Count} cartas no baralho.");
        }
    }
}
