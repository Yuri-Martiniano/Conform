using Microsoft.AspNetCore.Mvc; // Importa os namespaces necessários para ASP.NET Core MVC
using Conform.Models; // Importa o namespace onde está definida a classe Contrat (ajuste conforme necessário)
using Conform.Services; // Importa o namespace para o serviço que manipula os contratos (ajuste conforme necessário)
using MongoDB.Driver; // Importa o MongoDB Driver para interações com o banco de dados MongoDB

namespace Conform.Controllers
{
    [Route("api/[controller]")] // Define a rota da API baseada no nome do controlador (neste caso, será 'api/contracts')
    [ApiController] // Indica que a classe é um controlador da API e habilita funcionalidades específicas como validação automática de modelos
    public class ContractsController : ControllerBase // Define a classe do controlador herdando de ControllerBase
    {
        private readonly IMongoCollection<Contrat> _contractsCollection; // Representa a coleção de contratos no MongoDB

        // Construtor que injeta a dependência IMongoClient para conexão com o banco de dados
        public ContractsController(IMongoClient client)
        {
            // Inicializa a conexão com o banco de dados 'conform_db'
            var database = client.GetDatabase("conform_db");
            // Inicializa a coleção 'contracts' no banco de dados 'conform_db'
            _contractsCollection = database.GetCollection<Contrat>("contracts");
        }

        // Método para buscar todos os contratos
        [HttpGet] // Define um método de ação para responder a solicitações HTTP GET
        public ActionResult<List<Contrat>> Get() // Retorna uma lista de contratos
        {
            var contracts = _contractsCollection.Find(contract => true).ToList(); // Busca todos os documentos na coleção
            return Ok(contracts); // Retorna a lista de contratos com status HTTP 200 (OK)
        }
        
        // Método para obter um contrato específico por ID
        [HttpGet("{id:length(24)}", Name = "GetContract")] // Define um método de ação para responder a solicitações HTTP GET com um parâmetro 'id'
        public ActionResult<Contrat> Get(string id)
        {
            var contract = _contractsCollection.Find(contract => contract.Id == id).FirstOrDefault(); // Busca pelo ID fornecido
            if (contract == null) 
                return NotFound(); // Retorna 404 se o contrato não for encontrado
            
            return Ok(contract); // Retorna o contrato com status HTTP 200
        }

        // Método para criar um novo contrato
        [HttpPost] // Define um método de ação para responder a solicitações HTTP POST
        public ActionResult<Contrat> Create(Contrat contract)
        {
            _contractsCollection.InsertOne(contract); // Insere o contrato na coleção
            return CreatedAtRoute("GetContract", new { id = contract.Id }, contract); // Retorna o contrato criado com status HTTP 201
        }

        // Método para atualizar um contrato existente
        [HttpPut("{id:length(24)}")] // Define um método de ação para responder a solicitações HTTP PUT
        public IActionResult Update(string id, Contrat contractIn)
        {
            var contract = _contractsCollection.Find(contract => contract.Id == id).FirstOrDefault(); // Busca pelo ID fornecido
            if (contract == null) 
                return NotFound(); // Retorna 404 se o contrato não for encontrado

            var updateResult = _contractsCollection.ReplaceOne(contract => contract.Id == id, contractIn); // Atualiza o contrato
            if (updateResult.MatchedCount == 0) 
                return NotFound(); // Retorna 404 se o contrato não for encontrado
            
            return NoContent(); // Retorna status HTTP 204 para indicar que a atualização foi bem-sucedida
        }

        // Método para excluir um contrato
        [HttpDelete("{id:length(24)}")] // Define um método de ação para responder a solicitações HTTP DELETE
        public IActionResult Delete(string id)
        {
            var deleteResult = _contractsCollection.DeleteOne(contract => contract.Id == id); // Exclui o contrato
            if (deleteResult.DeletedCount == 0) 
                return NotFound(); // Retorna 404 se o contrato não for encontrado
            
            return NoContent(); // Retorna status HTTP 204 para indicar que a exclusão foi bem-sucedida
        }
    }
}
