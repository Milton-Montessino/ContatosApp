using System.ComponentModel.DataAnnotations;

namespace ContatosApp.API.Models
{
    public class ContatosPostModel
    {
        [MinLength(6, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do contato.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do contato.")]
        public string? Email { get; set; }

        [RegularExpression(@"\(\d{2}\)\s\d{5}-\d{4}",
            ErrorMessage = "Por favor, informe um telefone no formato: '(99) 99999-9999'.")]
        [Required(ErrorMessage = "Por favor, informe o telefone do contato.")]
        public string? Telefone { get; set; }
    }
}



