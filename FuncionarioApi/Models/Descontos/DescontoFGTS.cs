using System;

namespace FuncionarioApi.Models.Descontos
{
    public class DescontoFGTS : IDescontoObrigatorio
    {
        double valorDesconto = 8;
        public double Calcular(double salario)
        {
            double desconto = Math.Round(salario * (valorDesconto / 100), 2);

            return desconto;
        }

        public string Descricao()
        {
            return "FGTS";
        }
    }
}