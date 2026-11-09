using System;
using System.IO;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite a quantidade de arquivos (N): ");
            int n = int.Parse(Console.ReadLine());

            Directory.CreateDirectory("dados");

            for (int i = 0; i < n; i++)
            {
                string caminho = $"dados/valor_{i}.txt";
                File.WriteAllText(caminho, i.ToString());
            }

            Console.WriteLine("\nArquivos criados:");
            string[] arquivos = Directory.GetFiles("dados");
            foreach (string arq in arquivos)
            {
                Console.WriteLine(Path.GetFileName(arq));
            }
        }
    }
}
