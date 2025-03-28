using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Digite o primeiro número: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o segundo número: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Escolha a operação:");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");

            Console.Write("Digite o número da operação desejada: ");
            int operacao = Convert.ToInt32(Console.ReadLine());

            double resultado = 0;
            bool operacaoValida = true;

            switch (operacao)
            {
                case 1:
                    resultado = num1 + num2;
                    break;
                case 2:
                    resultado = num1 - num2;
                    break;
                case 3:
                    resultado = num1 * num2;
                    break;
                case 4:
                    if (num2 != 0)
                        resultado = num1 / num2;
                    else
                    {
                        Console.WriteLine("Erro: Divisão por zero não é permitida.");
                        operacaoValida = false;
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida. Escolha um número entre 1 e 4.");
                    operacaoValida = false;
                    break;
            }

            if (operacaoValida)
                Console.WriteLine($"Resultado: {resultado}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Digite apenas números válidos.");
        }
    }
}
