using System;

class JogoAdivinhacao
{
    static void Main()
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 51);
        int tentativasRestantes = 5;
        bool acertou = false;

        Console.WriteLine("Jogo de Adivinhação!");
        Console.WriteLine("Tente adivinhar um número entre 1 e 50 :)");

        while (tentativasRestantes > 0)
        {
            Console.Write($"Você tem {tentativasRestantes} tentativas. Digite um número: ");

            try
            {
                int palpite = int.Parse(Console.ReadLine());

                if (palpite < 1 || palpite > 50)
                {
                    Console.WriteLine("Erro: O número deve estar entre 1 e 50.");
                    continue;
                }

                if (palpite == numeroSecreto)
                {
                    Console.WriteLine($"Parabéns, você acertou o número {numeroSecreto}.");
                    acertou = true;
                    break;
                }
                else if (palpite < numeroSecreto)
                {
                    Console.WriteLine("Tente um número maior.");
                }
                else
                {
                    Console.WriteLine("Tente um número menor.");
                }

                tentativasRestantes--;
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Digite apenas números inteiros.");
            }
        }

        if (!acertou)
        {
            Console.WriteLine($"Fim do jogo! O número correto era {numeroSecreto}.");
        }
    }
}
