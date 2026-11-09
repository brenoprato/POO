using System;
using System.Collections.Generic;

namespace atv7
{
    // Interface que define o contrato para qualquer objeto imprimível
    public interface IImprimivel
    {
        void Imprimir();
    }

    public class Relatorio : IImprimivel
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }

        public Relatorio(string titulo, string conteudo)
        {
            Titulo = titulo;
            Conteudo = conteudo;
        }

        // Implementação do contrato da interface (sem uso de override)
        public void Imprimir()
        {
            Console.WriteLine("================================");
            Console.WriteLine($"RELATÓRIO: {Titulo}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine(Conteudo);
            Console.WriteLine("================================\n");
        }
    }

    public class Etiqueta : IImprimivel
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public Etiqueta(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        // Implementação do contrato da interface simulando um rótulo
        public void Imprimir()
        {
            Console.WriteLine($"[ETIQUETA] Código: {Codigo} | Descrição: {Descricao}\n");
        }
    }

    internal class Program
    {
        // Método polimórfico que aceita qualquer coleção de objetos que implementem IImprimivel
        static void ProcessarImpressao(List<IImprimivel> itens)
        {
            foreach (var item in itens)
            {
                // Invocação polimórfica de Imprimir()
                item.Imprimir();
            }
        }

        static void Main(string[] args)
        {
            List<IImprimivel> itens = new List<IImprimivel>
            {
                new Relatorio("Balanço Trimestral", "Resultados financeiros acima do esperado."),
                new Etiqueta("ETQ-4091", "Monitor UltraWide 34 polegadas"),
                new Relatorio("Auditoria de Segurança", "Nenhuma vulnerabilidade crítica encontrada."),
                new Etiqueta("ETQ-8820", "Teclado Mecânico ABNT2")
            };

            ProcessarImpressao(itens);
        }
    }
}
