using System;
using System.Collections.Generic;

namespace atv8
{
    // Classe abstrata com estado protegido e método abstrato
    public abstract class Funcionario
    {
        public string Nome { get; set; }
        protected double SalarioBase { get; set; }

        public Funcionario(string nome, double salarioBase)
        {
            Nome = nome;
            SalarioBase = salarioBase;
        }

        // Método abstrato a ser implementado por cada tipo de funcionário
        public abstract double CalcularSalario();
    }

    // Interface para avaliação de desempenho
    public interface IAvaliavel
    {
        void AvaliarDesempenho();
    }

    // Gerente herda de Funcionario e implementa IAvaliavel
    public class Gerente : Funcionario, IAvaliavel
    {
        public double Bonus { get; set; }

        public Gerente(string nome, double salarioBase, double bonus)
            : base(nome, salarioBase)
        {
            Bonus = bonus;
        }

        // Sobrescrita do cálculo salarial (polimorfismo via classe abstrata)
        public override double CalcularSalario()
        {
            return SalarioBase + Bonus;
        }

        // Implementação do contrato da interface IAvaliavel
        public void AvaliarDesempenho()
        {
            if (Bonus >= 3000)
                Console.WriteLine("Desempenho Excelente: liderança acima do esperado.");
            else if (Bonus >= 1500)
                Console.WriteLine("Desempenho Bom: atingiu as metas de gestão.");
            else
                Console.WriteLine("Desempenho Insuficiente: precisa melhorar indicadores de liderança.");
        }
    }

    // Vendedor herda de Funcionario e implementa IAvaliavel
    public class Vendedor : Funcionario, IAvaliavel
    {
        public double Comissao { get; set; }

        public Vendedor(string nome, double salarioBase, double comissao)
            : base(nome, salarioBase)
        {
            Comissao = comissao;
        }

        // Sobrescrita do cálculo salarial (polimorfismo via classe abstrata)
        public override double CalcularSalario()
        {
            return SalarioBase + Comissao;
        }

        // Implementação do contrato da interface IAvaliavel
        public void AvaliarDesempenho()
        {
            if (Comissao >= 2000)
                Console.WriteLine("Desempenho Excelente: vendas excepcionais.");
            else if (Comissao >= 800)
                Console.WriteLine("Desempenho Bom: metas de vendas atingidas.");
            else
                Console.WriteLine("Desempenho Insuficiente: metas de vendas não atingidas.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Gerente g1 = new Gerente("Alice Silva", 6000.0, 3500.0);
            Gerente g2 = new Gerente("Roberto Costa", 5000.0, 1200.0);
            Vendedor v1 = new Vendedor("Carlos Souza", 2500.0, 2200.0);
            Vendedor v2 = new Vendedor("Mariana Dias", 2200.0, 600.0);

            // Lista polimórfica de Funcionario
            List<Funcionario> funcionarios = new List<Funcionario> { g1, g2, v1, v2 };

            // Lista polimórfica de IAvaliavel com os mesmos objetos
            List<IAvaliavel> avaliaveis = new List<IAvaliavel> { g1, g2, v1, v2 };

            Console.WriteLine("=== Folha de Pagamento (List<Funcionario>) ===");
            foreach (var func in funcionarios)
            {
                // Chamada polimórfica de CalcularSalario()
                Console.WriteLine($"Nome: {func.Nome} | Tipo: {func.GetType().Name} | Salário Total: R$ {func.CalcularSalario():F2}");
            }

            Console.WriteLine("\n=== Avaliações de Desempenho (List<IAvaliavel>) ===");
            foreach (var item in avaliaveis)
            {
                // Casting seguro com 'as' para recuperar o Nome e Tipo do funcionário
                Funcionario? f = item as Funcionario;
                if (f != null)
                {
                    Console.Write($"[{f.GetType().Name}] {f.Nome} -> ");
                }

                // Chamada polimórfica da interface
                item.AvaliarDesempenho();
            }
        }
    }
}
