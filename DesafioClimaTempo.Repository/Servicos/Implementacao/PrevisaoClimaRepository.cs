using DesafioClimaTempo.Domain.Context;
using DesafioClimaTempo.Domain.Model;
using DesafioClimaTempo.Repository.Servicos.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioClimaTempo.Repository.Servicos.Implementacao
{
    public class PrevisaoClimaRepository : IPrevisaoClimaRepository
    {
        private EFContext Context = null;

        /// <summary>
        /// Construtor Previsao Clima Repository
        /// </summary>
        public PrevisaoClimaRepository(EFContext context)
        {
            this.Context = context;// new EFContext();
        }

        /// <summary>
        /// GetPrevisaoSeteDias
        /// </summary>
        /// <param name="cidadeid">int</param>
        /// <returns>Retorno Lista Previsao Clima</returns>
        public async Task<List<PrevisaoClima>> GetPrevisaoSeteDias(int cidadeid)
        {
            List<PrevisaoClima> previsaoClimas = new List<PrevisaoClima>();
            DateTime data = DateTime.Now.Date;

            for (int i = 0; i < 7; i++)
            {
                PrevisaoClima clima = new PrevisaoClima();

                DateTime dataFim = data.AddHours(23).AddMinutes(59);

                clima = await Context.Set<PrevisaoClima>().Include(x => x.Cidade)
                                .Where(x => x.CidadeId == cidadeid && x.DataPrevisao >= data && x.DataPrevisao <= dataFim)
                                .OrderBy(x => x.TemperaturaMinima).FirstOrDefaultAsync();

                if (clima != null)
                {
                    clima.TemperaturaMaxima = Context.Set<PrevisaoClima>().Include(x => x.Cidade)
                                    .Where(x => x.CidadeId == cidadeid && x.DataPrevisao >= data && x.DataPrevisao <= dataFim)
                                    .OrderByDescending(x => x.TemperaturaMaxima).FirstOrDefault().TemperaturaMaxima;
                }

                previsaoClimas.Add(clima);
                data = data.AddDays(1).Date;
            }

            return previsaoClimas;
        }

        /// <summary>
        /// GetTempoMaximo
        /// </summary>
        /// <param name="qtdeRegistro">int</param>
        /// <returns>Retorno Lista Previsao Clima</returns>
        public async Task<List<PrevisaoClima>> GetTempoMaximo(int qtdeRegistro = 3)
        {
            DateTime data = DateTime.Now.Date;
            DateTime dataFim = data.AddHours(23).AddMinutes(59);

            List<PrevisaoClima> previsaoClima = await Context.Set<PrevisaoClima>().Include(x => x.Cidade)
                .Where(x => x.DataPrevisao >= data && x.DataPrevisao <= dataFim)
                .OrderByDescending(p => p.TemperaturaMaxima).ToListAsync();

            return previsaoClima.GroupBy(x => x.CidadeId).Select(y => y.FirstOrDefault()).Take(qtdeRegistro).ToList();            

        }

        /// <summary>
        /// GetTempoMinimo
        /// </summary>
        /// <param name="qtdeRegistro">int</param>
        /// <returns>Retorno Lista Previsao Clima</returns>
        public async Task<List<PrevisaoClima>> GetTempoMinimo(int qtdeRegistro = 0)
        {
            DateTime data = DateTime.Now.Date;
            DateTime dataFim = data.AddHours(23).AddMinutes(59);

            List<PrevisaoClima> previsaoClima = await Context.Set<PrevisaoClima>().Include(x => x.Cidade)
                                                        .Where(x => x.DataPrevisao >= data && x.DataPrevisao <= dataFim)
                                                        .OrderBy(p => p.TemperaturaMinima).ToListAsync();

            return previsaoClima.GroupBy(x => x.CidadeId).Select(y => y.FirstOrDefault()).Take(qtdeRegistro).ToList();
        }
    }
}