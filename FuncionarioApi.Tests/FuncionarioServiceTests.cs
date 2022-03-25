using System;
using FuncionarioApi.Controllers.DTO;
using FuncionarioApi.Models.Common;
using FuncionarioApi.Models.Funcionarios;
using Moq;
using Xunit;

namespace FuncionarioApi.Tests
{
    public class FuncionarioServiceTests
    {

        private readonly FuncionarioService _service;
        private readonly Mock<IFuncionarioRepository> _funcionarioRepoMock = new Mock<IFuncionarioRepository>();
        public FuncionarioServiceTests()
        {
            this._service = new FuncionarioService(this._funcionarioRepoMock.Object);
        }

        [Fact]
        public async void GetById_ShouldGetFuncionarioWhenExistsTest()
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

            var funcionario = await this._service.ObterFuncionario(funcionarioId);

            Assert.Equal(funcionario.Id, funcionarioId);
        }

        [Fact]
        public async void GetById_ShouldReturnNullFuncionarioWhenNotExistsTest()
        {
            long funcionarioId = 99999;

            this._funcionarioRepoMock.Setup(x => x.GetById(It.IsAny<long>()))
                .ReturnsAsync(() => null);

            var funcionario = await this._service.ObterFuncionario(funcionarioId);

            Assert.Null(funcionario);
        }

        [Fact]
        public async void CreateFuncionario_ShouldCreateFuncionario_WhenFuncionarioDTOIsValidTest()
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

            var funcionarioDTO = new FuncionarioCreateDTO
            {
                Nome = "Luan",
                Sobrenome = "Mello da Silva",
                CPF = new CPF("12345678910").Valor.ToString(),
                Setor = Setor.FINANCEIRO,
                SalarioBruto = 2500.00,
                DataAdmissao = DateTime.Now,
                PossuiPlanoDeSaude = true,
                PossuiPlanoDental = true,
                PossuiValeTransporte = false
            };

            this._funcionarioRepoMock.Setup(x => x.Save(funcionarioMock));

            await this._service.CriarFuncionario(funcionarioDTO);
        }
    }
}
