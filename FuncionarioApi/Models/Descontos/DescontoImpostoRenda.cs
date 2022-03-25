using System;

namespace FuncionarioApi.Models.Descontos
{
    public class DescontoImpostoRenda : IDescontoObrigatorio
    {
        public double Calcular(double salario)
        {
            (double aliquota, double valorMaximo) = buscaValorAliquotaEValorMaximoDesconto(salario);

            double desconto = Math.Round(salario * (aliquota / 100), 2);

            if (desconto > valorMaximo)
                desconto = valorMaximo;

            return desconto;
        }

        public string Descricao()
        {
            return "Imposto de Renda (IR)";
        }

        private (double, double) buscaValorAliquotaEValorMaximoDesconto(double salario)
        {
            if (salario <= 1903.98) return (0.0, 0.0);

            else if (salario <= 2826.65) return (7.5, 142.80);

            else if (salario <= 3751.05) return (15.0, 354.80);

            else if (salario <= 4664.68) return (22.5, 636.13);

            else return (27.5, 869.36);
        }
    }
}