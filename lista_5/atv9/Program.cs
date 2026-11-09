using System;
using System.Collections.Generic;

namespace atv9
{
    // Interface que padroniza os métodos de locomoção
    public interface ITransporte
    {
        void Ligar();
        void Mover();
    }

    // Classe abstrata com propriedade de identificação e método concreto
    public abstract class Veiculo
    {
        public string Placa { get; set; }

        public Veiculo(string placa)
        {
            Placa = placa;
        }

        public void ExibirInfo()
        {
            Console.WriteLine($"Veículo com placa: {Placa}");
        }
    }

    public class Carro : Veiculo, ITransporte
    {
        public Carro(string placa) : base(placa) { }

        public void Ligar()
        {
            Console.WriteLine("Carro ligado: motor acionado.");
        }

        public void Mover()
        {
            Console.WriteLine("Carro em movimento pelas ruas.");
        }
    }

    public class Bicicleta : Veiculo, ITransporte
    {
        public Bicicleta(string placa) : base(placa) { }

        public void Ligar()
        {
            Console.WriteLine("Bicicleta pronta: não requer ignição.");
        }

        public void Mover()
        {
            Console.WriteLine("Bicicleta pedalando pela ciclovia.");
        }
    }

    public class Aviao : Veiculo, ITransporte
    {
        public Aviao(string placa) : base(placa) { }

        public void Ligar()
        {
            Console.WriteLine("Avião ligado: turbinas ativadas.");
        }

        public void Mover()
        {
            Console.WriteLine("Avião taxiando e decolando na pista.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<ITransporte> transportes = new List<ITransporte>
            {
                new Carro("BRA2E19"),
                new Bicicleta("BIC-2026"),
                new Aviao("PP-XYZ")
            };

            foreach (var item in transportes)
            {
                // Casting seguro com 'as' para acessar o método ExibirInfo() da classe abstrata base Veiculo
                Veiculo? v = item as Veiculo;
                if (v != null)
                {
                    v.ExibirInfo();
                }

                // Invocação polimórfica dos métodos da interface ITransporte
                item.Ligar();
                item.Mover();
                Console.WriteLine();
            }
        }
    }
}
