using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite seu nome completo: ");
        string nome = Console.ReadLine();
        string nomeCifrado = CifrarNome(nome);
        Console.WriteLine($"Nome cifrado: {nomeCifrado}");
    }

    static string CifrarNome(string nome)
    {
        char[] caracteres = nome.ToCharArray();

        for (int i = 0; i < caracteres.Length; i++)
        {
            char c = caracteres[i];

            if (c >= 'A' && c <= 'Z')
                caracteres[i] = (char)('A' + (c - 'A' + 2) % 26);
            else if (c >= 'a' && c <= 'z')
                caracteres[i] = (char)('a' + (c - 'a' + 2) % 26);
        }

        return new string(caracteres);
    }
}
