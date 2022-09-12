using DesafioClimaTempo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioClimaTempo.Repository.Servicos.Interface
{
    public interface ICidadeRepository
    {
        /// <summary>
        /// SelectByID
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>retorno Cidade</returns>
        Cidade SelectByID(int id);
         

        /// <summary>
        /// GetCidades
        /// </summary>
        /// <returns>Retorno Cidade</returns>
        Task<List<Cidade>> GetCidades();
    }
}