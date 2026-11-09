using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Digite o número de elementos a cadastrar (n): ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n <= 0)
            {
                Console.WriteLine("O valor de n deve ser positivo.");
                return;
            }

            List<Dictionary<string, object>> elementos = new List<Dictionary<string, object>>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Cadastro do Elemento {i + 1} ---");
                var elemento = new Dictionary<string, object>();

                Console.Write("Nome: ");
                elemento["Nome"] = Console.ReadLine() ?? string.Empty;

                Console.Write("Grupo: ");
                elemento["Grupo"] = Convert.ToInt32(Console.ReadLine());

                Console.Write("Período: ");
                elemento["Período"] = Convert.ToInt32(Console.ReadLine());

                Console.Write("Número Atômico: ");
                elemento["Número Atômico"] = Convert.ToInt32(Console.ReadLine());

                Console.Write("Massa Atômica: ");
                elemento["Massa Atômica"] = Convert.ToDouble(Console.ReadLine());

                elementos.Add(elemento);
            }

            Console.WriteLine("\n=== Lista de Dicionários Cadastrados ===");
            for (int i = 0; i < elementos.Count; i++)
            {
                Console.WriteLine($"\nElemento {i + 1}:");
                foreach (var par in elementos[i])
                {
                    Console.WriteLine($"  {par.Key}: {par.Value}");
                }
            }
        }
    }
}
