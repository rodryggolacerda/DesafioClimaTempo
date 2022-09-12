using DesafioClimaTempo.Domain.Enum;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioClimaTempo.Domain.Model
{
    /// <summary>
    /// PrevisaoClima
    /// </summary>
    public class PrevisaoClima: BaseEntity
    {
        /// <summary>
        /// Clima
        /// </summary>
        [JsonProperty("Clima")]
        [StringLength(15, ErrorMessage = "O {0} não pode exceder {1} caracteres.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O {0} não permitido null ou string empty.")]
        [Column(TypeName = "nvarchar(15)")]
        public ClimaEnum Clima { get; set; }

        /// <summary>
        /// Temperatura Minima
        /// </summary>
        [JsonProperty("TemperaturaMinima")]
        [Required(ErrorMessage = "O {0} não permitido null")]
        public Decimal TemperaturaMinima { get; set; }

        /// <summary>
        /// Temperatura Maxima
        /// </summary>
        [JsonProperty("TemperaturaMaxima")]
        [Required(ErrorMessage = "O {0} não permitido null")]
        public Decimal TemperaturaMaxima { get; set; }

        /// <summary>
        /// DataPreviao
        /// </summary>
        [JsonProperty("DataPrevisao")]
        [Required(ErrorMessage = "O {0} não permitido null")]
        public DateTime DataPrevisao { get; set; }

        /// <summary>
        /// CidadeId
        /// </summary>
        [Required(ErrorMessage = "O {0} não permitido null")]
        public int CidadeId { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public Cidade Cidade { get; set; }
    }
}