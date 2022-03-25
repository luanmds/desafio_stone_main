using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuncionarioApi.Models.Funcionarios
{
    public interface IFuncionarioRepository
    {
        Task<Funcionario> GetById(long id);
        Task<IEnumerable<Funcionario>> GetAll();
        Task Save(Funcionario entity);
    }
}