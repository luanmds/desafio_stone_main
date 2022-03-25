using System;
using System.ComponentModel.DataAnnotations;
using FuncionarioApi.Models.Common;

namespace FuncionarioApi.Controllers.DTO
{
    public class FuncionarioCreateDTO
    {
        [Required]
        [StringLength(20)]
        public string Nome { get; set; }

        [Required]
        [StringLength(60)]
        public string Sobrenome { get; set; }

        [RegularExpression(@"[0-9]{11}",
         ErrorMessage = "CPF can only contain numbers.")]
        public string CPF { get; set; }

        [Required]
        public Setor Setor { get; set; }

        [Range(1.0, 9999.99)]
        public double SalarioBruto { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataAdmissao { get; set; }

        [Required]
        public bool PossuiPlanoDeSaude { get; set; }

        [Required]
        public bool PossuiPlanoDental { get; set; }

        [Required]
        public bool PossuiValeTransporte { get; set; }
    }
}