using System;
using System.Collections.Generic;
using System.IO;

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public Contato(string nome, string telefone, string email)
    {
        Nome = nome;
        Telefone = telefone;
        Email = email;
    }
}

abstract class ContatoFormatter
{
    public abstract void ExibirContatos(List<Contato> contatos);
}

class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("## Lista de Contatos\n");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.Nome}\n");
            Console.WriteLine($"- Telefone: {contato.Telefone}\n");
            Console.WriteLine($"- Email: {contato.Email}\n");

        }
    }
}

class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("| Nome           | Telefone         | Email              |");
        Console.WriteLine("--------------------------------------------------");
        foreach (var contato in contatos)
        {
            Console.WriteLine($"| {contato.Nome,-14} | {contato.Telefone,-16} | {contato.Email,-20} |");
        }
        Console.WriteLine("--------------------------------------------------");
    }
}

class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        foreach (var contato in contatos)
        {
            Console.WriteLine($"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}");
        }
    }
}

class GerenciadorContatos
{
    static string caminhoArquivo = "contatos.txt";

    static void Main()
    {
        int opcao;
        do
        {
            ExibirMenu();
            opcao = LerOpcao();

            switch (opcao)
            {
                case 1:
                    AdicionarContato();
                    break;
                case 2:
                    List<Contato> contatos = CarregarContatos();
                    ExibirFormato(contatos);
                    break;
                case 3:
                    Console.WriteLine("Encerrando programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        } while (opcao != 3);
    }

    static void ExibirMenu()
    {
        Console.WriteLine("\n=== Gerenciador de Contatos ===");
        Console.WriteLine("1 - Adicionar novo contato");
        Console.WriteLine("2 - Listar contatos cadastrados");
        Console.WriteLine("3 - Sair");
        Console.Write("Escolha uma opção: ");
    }

    static int LerOpcao()
    {
        return int.TryParse(Console.ReadLine(), out int opcao) ? opcao : 0;
    }

    static void AdicionarContato()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        using (StreamWriter sw = File.AppendText(caminhoArquivo))
        {
            sw.WriteLine($"{nome},{telefone},{email}");
        }
        Console.WriteLine("Contato cadastrado com sucesso!");
    }

    static List<Contato> CarregarContatos()
    {
        List<Contato> contatos = new List<Contato>();
        if (File.Exists(caminhoArquivo))
        {
            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                string[] dados = linha.Split(',');
                if (dados.Length == 3)
                {
                    contatos.Add(new Contato(dados[0], dados[1], dados[2]));
                }
            }
        }
        return contatos;
    }

    static void ExibirFormato(List<Contato> contatos)
    {
        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("Escolha o formato de exibição:");
        Console.WriteLine("1 - Markdown");
        Console.WriteLine("2 - Tabela");
        Console.WriteLine("3 - Texto Puro");
        Console.Write("Opção: ");

        int opcao = LerOpcao();
        ContatoFormatter formatter;

        switch (opcao)
        {
            case 1:
                formatter = new MarkdownFormatter();
                break;
            case 2:
                formatter = new TabelaFormatter();
                break;
            case 3:
                formatter = new RawTextFormatter();
                break;
            default:
                Console.WriteLine("Opção inválida! Exibindo em formato de texto puro.");
                formatter = new RawTextFormatter();
                break;
        }
        formatter.ExibirContatos(contatos);
    }
}
