using System;
using System.Collections.Generic;
using FuncionarioApi.Models.Descontos;
using FuncionarioApi.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace FuncionarioApi.Models.Funcionarios
{
    public class Funcionario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public CPF Documento { get; set; }
        public Setor Setor { get; set; }
        public double SalarioBruto { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAdmissao { get; set; }
        public bool HasPlanoSaude { get; set; }
        public bool HasPlanoDental { get; set; }
        public bool HasValeTransporte { get; set; }
        public List<IDescontoExtra> DescontosExtras { get; set; }

        public Funcionario()
        {
            DescontosExtras = new List<IDescontoExtra>();
        }

    }
}