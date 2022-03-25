using System;

namespace FuncionarioApi.Models.Descontos
{
    public class DescontoINSS : IDescontoObrigatorio
    {
        public double Calcular(double salario)
        {
            double aliquota = buscaValorAliquota(salario);

            double desconto = Math.Round(salario * (aliquota / 100), 2);

            return desconto;
        }

        public string Descricao()
        {
            return "INSS";
        }

        private double buscaValorAliquota(double salario)
        {
            if (salario <= 1045.00) return 7.5;

            else if (salario <= 2089.60) return 9.0;

            else if (salario <= 3134.40) return 12.0;

            else if (salario <= 6101.06) return 14.0;

            else return -1.0;
        }
    }
}