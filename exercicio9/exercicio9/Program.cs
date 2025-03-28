using System;
using System.IO;

class Program
{
    static string filePath = "estoque.txt";
    static string[] produtos = new string[5];
    static int contador = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Inserir Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    InserirProduto();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    static void InserirProduto()
    {
        if (contador >= 5)
        {
            Console.WriteLine("Limite de produtos atingido!");
            return;
        }

        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Quantidade em estoque: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade))
        {
            Console.WriteLine("Quantidade inválida!");
            return;
        }

        Console.Write("Preço unitário: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
        {
            Console.WriteLine("Preço inválido!");
            return;
        }

        string produto = $"{nome},{quantidade},{preco:F2}";
        produtos[contador++] = produto;

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine(produto);
        }

        Console.WriteLine("Produto cadastrado com sucesso!");
    }

    static void ListarProdutos()
    {
        if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("\nProdutos cadastrados:");
        using (StreamReader sr = new StreamReader(filePath))
        {
            string linha;
            while ((linha = sr.ReadLine()) != null)
            {
                string[] dados = linha.Split(',');
                Console.WriteLine($"Produto: {dados[0]} | Quantidade: {dados[1]} | Preço: R$ {dados[2]}");
            }
        }
    }
}
