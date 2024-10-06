// configuração da injeção de dependencias
// configurando o banco de dados usadondo o banco de dados do appsettings.json para o CRUD
using Conform.Services;
using Microsoft.AspNetCore.Builder;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// add o mongoDB ao projeto utilizando a string de coneção do appsettings.json
builder.Services.AddSingleton<IMongoClient, MongoClient>(IServerSession =>
//IserverSession é um objeto que representa um acesso ao banco de dados sendo um localizador de serviços
{
    var connectionString = builder.Configuration.GetConnectionString("MongoDB");
    return new MongoClient(connectionString);
});

// Add o MongoDB para ser usado nos controladores utilizando o MongoDBContext que pode cria e atualizar documentos do banco de dados
builder.Services.AddSingleton<MongoDbContext>();

// Add controladores como uma funcionalidade disponivel da aplicação ele registra os controladores para serem usados
builder.Services.AddControllers();

var app = builder.Build();

//Configura o roteamento para o controlador
app.UseRouting();

//Mapeia os controladores diretamente
app.MapControllers();

app.Run();