using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.API.DTOs
{
    public class PaymentRequestDto
    {
        [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
        public Guid CustomerId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "A chave de idempotência é obrigatória para evitar duplicidade.")]
        public string IdempotencyKey { get; set; } = string.Empty;

        // Dados simulados do meio de pagamento
        [Required(ErrorMessage = "O número do cartão é obrigatório.")]
        [CreditCard(ErrorMessage = "Número de cartão inválido.")]
        public string CardNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "O nome impresso no cartão é obrigatório.")]
        public string CardHolderName { get; set; } = string.Empty;
    }
}