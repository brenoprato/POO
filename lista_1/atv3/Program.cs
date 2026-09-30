using System;

class Program
{
    static void Main()
    {
        int opcao;

        do
        {
            Console.WriteLine("\n========== MENU ==========");
            Console.WriteLine("1 - Calcular IMC");
            Console.WriteLine("2 - Converter Celsius -> Fahrenheit");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            
            // Tenta converter a entrada do usuário para int
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        MenuIMC();
                        break;
                    case 2:
                        MenuTemperatura();
                        break;
                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida! Digite apenas números.");
                opcao = -1; // Mantém o loop ativo
            }

        } while (opcao != 0);
    }

    static void MenuIMC()
    {
        Console.WriteLine("\n--- Calculadora de IMC ---");
        Console.Write("Digite o seu peso em kg (ex: 70,5): ");
        double peso = Convert.ToDouble(Console.ReadLine());

        Console.Write("Digite a sua altura em metros (ex: 1,75): ");
        double altura = Convert.ToDouble(Console.ReadLine());

        double imc = CalcularIMC(peso, altura);

        Console.WriteLine($"\nResultado: Seu IMC é {imc:F2}");
    }

    static void MenuTemperatura()
    {
        Console.WriteLine("\n--- Conversor de Temperatura ---");
        Console.Write("Digite a temperatura em graus Celsius: ");
        double celsius = Convert.ToDouble(Console.ReadLine());
        double fahrenheit = ConverterParaFahrenheit(celsius);

        Console.WriteLine($"\nResultado: {celsius}°C equivale a {fahrenheit:F2}°F");
    }

    static double CalcularIMC(double peso, double altura)
    {
        return peso / Math.Pow(altura, 2); 
    }

    static double ConverterParaFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }
}