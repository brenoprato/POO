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

            string maiorConcatenacao = (string)lista_de_dicionarios[0]["primeiro_nome"] + (string)lista_de_dicionarios[0]["segundo_nome"];

            foreach (var dict in lista_de_dicionarios)
            {
                string conc = (string)dict["primeiro_nome"] + (string)dict["segundo_nome"];
                if (conc.Length > maiorConcatenacao.Length)
                {
                    maiorConcatenacao = conc;
                }
            }

            Console.WriteLine($"Concatenação com maior número de caracteres: \"{maiorConcatenacao}\"");
            Console.WriteLine($"Comprimento: {maiorConcatenacao.Length}");
            Console.WriteLine($"Tipo: {maiorConcatenacao.GetType()}");
        }
    }
}
