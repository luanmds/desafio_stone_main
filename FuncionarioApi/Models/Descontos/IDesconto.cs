namespace FuncionarioApi.Models.Descontos
{
    public interface IDesconto
    {
        double Calcular(double salario);

        string Descricao();
    }
}