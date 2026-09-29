using System.ComponentModel.DataAnnotations;

namespace Atividade2.Models
{
    public class Visita
    {
        [Required]
        public string RaAluno { get; set; } = string.Empty;

        public DateTime DataVisita { get; set; }

        [Required]
        [Range(10, 99)]
        public int NumeroProjeto { get; set; }

        [Required]
        [Range(0, 5)]
        public double Nota { get; set; }
    }
}
