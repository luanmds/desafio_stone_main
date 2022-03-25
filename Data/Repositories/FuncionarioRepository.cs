using System.Collections.Generic;
using System.Threading.Tasks;
using FuncionarioApi.Data.Entities;
using FuncionarioApi.Models.Common;
using FuncionarioApi.Models.Descontos;
using FuncionarioApi.Models.Funcionarios;
using Microsoft.EntityFrameworkCore;

namespace FuncionarioApi.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private readonly FuncionarioDbContext _context;

        public FuncionarioRepository(FuncionarioDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Funcionario>> GetAll()
        {
            List<FuncionarioEntity> funcionarioEntities = await this._context.Funcionarios.ToListAsync();

            List<Funcionario> funcionarios = new List<Funcionario>();

            foreach (FuncionarioEntity f in funcionarioEntities)
            {
                Funcionario funcionario = new Funcionario();
                funcionario.Id = f.Id;
                funcionario.Nome = f.Nome;
                funcionario.Sobrenome = f.Sobrenome;
                funcionario.Documento = new CPF(f.Documento);
                funcionario.Setor = SetorFactory.GetSetor(f.Setor);
                funcionario.SalarioBruto = f.SalarioBruto;
                funcionario.DataAdmissao = f.DataAdmissao;
                funcionario.HasPlanoSaude = f.HasPlanoSaude;
                funcionario.HasPlanoDental = f.HasPlanoDental;
                funcionario.HasValeTransporte = f.HasValeTransporte;

                funcionarios.Add(funcionario);
            }

            return funcionarios;
        }

        public async Task<Funcionario> GetById(long id)
        {
            FuncionarioEntity f = await this._context.Funcionarios.FindAsync(id);


            if (f == null) return null;

            Funcionario funcionario = new Funcionario();
            funcionario.Id = f.Id;
            funcionario.Nome = f.Nome;
            funcionario.Sobrenome = f.Sobrenome;
            funcionario.Documento = new CPF(f.Documento);
            funcionario.Setor = SetorFactory.GetSetor(f.Setor);
            funcionario.SalarioBruto = f.SalarioBruto;
            funcionario.DataAdmissao = f.DataAdmissao;
            funcionario.HasPlanoSaude = f.HasPlanoSaude;
            funcionario.HasPlanoDental = f.HasPlanoDental;
            funcionario.HasValeTransporte = f.HasValeTransporte;

            if (funcionario.HasPlanoSaude)
                funcionario.DescontosExtras.Add(new DescontoPlanoSaude());
            if (funcionario.HasPlanoDental)
                funcionario.DescontosExtras.Add(new DescontoPlanoDental());
            if (funcionario.HasValeTransporte)
                funcionario.DescontosExtras.Add(new DescontoValeTransporte());

            return funcionario;
        }

        public async Task Save(Funcionario entity)
        {
            using (this._context)
            {
                FuncionarioEntity f = new FuncionarioEntity();
                f.Nome = entity.Nome;
                f.Sobrenome = entity.Sobrenome;
                f.Documento = entity.Documento.Valor.ToString();
                f.Setor = entity.Setor.ToString();
                f.SalarioBruto = entity.SalarioBruto;
                f.DataAdmissao = entity.DataAdmissao;
                f.HasPlanoSaude = entity.HasPlanoSaude;
                f.HasPlanoDental = entity.HasPlanoDental;
                f.HasValeTransporte = entity.HasValeTransporte;

                await _context.Funcionarios.AddAsync(f);
                await _context.SaveChangesAsync();
            }
        }
    }
}