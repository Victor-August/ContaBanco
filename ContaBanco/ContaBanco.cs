using System;
using System.Collections.Generic;

namespace ProjetoAula {
	public class ContaBanco
	{
		private static int numeroConta = 1;

		public string Numero { get; set; }
		
		public string Cliente { get; set; }
		
		public decimal Saldo { 
			get {
				decimal saldo = 0;
				foreach (var item in todasTransacoes)
                {
					saldo += item.Montante;
                }
				return saldo;
			}
			set { } 
		}

		private List<Transacao> todasTransacoes = new List<Transacao>();

        //Metodo construtor
        public ContaBanco(string nome, decimal valorInicial)
        {
			this.Cliente = nome;
			this.Saldo = valorInicial;
			this.Numero = numeroConta.ToString();
			numeroConta++;

			fazerDeposito(valorInicial, DateTime.Now, "Valor Inicial");
        }

		public void fazerDeposito(decimal valor, DateTime date, string nota)
        {
			if(valor <= 0)
            {
				throw new ArgumentOutOfRangeException(nameof(valor),
					"Valor do depósito deve ser positivo");
            }
			var deposito = new Transacao(valor, date, nota);
			todasTransacoes.Add(deposito);
        }

		public void fazerRetirada(decimal valor, DateTime date, string nota)
		{
			if(valor <= 0)
            {
				throw new ArgumentOutOfRangeException(nameof(valor),
					"Valor de retidade deve ser positivo");
            }
			if (this.Saldo - valor < 0)
			{
				throw new InvalidOperationException("Fundos insuficientes para esta retirada");
			}
			var retirada = new Transacao(-valor, date, nota);
			todasTransacoes.Add(retirada);
		}

		public string getHistoricoConta()
        {
			var report = new System.Text.StringBuilder();
			decimal saldo = 0;

			report.AppendLine("Data\t\tValor\tSaldo\tNota");

            foreach (var item in todasTransacoes)
            {
				saldo += item.Montante;
				report.AppendLine($"{item.Data.ToShortDateString()}\t" +
					$"{item.Montante}\t" +
					$"{saldo}\t" +
					$"{item.Nota}");
            }
			return report.ToString();
        }

	}
}

