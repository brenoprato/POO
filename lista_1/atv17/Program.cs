using System;
using System.IO;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("dados");
            Directory.CreateDirectory("lixeira");

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                File.WriteAllText($"dados/valor_{i}.txt", rand.Next(0, 100).ToString());
            }

            string[] arquivos = Directory.GetFiles("dados", "valor_*.txt");
            int movidos = 0;
            int deletados = 0;
            int mantidos = 0;

            foreach (string arq in arquivos)
            {
                int valor = int.Parse(File.ReadAllText(arq).Trim());
                string nome = Path.GetFileName(arq);

                if (valor < 10)
                {
                    File.Delete(arq);
                    deletados++;
                }
                else if (valor <= 50)
                {
                    File.Move(arq, "lixeira/" + nome, true);
                    movidos++;
                }
                else
                {
                    mantidos++;
                }
            }

            Console.WriteLine("Relatório Final:");
            Console.WriteLine($"Arquivos deletados (valor < 10): {deletados}");
            Console.WriteLine($"Arquivos movidos para lixeira (10 <= valor <= 50): {movidos}");
            Console.WriteLine($"Arquivos mantidos em dados (valor > 50): {mantidos}");
        }
    }
}
