using DesafioClimaTempo.Domain.Context;
using DesafioClimaTempo.Domain.Model;
using DesafioClimaTempo.Repository.Servicos.Implementacao;
using DesafioClimaTempo.Repository.Servicos.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioClimaTempo.Teste
{
    [TestClass]
    public class PrevisaoClimaRepositoryTeste
    {
        private IPrevisaoClimaRepository _previsaoClimaRepository = null;

        [TestInitialize]
        public void Inicializar()
        {
            var Cidade = new List<Cidade>
            {
                new Cidade{ Id = 1, Nome = "Campo Grande", EstadoId = 2},
                new Cidade{ Id = 2, Nome = "Dourados", EstadoId = 2},
                new Cidade{ Id = 3, Nome = "Bauru", EstadoId = 1},
                new Cidade{ Id = 4, Nome = "Camapuã", EstadoId = 2},
                new Cidade{ Id = 5, Nome = "Ponta Pora", EstadoId = 2},
                new Cidade{ Id = 6, Nome = "Douradina", EstadoId = 2},
                new Cidade{ Id = 7, Nome = "Iguatemi", EstadoId = 2},
                new Cidade{ Id = 8, Nome = "Coxim", EstadoId = 2},
                new Cidade{ Id = 9, Nome = "Bandeirantes", EstadoId = 2},
                new Cidade{ Id = 10, Nome = "Tres lagoas", EstadoId = 2},
                new Cidade{ Id = 11, Nome = "Rio Negro", EstadoId = 2}
            };

            DateTime date = DateTime.Now.Date; 

            var previsaoClima = new List<PrevisaoClima>
            {
               new PrevisaoClima{ Id = 1, CidadeId = 1, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("35,5"), TemperaturaMinima = decimal.Parse("25,6"), Clima = Domain.Enum.ClimaEnum.Sol},
               new PrevisaoClima{ Id = 2, CidadeId = 2, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("34,5"), TemperaturaMinima = decimal.Parse("24,6"), Clima = Domain.Enum.ClimaEnum.Sol},
               new PrevisaoClima{ Id = 3, CidadeId = 3, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("33,5"), TemperaturaMinima = decimal.Parse("23,6"), Clima = Domain.Enum.ClimaEnum.ensolarado},
               new PrevisaoClima{ Id = 4, CidadeId = 4, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("32,5"), TemperaturaMinima = decimal.Parse("22,6"), Clima = Domain.Enum.ClimaEnum.nublado},
               new PrevisaoClima{ Id = 5, CidadeId = 5, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("31,5"), TemperaturaMinima = decimal.Parse("21,6"), Clima = Domain.Enum.ClimaEnum.Chuva},
               new PrevisaoClima{ Id = 6, CidadeId = 6, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("30,5"), TemperaturaMinima = decimal.Parse("19,6"), Clima = Domain.Enum.ClimaEnum.chuvoso},
               new PrevisaoClima{ Id = 7, CidadeId = 7, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("29,5"), TemperaturaMinima = decimal.Parse("18,6"), Clima = Domain.Enum.ClimaEnum.Tempestuoso},
               new PrevisaoClima{ Id = 8, CidadeId = 8, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("28,5"), TemperaturaMinima = decimal.Parse("17,6"), Clima = Domain.Enum.ClimaEnum.Frio},
               new PrevisaoClima{ Id = 9, CidadeId = 9, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("27,5"), TemperaturaMinima = decimal.Parse("16,6"), Clima = Domain.Enum.ClimaEnum.ensolarado},
               new PrevisaoClima{ Id = 10, CidadeId = 10, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("26,5"), TemperaturaMinima = decimal.Parse("15,6"), Clima = Domain.Enum.ClimaEnum.Frio},
               new PrevisaoClima{ Id = 11, CidadeId = 11, DataPrevisao = date, TemperaturaMaxima = decimal.Parse("25,5"), TemperaturaMinima = decimal.Parse("14,6"), Clima = Domain.Enum.ClimaEnum.Chuva}
            };

            var dbsetPrevisaoClima = new Mock<DbSet<PrevisaoClima>>();
            dbsetPrevisaoClima.As<IQueryable<PrevisaoClima>>().Setup(x => x.Expression).Returns(previsaoClima.AsQueryable().Expression);

            var dbsetCidade = new Mock<DbSet<Cidade>>();
            dbsetCidade.As<IQueryable<Cidade>>().Setup(x => x.Expression).Returns(Cidade.AsQueryable().Expression);

            var contextMock = new Mock<EFContext>();

            contextMock.Setup(dbContext => dbContext.PrevisaoClima).Returns(dbsetPrevisaoClima.Object);
            contextMock.Setup(dbContext => dbContext.Cidades).Returns(dbsetCidade.Object);

            var previsaoTempoRepository = new Mock<IPrevisaoClimaRepository>();

            previsaoTempoRepository.Setup(m => m.GetPrevisaoSeteDias(It.IsAny<int>())).ReturnsAsync((int id) => previsaoClima.Where(x => x.CidadeId == id).ToList());
            previsaoTempoRepository.Setup(m => m.GetTempoMaximo(It.IsAny<int>())).ReturnsAsync((int qtde) => previsaoClima.Take(qtde).ToList());
            previsaoTempoRepository.Setup(m => m.GetTempoMinimo(It.IsAny<int>())).ReturnsAsync((int qtde) => previsaoClima.Take(qtde).ToList());



            this._previsaoClimaRepository = previsaoTempoRepository.Object;
        }

        [TestMethod]
        public async Task GetPrevisaoSeteDias_BuscarEstado_Sucesso()
        {
            #region Arrange
            List<PrevisaoClima> previsaoClima = await _previsaoClimaRepository.GetPrevisaoSeteDias(1);
            #endregion

            #region act
            #endregion

            #region Assert
            Assert.IsNotNull(previsaoClima);
            Assert.IsTrue(previsaoClima.Count() > 0);
            #endregion
        }

        [TestMethod]
        public async Task GetTempoMaximo_BuscarEstado_Sucesso()
        {
            #region Arrange
            List<PrevisaoClima> previsaoClima = await _previsaoClimaRepository.GetTempoMaximo(1);
            #endregion

            #region act
            #endregion

            #region Assert
            Assert.IsNotNull(previsaoClima);
            Assert.IsTrue(previsaoClima.Count() > 0);
            #endregion
        }

    }
}