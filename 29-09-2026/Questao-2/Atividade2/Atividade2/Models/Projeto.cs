using System.ComponentModel.DataAnnotations;

namespace Atividade2.Models
{
    public class Projeto
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Range(1, 8)]
        public int Turma { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [Range(10, 99)]
        public int Numero { get; set; }
    }
}
