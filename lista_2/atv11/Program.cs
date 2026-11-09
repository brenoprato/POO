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
                { "Nome", "Ouro" },
                { "Grupo", 11 },
                { "Período", 6 },
                { "Número Atômico", 79 },
                { "Massa Atômica", 197 }
            };

            var prata = new Dictionary<string, object>
            {
                { "Nome", "Prata" },
                { "Grupo", 11 },
                { "Período", 5 },
                { "Número Atômico", 47 },
                { "Massa Atômica", 108 }
            };

            var helio = new Dictionary<string, object>
            {
                { "Nome", "Hélio" },
                { "Grupo", 18 },
                { "Período", 1 },
                { "Número Atômico", 2 },
                { "Massa Atômica", 4 }
            };

            var cloro = new Dictionary<string, object>
            {
                { "Nome", "Cloro" },
                { "Grupo", 17 },
                { "Período", 3 },
                { "Número Atômico", 17 },
                { "Massa Atômica", 35 }
            };

            List<Dictionary<string, object>> elementos = new List<Dictionary<string, object>>
            {
                ouro,
                prata,
                helio,
                cloro
            };

            Console.WriteLine("--- Elementos Cadastrados ---");
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
