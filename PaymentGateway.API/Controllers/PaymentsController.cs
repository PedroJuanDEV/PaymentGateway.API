using Microsoft.AspNetCore.Mvc;
using PaymentGateway.API.Data;
using PaymentGateway.API.DTOs;
using PaymentGateway.API.Models;
using Microsoft.EntityFrameworkCore;

namespace PaymentGateway.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // O caminho será: api/payments
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentDbContext _context;

        // Injeção de dependência do nosso contexto do banco de dados
        public PaymentsController(PaymentDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequestDto request)
        {
            // 1. Validar se o cliente existe no banco de dados
            var customerExists = await _context.Customers.AnyAsync(c => c.Id == request.CustomerId);
            if (!customerExists)
            {
                return NotFound(new { message = "Cliente não encontrado no sistema." });
            }

            // 2. Simulação da Regra de Idempotência (Verificar se a chave já foi usada)
            var existingTransaction = await _context.Transactions
                .FirstOrDefaultAsync(t => t.IdempotencyKey == request.IdempotencyKey);

            if (existingTransaction != null)
            {
                // Se a transação já existe, retornamos o resultado dela imediatamente sem reprocessar
                return Ok(new PaymentResponseDto
                {
                    TransactionId = existingTransaction.Id,
                    Amount = existingTransaction.Amount,
                    Status = existingTransaction.Status,
                    ProcessedAt = existingTransaction.CreatedAt,
                    Message = "Requisição duplicada detectada. Retornando resultado original."
                });
            }

            // 3. Simular a análise de aprovação (Regra de negócio simples para teste)
            // Se o valor for maior que 5000, vamos simular que o banco recusou por falta de limite
            string statusFinal = "Approved";
            string mensagemFinal = "Pagamento processado com sucesso.";

            if (request.Amount > 5000)
            {
                statusFinal = "Failed";
                mensagemFinal = "Pagamento recusado: Saldo/Limite insuficiente.";
            }

            // 4. Mapear o DTO para a Entidade do Banco de Dados e Salvar
            var transaction = new Transaction
            {
                Amount = request.Amount,
                Status = statusFinal,
                IdempotencyKey = request.IdempotencyKey,
                CustomerId = request.CustomerId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            // 5. Mapear a Entidade de volta para o DTO de Resposta
            var response = new PaymentResponseDto
            {
                TransactionId = transaction.Id,
                Amount = transaction.Amount,
                Status = transaction.Status,
                ProcessedAt = transaction.CreatedAt,
                Message = mensagemFinal
            };

            return Ok(response);
        }
    }
}