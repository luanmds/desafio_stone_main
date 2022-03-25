using System;
using FuncionarioApi.Models.Funcionarios;
using FuncionarioApi.Models.Common;

namespace FuncionarioApi.Controllers.DTO
{
    public class FuncionarioDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string Setor { get; set; }
        public double SalarioBruto { get; set; }
        public DateTime DataAdmissao { get; set; }
        public bool PossuiPlanoDeSaude { get; set; }
        public bool PossuiPlanoDental { get; set; }
        public bool PossuiValeTransporte { get; set; }

        public static FuncionarioDTO FuncionarioToDTO(Funcionario f)
        {
            FuncionarioDTO dto = new FuncionarioDTO();
            dto.Id = f.Id;
            dto.Nome = f.Nome;
            dto.Sobrenome = f.Sobrenome;
            dto.CPF = f.Documento.Valor.ToString();
            dto.Setor = f.Setor.ToString();
            dto.SalarioBruto = f.SalarioBruto;
            dto.DataAdmissao = f.DataAdmissao;
            dto.PossuiPlanoDeSaude = f.HasPlanoSaude;
            dto.PossuiPlanoDental = f.HasPlanoDental;
            dto.PossuiValeTransporte = f.HasValeTransporte;
            
            return dto;
        }
    }
}