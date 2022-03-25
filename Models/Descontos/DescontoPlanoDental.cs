namespace FuncionarioApi.Models.Descontos
{
    public class DescontoPlanoDental : IDescontoExtra
    {
        double valorDesconto = 5.0;
        public double Calcular(double salario)
        {
            return valorDesconto;
        }

        public string Descricao()
        {
            return "Plano Dental";
        }
    }
}