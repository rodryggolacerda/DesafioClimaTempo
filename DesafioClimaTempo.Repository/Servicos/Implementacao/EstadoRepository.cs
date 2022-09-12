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
    public class EstadoRepository : IEstadoRepository
    {
        private EFContext Context = null;

        /// <summary>
        /// Construtor Estado Repository
        /// </summary>
        public EstadoRepository(EFContext context)
        {
            this.Context = context;// new EFContext();
        }

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Retorno lista de Estados</returns>
        public async Task<List<Estado>> Find(Expression<Func<Estado, bool>> expression)
        {
            return await Context.Set<Estado>().Where(expression).ToListAsync();
        }

        /// <summary>
        /// SelectByID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Retorno Estado</returns>
        public Estado SelectByID(int id)
        {
            return Context.Estados.FirstOrDefault(x => x.Id == id);
        }
    }
}