using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Conform.Services;

var builder = WebApplication.CreateBuilder(args);

// Obtém a string de conexão do appsettings.json
var mongoDbConnectionString = builder.Configuration.GetConnectionString("MongoDb");

// Inicializa o MongoDB com a string de conexão fornecida
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    return new MongoClient(mongoDbConnectionString);
});

// Adiciona um contexto de banco de dados, se necessário
builder.Services.AddSingleton<MongoDbContext>();

// Adiciona controladores ao contêiner de serviços
builder.Services.AddControllers();

// Adiciona suporte ao Swagger para documentação
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita a interface do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura o pipeline de requisições HTTP
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
