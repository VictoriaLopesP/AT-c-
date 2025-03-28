using System;
using System.IO;

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
                    ListarContatos();
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
        int opcao;
        return int.TryParse(Console.ReadLine(), out opcao) ? opcao : 0;
    }

    static void AdicionarContato()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        try
        {
            using (StreamWriter sw = File.AppendText(caminhoArquivo))
            {
                sw.WriteLine($"{nome},{telefone},{email}");
            }
            Console.WriteLine("Contato cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar contato: {ex.Message}");
        }
    }

    static void ListarContatos()
    {
        if (!File.Exists(caminhoArquivo) || new FileInfo(caminhoArquivo).Length == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        try
        {
            Console.WriteLine("\nContatos cadastrados:");
            using (StreamReader sr = new StreamReader(caminhoArquivo))
            {
                string linha;
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] dados = linha.Split(',');
                    if (dados.Length == 3)
                    {
                        Console.WriteLine($"Nome: {dados[0]} | Telefone: {dados[1]} | Email: {dados[2]}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao ler contatos: {ex.Message}");
        }
    }
}
