using System.ComponentModel.DataAnnotations;

namespace Atividade04.Models
{
    public class Aluno
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]

        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")] 
        public string Nome { get; set; }

        [Required(ErrorMessage = "O RA é obrigatório.")]

        [RegularExpression(@"^RA[0-9]{6}$", ErrorMessage = "O RA deve começar com RA e ter 6 números.")] 
        public string Ra { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]

        [EmailAddress(ErrorMessage = "Digite um email válido.")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")] 
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
    }
}
