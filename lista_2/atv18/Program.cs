using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            List<Dictionary<string, object>> lista_de_dicionarios =
                new List<Dictionary<string, object>>
                {
                    new Dictionary<string, object>{{"primeiro_nome","Paola"}, {"segundo_nome","Perez Ochoa"}, {"idade",72}},
                    new Dictionary<string, object>{{"primeiro_nome","Paola"}, {"segundo_nome","Mercedes"}, {"idade",22}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Bracho"}, {"idade",60}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Mercedes"}, {"idade",91}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Bracho"}, {"idade",35}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Perez Ochoa"}, {"idade",26}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Perez Ochoa"}, {"idade",71}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Bracho"}, {"idade",73}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Bracho"}, {"idade",72}},
                    new Dictionary<string, object>{{"primeiro_nome","Paola"}, {"segundo_nome","Bracho"}, {"idade",83}},
                    new Dictionary<string, object>{{"primeiro_nome","Paola"}, {"segundo_nome","Mercedes"}, {"idade",63}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Bracho"}, {"idade",21}},
                    new Dictionary<string, object>{{"primeiro_nome","Paola"}, {"segundo_nome","Bracho"}, {"idade",86}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Perez Ochoa"}, {"idade",69}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Mercedes"}, {"idade",80}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Bracho"}, {"idade",87}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Perez Ochoa"}, {"idade",61}},
                    new Dictionary<string, object>{{"primeiro_nome","Paola"}, {"segundo_nome","Perez Ochoa"}, {"idade",21}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Mercedes"}, {"idade",56}},
                    new Dictionary<string, object>{{"primeiro_nome","Paola"}, {"segundo_nome","Bracho"}, {"idade",24}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Mercedes"}, {"idade",70}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Perez Ochoa"}, {"idade",69}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Bracho"}, {"idade",94}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Bracho"}, {"idade",35}},
                    new Dictionary<string, object>{{"primeiro_nome","Paola"}, {"segundo_nome","Bracho"}, {"idade",54}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Mercedes"}, {"idade",66}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Perez Ochoa"}, {"idade",83}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Perez Ochoa"}, {"idade",26}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Mercedes"}, {"idade",49}},
                    new Dictionary<string, object>{{"primeiro_nome","Paola"}, {"segundo_nome","Bracho"}, {"idade",57}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Bracho"}, {"idade",97}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Bracho"}, {"idade",42}},
                    new Dictionary<string, object>{{"primeiro_nome","Paola"}, {"segundo_nome","Mercedes"}, {"idade",82}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Bracho"}, {"idade",56}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Mercedes"}, {"idade",29}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Mercedes"}, {"idade",29}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Bracho"}, {"idade",19}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Mercedes"}, {"idade",90}},
                    new Dictionary<string, object>{{"primeiro_nome","Rubi"}, {"segundo_nome","Perez Ochoa"}, {"idade",52}},
                    new Dictionary<string, object>{{"primeiro_nome","Maria"}, {"segundo_nome","Bracho"}, {"idade",71}}
                };

            // Adiciona a chave "categoria" conforme a regra
            foreach (var dict in lista_de_dicionarios)
            {
                string primeiroNome = (string)dict["primeiro_nome"];
                dict["categoria"] = (primeiroNome == "Maria") ? "Mocinha" : "Vilã";
            }

            Console.WriteLine("--- Dicionários com a chave 'categoria' ---");
            for (int i = 0; i < lista_de_dicionarios.Count; i++)
            {
                var d = lista_de_dicionarios[i];
                Console.WriteLine($"Item {i + 1:D2}: {d["primeiro_nome"]} {d["segundo_nome"]} ({d["idade"]} anos) -> Categoria: {d["categoria"]}");
            }
        }
    }
}
