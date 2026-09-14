using System.ComponentModel.DataAnnotations;

namespace Atividade_05.Models
{
    public class Produto
    {
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MinLength(3, ErrorMessage = "A descrição deve ter no mínimo 3 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public double Preco { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo.")]
        public int Estoque { get; set; }

        [Required(ErrorMessage = "O código do produto é obrigatório.")]
        [RegularExpression(@"^[A-Z]{3}-[0-9]{4}$", ErrorMessage = "O código deve seguir o formato AAA-1234.")]
        public string CodigoProduto { get; set; }
    }
}
