using System;

namespace FuncionarioApi.Data.Entities
{
    public class FuncionarioEntity
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Setor { get; set; }
        public double SalarioBruto { get; set; }
        public DateTime DataAdmissao { get; set; }
        public bool HasPlanoSaude { get; set; }
        public bool HasPlanoDental { get; set; }
        public bool HasValeTransporte { get; set; }
    }
}