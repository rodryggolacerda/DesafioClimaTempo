using DesafioClimaTempo.Domain.Model;
using System.Collections.Generic;

namespace DesafioClimaTempo.Web.Models
{
    public class PrevisaoClimaModel
    {
        public List<PrevisaoClima> GetCidadesMaisQuentes { get; set; }
        public List<PrevisaoClima> GetCidadesMaisFrias { get; set; }
        public List<Cidade> GetCidades { get; set; }
        public Cidade Cidade { get; set; }
    }
}