using System;

namespace Exceptions
{
    [Serializable]
    public class FuncionarioNotFound : Exception
    {
        public FuncionarioNotFound() { }

        public FuncionarioNotFound(long id)
            : base(String.Format("Funcionário with ID {0} Not Found.", id))
        {

        }
    }
}