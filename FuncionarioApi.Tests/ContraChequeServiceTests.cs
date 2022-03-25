using System;
using FuncionarioApi.Models.Common;
using FuncionarioApi.Models.ContraCheque;
using FuncionarioApi.Models.Funcionarios;
using Moq;
using Xunit;

namespace FuncionarioApi.Tests
{
    public class ContraChequeServiceTests
    {

        private readonly ContraChequeService _service;
        private readonly Mock<IFuncionarioRepository> _funcionarioRepoMock = new Mock<IFuncionarioRepository>();
        public ContraChequeServiceTests()
        {
            this._service = new ContraChequeService(this._funcionarioRepoMock.Object);
        }

        [Fact]
        public async void CalcularDeFuncionario_ShouldCalcContraCheque_WhenFuncionarioExistsTest()
        {
            long funcionarioId = 99999;

            var funcionarioMock = new Funcionario
            {
                Id = funcionarioId,
                Nome = "Luan",
                Sobrenome = "Mello da Silva",
                Documento = new CPF("12345678910"),
                Setor = Setor.FINANCEIRO,
                SalarioBruto = 2500.00,
                DataAdmissao = DateTime.Now,
                HasPlanoSaude = true,
                HasPlanoDental = true,
                HasValeTransporte = false
            };

            this._funcionarioRepoMock.Setup(x => x.GetById(funcionarioId))
                .ReturnsAsync(funcionarioMock);

            var contraCheque = await this._service.CalcularDeFuncionario(funcionarioId);

            Assert.NotNull(contraCheque);
        }

    }
}
