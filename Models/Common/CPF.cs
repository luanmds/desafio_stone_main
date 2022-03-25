using System;
using System.Text.RegularExpressions;

namespace FuncionarioApi.Models.Common
{
    /// <summary>
    /// Class CPF para validação e criação de uma entidade CPF
    /// Aceita-se no formato tradicional. Exemplo: 123.456.789-10
    /// </summary>
    public class CPF
    {
        public long Valor { get; set; }

        public CPF(string valor)
        {
            if (!this.validaCPF(valor))
            {
                throw new ArgumentException("Value to CPF is not Valid.");
            }

            this.Valor = long.Parse(valor);
        }

        private bool validaCPF(string cpf)
        {
            Match match = Regex.Match(cpf, @"[0-9]{11}");
            return match.Success;
        }
    }
}