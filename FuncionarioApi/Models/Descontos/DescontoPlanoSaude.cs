namespace FuncionarioApi.Models.Descontos
{
    public class DescontoPlanoSaude : IDescontoExtra
    {
        double valorDesconto = 10.0;

        public double Calcular(double salario)
        {
            return valorDesconto;
        }

        public string Descricao()
        {
            return "Plano de Saúde";
        }
    }
}