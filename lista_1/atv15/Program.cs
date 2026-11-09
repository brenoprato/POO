using System;
using System.IO;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("dados");

            string[] arquivos = Directory.GetFiles("dados", "*.txt");
            int soma = 0;

            foreach (string arq in arquivos)
            {
                if (Path.GetFileName(arq) != "soma.txt")
                {
                    string texto = File.ReadAllText(arq);
                    soma += int.Parse(texto.Trim());
                }
            }

            File.WriteAllText("dados/soma.txt", soma.ToString());
            Console.WriteLine($"Soma total salva em dados/soma.txt: {soma}");
        }
    }
}
