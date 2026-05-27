namespace PaymentGateway.API.DTOs
{
    public class PaymentResponseDto
    {
        public Guid TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty; // Approved, Rejected, Failed
        public DateTime ProcessedAt { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}