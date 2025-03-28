using System;

class ContaBancaria
{
    public string Titular { get; set; }
    private decimal Saldo { get; set; }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
        }
        else
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
        }
    }

    public void Sacar(decimal valor)
    {
        if (valor > Saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
        }
        else
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
        }
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: R$ {Saldo:F2}");
    }
}

class Program
{
    static void Main()
    {
        ContaBancaria conta = new ContaBancaria
        {
            Titular = "Victória Lopes"
        };

        Console.WriteLine($"Titular: {conta.Titular}\n");

        conta.Depositar(1000);
        conta.ExibirSaldo();

        conta.Sacar(1500);
        conta.Sacar(500);
        conta.ExibirSaldo();
    }
}
