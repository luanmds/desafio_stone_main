namespace FuncionarioApi.Models.Common
{
    public enum Setor
    {
        FINANCEIRO,
        TECNOLOGIA_DA_INFORMACAO,
        RECURSOS_HUMANOS,
        ADMINISTRATIVO
    }

    public static class SetorFactory
    {
        public static Setor GetSetor(string SetorName)
        {
            if (SetorName == "FINANCEIRO") return Setor.FINANCEIRO;

            if (SetorName == "TECNOLOGIA_DA_INFORMACAO") return Setor.TECNOLOGIA_DA_INFORMACAO;

            if (SetorName == "RECURSOS_HUMANOS") return Setor.RECURSOS_HUMANOS;

            else return Setor.ADMINISTRATIVO;
        }
    }
}