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
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioClimaTempo.Teste
{
    [TestClass]
    public class EstadoTeste
    {
        private IEstadoRepository _estadoRepository = null;

        [TestInitialize]
        public void Inicializar()
        {
            var estados = new List<Estado>
            {
                new Estado { Id = 1, Nome = "São Paulo"},
                new Estado{ Id = 2, Nome = "Mato Grosso do Sul"}
            };

            var dbsetEstados = new Mock<DbSet<Estado>>();
            dbsetEstados.As<IQueryable<Estado>>().Setup(x => x.Expression).Returns(estados.AsQueryable().Expression);

            var contextMock = new Mock<EFContext>();
            contextMock.Setup(dbContext => dbContext.Estados).Returns(dbsetEstados.Object); 

            var estadoRepository = new Mock<IEstadoRepository>();             

            estadoRepository.Setup(m => m.SelectByID(It.IsAny<int>())).Returns((int id) => estados.FirstOrDefault(o => o.Id == id));
            estadoRepository.Setup(m => m.Find( It.IsAny<Expression<Func<Estado, bool>>>())).ReturnsAsync(estados.ToList());
          
            this._estadoRepository = estadoRepository.Object;
        }

        [TestMethod]
        public void SelectByID_BuscarEstado_Sucesso()
        {
            #region Arrange
            Estado estado = _estadoRepository.SelectByID(1);
            #endregion

            #region act
            #endregion

            #region Assert
            Assert.IsNotNull(estado);
            Assert.AreEqual(estado.Id, 1);
            #endregion
        }

        [TestMethod]
        public void SelectByID_BuscarEstado_Falha()
        {
            Estado estado = _estadoRepository.SelectByID(0);

            #region act
            #endregion

            Assert.IsNull(estado);
        }


        [TestMethod]
        public async Task Find_BuscarEstado_Sucesso()
        {
            #region Arrange
            List<Estado> estado = await _estadoRepository.Find(null);
            #endregion

            #region act
            #endregion

            #region Assert
            Assert.AreEqual(estado.Count(), 2);
            Assert.AreEqual(estado[0].Id, 1);
            #endregion
        }
    }
}