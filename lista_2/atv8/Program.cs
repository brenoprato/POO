using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Digite o número de alunos: ");
            int numero_de_alunos = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o número de provas por aluno: ");
            int numero_de_provas_por_aluno = Convert.ToInt32(Console.ReadLine());

            if (numero_de_alunos <= 0 || numero_de_provas_por_aluno <= 0)
            {
                Console.WriteLine("Os valores devem ser inteiros positivos.");
                return;
            }

            List<List<object>> lista_de_notas_dos_alunos = new List<List<object>>();

            for (int i = 0; i < numero_de_alunos; i++)
            {
                List<object> aluno = new List<object>();

                Console.Write($"\nDigite o nome do aluno {i + 1}: ");
                string nome = Console.ReadLine() ?? string.Empty;
                aluno.Add(nome);

                double somaNotas = 0;
                for (int j = 0; j < numero_de_provas_por_aluno; j++)
                {
                    Console.Write($"Digite a nota da prova {j + 1}: ");
                    double nota = Convert.ToDouble(Console.ReadLine());
                    aluno.Add(nota);
                    somaNotas += nota;
                }

                double media = somaNotas / numero_de_provas_por_aluno;
                aluno.Add(media);

                lista_de_notas_dos_alunos.Add(aluno);
            }

            Console.WriteLine("\n--- Apresentação da lista_de_notas_dos_alunos ---");
            for (int i = 0; i < lista_de_notas_dos_alunos.Count; i++)
            {
                Console.WriteLine($"Item {i}: [" + string.Join(", ", lista_de_notas_dos_alunos[i]) + "]");
            }
        }
    }
}
