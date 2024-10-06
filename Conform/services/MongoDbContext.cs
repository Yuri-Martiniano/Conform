using Conform.Models;
using MongoDB.Driver;

namespace Conform.Services //localização do arquivo
{
    public class MongoDbContext //Classe publica
    {
        private readonly IMongoDatabase database;

        //Construtor que inicializa o MongoDB Context com string de conexão
        public MongoDbContext(IMongoClient client)
        {
            //Obtém o nome do banco de dados da configuração
            database = client.GetDatabase("conformDb"); //Banco de dados
        }

        //Propriedade de acesso a coleção de contratos
        public IMongoCollection<Contrat> Contrats => 
        database.GetCollection<Contrat>("Contratos");

        // -> Add outras coleções aqui <-
    }
}