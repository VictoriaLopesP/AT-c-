using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Digite sua data de nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
            DateTime hoje = DateTime.Today;
            DateTime proximoAniversario = new DateTime(hoje.Year, dataNascimento.Month, dataNascimento.Day);

            if (proximoAniversario < hoje)
                proximoAniversario = proximoAniversario.AddYears(1);

            int diasRestantes = (proximoAniversario - hoje).Days;

            Console.WriteLine($"Faltam {diasRestantes} dias para seu próximo aniversário :)");

            if (diasRestantes < 7)
                Console.WriteLine("Seu aniversário está chegando! Uhuuuuuuuuuuuu :D");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Formato de data inválido. Digite no formato dd/mm/yyyy.");
        }
    }
}
