using System;

class Aluno
{
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Curso { get; set; }
    public double Media { get; set; }

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Média: {Media:F2}");
    }

    public string VerificarAprovacao()
    {
        if (Media >= 7)
        {
            return "Aprovado";
        }
        else
        {
            return "Reprovado";
        }
    }
}

class Program
{
    static void Main()
    {
        Aluno aluno = new Aluno
        {
            Nome = "Victória Lopes",
            Matricula = "18137578709",
            Curso = "Engenharia de Software",
            Media = 8.5
        };

        aluno.ExibirDados();
        Console.WriteLine($"Status: {aluno.VerificarAprovacao()}");
    }
}
