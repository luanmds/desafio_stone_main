using FuncionarioApi.Models.Descontos;

namespace FuncionarioApi.Models.ContraCheque
{
    public class Lancamento
    {
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }

        public Lancamento() { }

        public Lancamento(string Tipo, double Valor, string Descricao)
        {
            this.Tipo = Tipo;
            this.Descricao = Descricao;
            this.Valor = Valor;
        }
    }
}