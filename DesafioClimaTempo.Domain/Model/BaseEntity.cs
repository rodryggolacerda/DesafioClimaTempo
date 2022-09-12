using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DesafioClimaTempo.Domain.Model
{
    /// <summary>
    /// Base Entity
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [JsonProperty("Id")]
        [Required(ErrorMessage = "O {0} não permitido null")]
        public int Id { get; set; }
    }
}