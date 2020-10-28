using System;
using System.Runtime.InteropServices;

namespace ProjetoAula
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ContaBanco conta = new ContaBanco("Marcelo", 1000);
            Console.WriteLine($"Conta {conta.Numero} foi criada para {conta.Cliente} " +
                $"com saldo inicial de {conta.Saldo}.");

            //Retirada
            conta.fazerRetirada(500, DateTime.Now, "Pagamento de aluguel");
            Console.WriteLine($"Saldo: R$ {conta.Saldo}.");

            //Deposito
            conta.fazerDeposito(100, DateTime.Now, "Amigo me pagou de volta");
            Console.WriteLine($"Saldo: R$ {conta.Saldo}.");

            //Relatório das Transações
            Console.WriteLine(conta.getHistoricoConta());
            Console.WriteLine("Fim Relatório");



            Console.WriteLine("Criando conta saldo Negativo: ");
            try
            {
                var contaInvalida = new ContaBanco("Sr. Inválido", -100);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Execeção capturada criando uma conta saldo negativo");
                //Console.WriteLine(e.ToString());
            }

            try 
            {
                conta.fazerRetirada(750, DateTime.Now, "Tentativa de retirada");
            } 
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exceção causada por tentativa de retirada");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
