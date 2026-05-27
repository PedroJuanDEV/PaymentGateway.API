using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.DTOs
{
    public class CustomerRequestDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O documento é obrigatório.")]
        public string Document { get; set; } = string.Empty;
    }
}