using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DesafioClimaTempo.Domain.Model
{
    /// <summary>
    /// Estado
    /// </summary>
    public class Estado : BaseEntity
    {
        /// <summary>
        /// Nome
        /// </summary>
        [JsonProperty("Nome")]
        [StringLength(200, ErrorMessage = "O {0} não pode exceder {1} caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} não permitido null ou string empty.")]
        public string Nome { get; set; }


        /// <summary>
        /// Uf
        /// </summary>
        [JsonProperty("UF")]
        [StringLength(2, ErrorMessage = "O {0} não pode exceder {1} caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} não permitido null ou string empty.")]
        public string Uf { get; set; }
    }
}