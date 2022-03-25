using System;
using System.Threading.Tasks;
using Exceptions;
using FuncionarioApi.Models.Funcionarios;

namespace FuncionarioApi.Models.ContraCheque
{
    public class ContraChequeService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public ContraChequeService(IFuncionarioRepository funcionarioRepository)
        {
            this._funcionarioRepository = funcionarioRepository;
        }

        public async Task<ContraCheque> CalcularDeFuncionario(long funcionarioId)
        {

            var funcionario = await this._funcionarioRepository.GetById(funcionarioId);

            if (funcionario == null) throw new FuncionarioNotFound(funcionarioId);

            ContraCheque relatorio = new ContraCheque(funcionario);

            relatorio.geraLancamentos();

            relatorio.SalarioLiquido = Math.Round(relatorio.Funcionario.SalarioBruto - relatorio.TotalDescontos, 2);

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");
            relatorio.MesReferencia = DateTime.Now.ToString("MMMM", culture);

            return relatorio;
        }

    }
}