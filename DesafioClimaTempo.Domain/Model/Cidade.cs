using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DesafioClimaTempo.Domain.Model
{
    /// <summary>
    /// Cidade
    /// </summary>
    public class Cidade : BaseEntity
    {
        /// <summary>
        /// Nome
        /// </summary>
        [JsonProperty("Nome")]
        [StringLength(200, ErrorMessage = "O {0} não pode exceder {1} caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} não permitido null ou string empty.")]
        public string Nome { get; set; }

        /// <summary>
        /// EstadoId
        /// </summary>
        [JsonProperty("EstadoId")]
        [Required(ErrorMessage = "O {0} não permitido null")]
        public int EstadoId { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public Estado Estado { get; set; }
    }
}