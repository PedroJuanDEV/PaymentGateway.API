namespace PaymentGateway.API.Models
{
    public class Customer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty; // CPF ou CNPJ

        // Relacionamento: Um cliente pode ter várias transações
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}