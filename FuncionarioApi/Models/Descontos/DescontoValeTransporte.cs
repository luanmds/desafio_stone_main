using System;

namespace FuncionarioApi.Models.Descontos
{
    public class DescontoValeTransporte : IDescontoExtra
    {
        public double Calcular(double salario)
        {
            if (salario < 1500.00)
                return 0.0;

            return Math.Round(salario * (6.0 / 100), 2);
        }

        public string Descricao()
        {
            return "Vale Transporte (VT)";
        }
    }
}