using System;
using System.IO;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("dados");
            Directory.CreateDirectory("backup");

            string[] arquivos = Directory.GetFiles("dados");

            foreach (string arq in arquivos)
            {
                string nomeArquivo = Path.GetFileName(arq);
                string destino = "backup/" + nomeArquivo;
                File.Copy(arq, destino, true);
                Console.WriteLine($"Copiado: {nomeArquivo}");
            }
        }
    }
}
