using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Digite a data atual: ");
            DateTime dataAtual = DateTime.Parse(Console.ReadLine());

            DateTime dataFormatura = new DateTime(2027, 12, 15);

            if (dataAtual > DateTime.Now)
            {
                Console.WriteLine("Erro: A data informada não pode ser no futuro!");
                return;
            }

            if (dataAtual > dataFormatura)
            {
                Console.WriteLine("Parabéns! Você já deveria estar formado!");
                return;
            }

            int anos = dataFormatura.Year - dataAtual.Year;
            int meses = dataFormatura.Month - dataAtual.Month;
            int dias = dataFormatura.Day - dataAtual.Day;

            if (meses < 0)
            {
                anos--;
                meses += 12;
            }

            if (dias < 0)
            {
                meses--;
                dias += DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);
            }

            Console.WriteLine($"Faltam {anos} anos, {meses} meses e {dias} dias para sua formatura!");

            if (anos == 0 && meses < 6)
            {
                Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Formato de data inválido. Digite no formato dd/MM/yyyy.");
        }
    }
}
