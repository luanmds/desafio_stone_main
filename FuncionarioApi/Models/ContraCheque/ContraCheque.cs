using System;
using System.Collections.Generic;
using FuncionarioApi.Models.Descontos;
using FuncionarioApi.Models.Funcionarios;

namespace FuncionarioApi.Models.ContraCheque
{
    public class ContraCheque
    {
        public Funcionario Funcionario { get; set; }
        public string MesReferencia { get; set; }
        public double TotalDescontos { get; set; }
        public double SalarioLiquido { get; set; }
        public List<Lancamento> Lancamentos { get; set; }
        public List<IDescontoObrigatorio> DescontosObrigatorios { get; set; }
        public List<IDescontoExtra> DescontosExtras { get; set; }

        public ContraCheque(Funcionario funcionario)
        {
            this.Funcionario = funcionario;
            this.DescontosObrigatorios = new List<IDescontoObrigatorio>();
            this.Lancamentos = new List<Lancamento>();

            this.DescontosObrigatorios.Add(new DescontoINSS());
            this.DescontosObrigatorios.Add(new DescontoImpostoRenda());
            this.DescontosObrigatorios.Add(new DescontoFGTS());

            this.DescontosExtras = funcionario.DescontosExtras;
        }

        public void geraLancamentos()
        {
            this.Lancamentos.Add(new Lancamento(
                TipoLancamento.REMUNERACAO.ToString(),
                this.Funcionario.SalarioBruto,
                "Salário Bruto"
            ));

            foreach (IDescontoObrigatorio d in this.DescontosObrigatorios)
            {
                Lancamento lancDescontoObrigatorio = new Lancamento(
                    TipoLancamento.DESCONTO.ToString(),
                    d.Calcular(this.Funcionario.SalarioBruto),
                    d.Descricao()
                );

                this.TotalDescontos += lancDescontoObrigatorio.Valor;

                this.Lancamentos.Add(lancDescontoObrigatorio);
            }

            foreach (IDescontoExtra d in this.DescontosExtras)
            {
                Lancamento lancDescontoExtra = new Lancamento(
                    TipoLancamento.DESCONTO.ToString(),
                    d.Calcular(this.Funcionario.SalarioBruto),
                    d.Descricao()
                );

                this.TotalDescontos += lancDescontoExtra.Valor;

                this.Lancamentos.Add(lancDescontoExtra);
            }

            this.TotalDescontos = Math.Round(this.TotalDescontos, 2);
        }
    }
}