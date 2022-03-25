using System.Collections.Generic;
using System.Threading.Tasks;
using FuncionarioApi.Controllers.DTO;
using FuncionarioApi.Models.Common;
using FuncionarioApi.Models.Descontos;

namespace FuncionarioApi.Models.Funcionarios
{
    public class FuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            this._funcionarioRepository = funcionarioRepository;
        }
        public async Task CriarFuncionario(FuncionarioCreateDTO f)
        {

            Funcionario funcionario = new Funcionario();
            funcionario.Nome = f.Nome;
            funcionario.Sobrenome = f.Sobrenome;
            funcionario.SalarioBruto = f.SalarioBruto;
            funcionario.Documento = new CPF(f.CPF);
            funcionario.Setor = f.Setor;
            funcionario.DataAdmissao = f.DataAdmissao;
            funcionario.HasPlanoSaude = f.PossuiPlanoDeSaude;
            funcionario.HasPlanoDental = f.PossuiPlanoDental;
            funcionario.HasValeTransporte = f.PossuiValeTransporte;

            if (f.PossuiPlanoDeSaude)
                funcionario.DescontosExtras.Add(new DescontoPlanoSaude());

            if (f.PossuiPlanoDental)
                funcionario.DescontosExtras.Add(new DescontoPlanoDental());

            if (f.PossuiValeTransporte)
                funcionario.DescontosExtras.Add(new DescontoValeTransporte());

            await this._funcionarioRepository.Save(funcionario);
        }

        public async Task<Funcionario> ObterFuncionario(long id)
        {
            var funcionario = await this._funcionarioRepository.GetById(id);

            if (funcionario == null)
                return null;

            return funcionario;
        }

        public async Task<IEnumerable<Funcionario>> ObterTodosFuncionarios()
        {
            return await this._funcionarioRepository.GetAll();
        }
    }
}