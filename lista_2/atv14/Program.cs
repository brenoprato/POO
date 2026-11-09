using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            var ouro = new Dictionary<string, object>
            {
                { "Nome", "Au" },
                { "Grupo", 11 },
                { "Período", 6 },
                { "Número Atômico", 79 },
                { "Massa Atômica", 197 },
                { "Estado físico (CNTP)", "Sólido" }
            };

            var prata = new Dictionary<string, object>
            {
                { "Nome", "Ag" },
                { "Grupo", 11 },
                { "Período", 5 },
                { "Número Atômico", 47 },
                { "Massa Atômica", 108 },
                { "Estado físico (CNTP)", "Sólido" }
            };

            var helio = new Dictionary<string, object>
            {
                { "Nome", "He" },
                { "Grupo", 18 },
                { "Período", 1 },
                { "Número Atômico", 2 },
                { "Massa Atômica", 4 },
                { "Estado físico (CNTP)", "Gasoso" }
            };

            var cloro = new Dictionary<string, object>
            {
                { "Nome", "Cl" },
                { "Grupo", 17 },
                { "Período", 3 },
                { "Número Atômico", 17 },
                { "Massa Atômica", 35 },
                { "Estado físico (CNTP)", "Gasoso" }
            };

            List<Dictionary<string, object>> elementos = new List<Dictionary<string, object>>
            {
                ouro,
                prata,
                helio,
                cloro
            };

            // Remoção da chave "Grupo" de todos os dicionários
            foreach (var elemento in elementos)
            {
                elemento.Remove("Grupo");
            }

            Console.WriteLine("--- Elementos após a remoção da chave 'Grupo' ---");
            foreach (var elemento in elementos)
            {
                foreach (var par in elemento)
                {
                    Console.Write($"{par.Key}: {par.Value} | ");
                }
                Console.WriteLine();
            }
        }
    }
}
