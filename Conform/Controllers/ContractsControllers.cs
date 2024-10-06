using Microsoft.AspNetCore.Mvc;
using Conform.Models;
using Conform.Services;
using MongoDB.Driver;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Conform.Controllers
{
    [Route("api/[controller]")] //A rota da API e o diretorio Controller e um placeholder
    [ApiController] //indica que a classe é um controlador da API
    public class ContractsControllers : ControllerBase // defina uma classe que herda de ControllerBase
    {
        private readonly IMongoCollection<Contrat> coontractsCollection;

        // Construtor que injeta a dependência IMongoClient para conexão com o banco de dados
        public ContractsControllers(IMongoClient client)
        {
            var database = client.GetDatabase("conform_db");
            coontractsCollection = database.GetCollection<Contrat>("contracts");
        }

        [HttpGet] //Define um método de ação para responder a solicitações HTTP GET
        public ActionResult<List<Contrat>> Get() //Retorna uma lista de contratos
        {
            var contracts = coontractsCollection.Find(Contract => true).ToList(); //Busca todos os documentos na coleção
            return Ok(contracts); //Retorna a lista de contratos com status HTTP 200
        }
        
        // Método para obter um contrato específico por ID
        [HttpGet ("{id:length(24)}", Name = "Getcontact")] //Define um método de ação para responder a solicitações HTTP GET
        public ActionResult<Contrat> Get(string id)
        {
            var contract = coontractsCollection.Find(Contract => Contract.Id == id).FirstOrDefault(); // Busca pelo ID fornecido
            if (contract == null) return NotFound(); //Retorna 404 se o contrato não for encontrado
            return Ok(contract); //Retorna o contrato com status HTTP 200
        }
        // Método para criar um novo contrato
        [HttpPost] //Define um método de ação para responder a solicitações HTTP POST
        public ActionResult<Contrat> Create(Contrat contract)
        {
            coontractsCollection.InsertOne(contract); //Insere o contrato na coleção
            return CreatedAtRoute("Getcontact", new { id = contract.Id }, contract); //Retorna o contrato criado com status HTTP 201
        }

        // Método para atualizar um contrato existente
        [HttpPut("{id:length(24)}")] //Define um método de ação para responder a solicitações HTTP PUT
        public IActionResult Update(string id, Contrat contractIn)
        {
            var contract = coontractsCollection.Find(Contract => Contract.Id == id).FirstOrDefault(); // Busca pelo ID fornecido
            if (contract == null) return NotFound(); //Retorna 404 se o contrato não for encontrado
            var updateResult = coontractsCollection.ReplaceOne(Contract => Contract.Id == id, contractIn); //Atualiza o contrato
            if (updateResult.MatchedCount == 0) return NotFound(); //Retorna 404 se o contrato não for encontrado
            return NoContent(); //Retorna status HTTP 204
        }
        // Método para excluir um contrato
        [HttpDelete("{id:length(24)}")] //Define um método de ação para responder a solicitações HTTP DELETE
        public IActionResult Delete(string id)
        {
            var deleteResult = coontractsCollection.DeleteOne(Contract => Contract.Id == id); //Exclui o contrato
            if (deleteResult.DeletedCount == 0) return NotFound(); //Retorna 404 se o contrato não for encontrado
            return NoContent(); //Retorna status HTTP 204
        }
    }
    
}