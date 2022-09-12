using DesafioClimaTempo.Domain.Context;
using DesafioClimaTempo.Domain.Model;
using DesafioClimaTempo.Repository.Servicos.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioClimaTempo.Repository.Servicos.Implementacao
{
    public class CidadeRepository : ICidadeRepository
    {
        private EFContext Context = null;

        /// <summary>
        /// Construtor Cidade Repository
        /// </summary>
        public CidadeRepository(EFContext context)
        {
            this.Context = context;// new EFContext();
        }
            

        /// <summary>
        /// GetCidades
        /// </summary>
        /// <returns>Retorno lista de Cidades</returns>
        public async Task<List<Cidade>> GetCidades()
        {
            return await Context.Set<Cidade>().OrderBy(x => x.Nome).ToListAsync();
        }

        /// <summary>
        /// SelectByID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorno Cidade</returns>
        public Cidade SelectByID(int id)
        {
            return Context.Cidades.Include(x => x.Estado).FirstOrDefault(x => x.Id == id);
        }
    }
}