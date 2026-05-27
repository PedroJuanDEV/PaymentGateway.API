namespace PaymentGateway.API.Models
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Amount { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Approved, Failed
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Chave de Idempotência: Para evitar cobrança dupla se o app mandar a requisição duas vezes
        public string IdempotencyKey { get; set; } = string.Empty;

        // Relacionamento com o Cliente
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}