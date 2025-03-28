using System;

class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal SalarioBase { get; set; }

    public virtual void ExibirSalario()
    {
        Console.WriteLine($"{Nome}, Cargo: {Cargo}, Salário Base: R$ {SalarioBase:F2}");
    }
}

class Gerente : Funcionario
{
    public override void ExibirSalario()
    {
        decimal salarioComBonus = SalarioBase * 1.20m;
        Console.WriteLine($"{Nome}, Cargo: {Cargo}, Salário Base: R$ {SalarioBase:F2}, Salário com Bônus: R$ {salarioComBonus:F2}");
    }
}

class Program
{
    static void Main()
    {
        Funcionario funcionario = new Funcionario
        {
            Nome = "Angelica Oliveira",
            Cargo = "Assistente",
            SalarioBase = 3000
        };

        Gerente gerente = new Gerente
        {
            Nome = "Carla Pereira",
            Cargo = "Gerente",
            SalarioBase = 5000
        };

        funcionario.ExibirSalario();
        gerente.ExibirSalario();
    }
}
