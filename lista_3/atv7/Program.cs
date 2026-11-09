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

    public class Baralho_de_Truco : Baralho
    {
        private Carta? vira;

        public Baralho_de_Truco() : base(
            new List<string> { "4", "5", "6", "7", "Q", "J", "K", "A", "2", "3" },
            new List<string> { "Paus", "Copas", "Espadas", "Ouros" }
        )
        {
            this.vira = null;
        }

        public Carta? get_vira() => this.vira;
        public void set_vira(Carta? vira) => this.vira = vira;

        // Retorna o peso base inicial da carta de truco (0 a 9)
        private double calcula_peso_truco(string valor)
        {
            switch (valor)
            {
                case "4": return 0;
                case "5": return 1;
                case "6": return 2;
                case "7": return 3;
                case "Q": return 4;
                case "J": return 5;
                case "K": return 6;
                case "A": return 7;
                case "2": return 8;
                case "3": return 9;
                default: return 0;
            }
        }

        // Constrói o baralho de truco com os pesos base
        public override void constroi_baralho()
        {
            this.cartas.Clear();
            for (int i = 0; i < this.valores_validos.Count; i++)
            {
                string valor = this.valores_validos[i];
                double peso = calcula_peso_truco(valor);
                for (int j = 0; j < this.naipes_validos.Count; j++)
                {
                    string naipe = this.naipes_validos[j];
                    this.cartas.Add(new Carta(valor, naipe, peso));
                }
            }
        }

        // Escolhe aleatoriamente uma carta do baralho como vira e atualiza os pesos
        public void define_vira()
        {
            if (this.cartas.Count == 0) return;

            Random rand = new Random();
            int idx = rand.Next(0, this.cartas.Count);
            this.vira = this.cartas[idx];
            atualiza_pesos();
        }

        // Atualiza os pesos das manilhas conforme o valor da carta vira
        public void atualiza_pesos()
        {
            if (this.vira == null) return;

            // Restaura os pesos base antes de aplicar novas manilhas
            for (int i = 0; i < this.cartas.Count; i++)
            {
                this.cartas[i].set_peso(calcula_peso_truco(this.cartas[i].get_valor()));
            }

            // Ordem circular do truco: 4, 5, 6, 7, Q, J, K, A, 2, 3
            List<string> ordemTruco = new List<string> { "4", "5", "6", "7", "Q", "J", "K", "A", "2", "3" };
            int idxVira = ordemTruco.IndexOf(this.vira.get_valor());
            string valorManilha = ordemTruco[(idxVira + 1) % ordemTruco.Count];

            // Manilhas recebem pesos especiais baseados no naipe: Ouros=10, Espadas=11, Copas=12, Paus=13
            for (int i = 0; i < this.cartas.Count; i++)
            {
                Carta c = this.cartas[i];
                if (c.get_valor() == valorManilha)
                {
                    if (c.get_naipe() == "Ouros") c.set_peso(10);
                    else if (c.get_naipe() == "Espadas") c.set_peso(11);
                    else if (c.get_naipe() == "Copas") c.set_peso(12);
                    else if (c.get_naipe() == "Paus") c.set_peso(13);
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Baralho_de_Truco truco = new Baralho_de_Truco();

            Console.WriteLine("=== CARTAS E PESOS ANTES DE DEFINE_VIRA ===");
            truco.mostra_cartas();

            truco.define_vira();

            Carta? vira = truco.get_vira();
            if (vira != null)
            {
                Console.WriteLine($">>> Carta Vira selecionada: {vira.get_valor()} de {vira.get_naipe()} <<<\n");
            }

            Console.WriteLine("=== CARTAS E PESOS DEPOIS DE DEFINE_VIRA ===");
            truco.mostra_cartas();
        }
    }
}
