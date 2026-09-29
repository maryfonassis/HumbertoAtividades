using System.ComponentModel.DataAnnotations;

namespace Atividade1.Models
{
    public class Voto
    {
        [Required]
        public string RaAluno { get; set; } = string.Empty;

        public DateTime DataVoto { get; set; }

        [Required]
        public int NumeroCandidato { get; set; }
    }
}
