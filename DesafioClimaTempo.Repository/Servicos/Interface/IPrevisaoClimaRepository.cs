using DesafioClimaTempo.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioClimaTempo.Repository.Servicos.Interface
{
    public interface IPrevisaoClimaRepository
    {
        /// <summary>
        /// GetPrevisaoSeteDias
        /// </summary>
        /// <param name="cidadeid">int</param>
        /// <returns>Retorno Lista Previsao Clima</returns>
        Task<List<PrevisaoClima>> GetPrevisaoSeteDias(int cidadeid);

        /// <summary>
        /// GetTempoMaximo
        /// </summary>
        /// <param name="qtdeRegistro">int</param>
        /// <returns>Retorno Lista Previsao Clima</returns>
        Task<List<PrevisaoClima>> GetTempoMaximo(int qtdeRegistro = 0);

        /// <summary>
        /// GetTempoMinimo
        /// </summary>
        /// <param name="qtdeRegistro">int</param>
        /// <returns>Retorno Lista Previsao Clima</returns>
        Task<List<PrevisaoClima>> GetTempoMinimo(int qtdeRegistro = 0);
    }
}