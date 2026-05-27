using Microsoft.EntityFrameworkCore;
using PaymentGateway.API.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuração do Banco de Dados
builder.Services.AddDbContext<PaymentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Adicionando os Controladores e o Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 3. Configurando o Pipeline (O que a API usa quando está rodando)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Diz para a API usar as rotas que criamos no PaymentsController

// 4. O COMANDO MÁGICO: Mantém a API rodando e escutando requisições!
app.Run();