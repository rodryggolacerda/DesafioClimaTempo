using DesafioClimaTempo.Domain.Context;
using DesafioClimaTempo.Domain.Model;
using DesafioClimaTempo.Repository.Servicos.Implementacao;
using DesafioClimaTempo.Repository.Servicos.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioClimaTempo.Teste
{

    [TestClass]
    public class CidadeTeste
    {
        private ICidadeRepository _cidadeRepository = null;

        [TestInitialize]
        public void Inicializar()
        {
            var cidade = new List<Cidade>
            {
                new Cidade{ Id = 1, Nome = "Campo Grande", EstadoId = 2},
                new Cidade{ Id = 2, Nome = "Dourados", EstadoId = 2},
                new Cidade{ Id = 3, Nome = "Bauru", EstadoId = 1},
                new Cidade{ Id = 4, Nome = "Camapuã", EstadoId = 2},
                new Cidade{ Id = 5, Nome = "São Gabriel do Oeste", EstadoId = 2}
            };
           
            var cidadeRepository = new Mock<ICidadeRepository>(); 

            cidadeRepository.Setup(m => m.SelectByID(It.IsAny<int>())).Returns((int id) => cidade.FirstOrDefault(o => o.Id == id)); 
            cidadeRepository.Setup(m => m.GetCidades()).ReturnsAsync(cidade.ToList());

            this._cidadeRepository = cidadeRepository.Object;
        }

        [TestMethod]
        public void SelectByID_BuscarEstado_Sucesso()
        {
            #region Arrange
            Cidade cidade = _cidadeRepository.SelectByID(1);
            #endregion

            #region act
            #endregion

            #region Assert
            Assert.IsNotNull(cidade);
            Assert.AreEqual(cidade.Id, 1);
            #endregion
        }

        [TestMethod]
        public void SelectByID_BuscarEstado_Falha()
        {
            Cidade cidade = _cidadeRepository.SelectByID(0);

            #region act
            #endregion

            Assert.IsNull(cidade);
        }

        [TestMethod]
        public async Task GetCidades_BuscarEstado_Sucesso()
        {
            #region Arrange
            List<Cidade> cidade = await _cidadeRepository.GetCidades();
            #endregion

            #region act
            #endregion

            #region Assert
            Assert.IsNotNull(cidade);
            Assert.IsTrue(cidade.Count() > 0);
            #endregion
        }
    }
}