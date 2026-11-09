using System;

namespace MyApp
{
    public class Pessoa
    {
        private string nome = "";
        private int idade;

        public Pessoa(string nome, int idade)
        {
            set_nome(nome);
            set_idade(idade);
        }

        public string get_nome()
        {
            return this.nome;
        }

        public void set_nome(string nome)
        {
            this.nome = nome;
        }

        public int get_idade()
        {
            return this.idade;
        }

        public void set_idade(int idade)
        {
            if (idade > 0)
            {
                this.idade = idade;
            }
            else
            {
                Console.WriteLine("Idade inválida! Deve ser positiva.");
            }
        }

        public virtual void exibir_dados()
        {
            Console.WriteLine($"Nome: {this.nome}, Idade: {this.idade}");
        }
    }

    public class Aluno : Pessoa
    {
        private double nota;

        public Aluno(string nome, int idade, double nota) : base(nome, idade)
        {
            set_nota(nota);
        }

        public double get_nota()
        {
            return this.nota;
        }

        public void set_nota(double nota)
        {
            if (nota >= 0 && nota <= 10)
            {
                this.nota = nota;
            }
            else
            {
                Console.WriteLine("Nota inválida! Deve estar entre 0 e 10.");
            }
        }

        public override void exibir_dados()
        {
            Console.WriteLine($"Nome: {get_nome()}, Idade: {get_idade()}, Nota: {this.nota}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Pessoa p = new Pessoa("Carlos", 40);
            Aluno a = new Aluno("Ana", 20, 8.5);

            Console.WriteLine("--- Dados da Pessoa ---");
            p.exibir_dados();

            Console.WriteLine("\n--- Dados do Aluno ---");
            a.exibir_dados();

            Console.WriteLine("\n--- Teste de validações ---");
            p.set_idade(-5);
            a.set_nota(12);
        }
    }
}
