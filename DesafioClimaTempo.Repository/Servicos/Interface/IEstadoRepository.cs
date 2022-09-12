using DesafioClimaTempo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesafioClimaTempo.Repository.Servicos.Interface
{
    public interface IEstadoRepository
    {
        /// <summary>
        /// SelectByID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorno Estado</returns>
        Estado SelectByID(int id);

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Retorno lista de Estados</returns>
        Task<List<Estado>> Find(Expression<Func<Estado, bool>> expression);
    }
}