using System;
using System.Collections.Generic;
using FuncionarioApi.Models.ContraCheque;

namespace FuncionarioApi.Controllers.DTO
{
    public class ContraChequeDTO
    {
        public string NomeFuncionario { get; set; }
        public double SalarioBrutoFuncionario { get; set; }
        public string MesReferencia { get; set; }
        public List<Lancamento> Lancamentos { get; set; }
        public double TotalDescontos { get; set; }
        public double SalarioLiquido { get; set; }

        public static ContraChequeDTO ToDTO(ContraCheque cc)
        {
            ContraChequeDTO dto = new ContraChequeDTO();
            dto.NomeFuncionario = String.Format("{0} {1}",
                                    cc.Funcionario.Nome, cc.Funcionario.Sobrenome);
            dto.SalarioBrutoFuncionario = cc.Funcionario.SalarioBruto;
            dto.Lancamentos = cc.Lancamentos;
            dto.MesReferencia = cc.MesReferencia;
            dto.TotalDescontos = -cc.TotalDescontos;
            dto.SalarioLiquido = cc.SalarioLiquido;

            return dto;
        }
    }
}