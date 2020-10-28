using System;

namespace ProjetoAula
{
	public class Transacao
	{

		public decimal Montante { get; set; }
		public DateTime Data { get; set; }
		public string Nota { get; set; }

		public Transacao(decimal valor, DateTime data, string nota)
		{
			this.Montante = valor;
			this.Data = data;
			this.Nota = nota;

		}
	}
}