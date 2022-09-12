using DesafioClimaTempo.Repository.Servicos.Implementacao;
using DesafioClimaTempo.Repository.Servicos.Interface;
using DesafioClimaTempo.Web.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DesafioClimaTempo.Web.Controllers
{
    public class PrevisaoTempoController : Controller
    {
        private ICidadeRepository _cidadeRepository = null;

        private IPrevisaoClimaRepository _previsaoClimaRepository = null;

        public PrevisaoTempoController()
        {
            // Eu sei que o correto é por injeção de dependencia, venho trabalhando atualmente com projeto .net core usando injeção de depencia, fiz a implementação neste mas tive contratempo
            // e por esse motivo esta desta forma

            this._cidadeRepository = new CidadeRepository(new Domain.Context.EFContext());
            this._previsaoClimaRepository = new PrevisaoClimaRepository(new Domain.Context.EFContext());
        }

        public async Task<ActionResult> Index()
        {
            PrevisaoClimaModel previsaoClima = new PrevisaoClimaModel();

            previsaoClima.GetCidadesMaisQuentes = await _previsaoClimaRepository.GetTempoMaximo(3);
            previsaoClima.GetCidadesMaisFrias = await _previsaoClimaRepository.GetTempoMinimo(3);
            previsaoClima.GetCidades = await _cidadeRepository.GetCidades();
           
            return View(previsaoClima);
        }
    }
}