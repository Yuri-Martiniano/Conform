// Selecione o banco de dados a ser usado.
use('conformDb');

// Crie a coleção "contracts" e insira documentos
db.getCollection('contracts').insertMany([
  {
    'name': 'Contrato de Serviço',
    'description': 'Contrato para prestação de serviços de desenvolvimento',
    'value': 5000,
    'status': 'active',
  },
  {
    'name': 'Contrato de Manutenção',
    'description': 'Contrato para manutenção de sistema',
    'value': 2000,
    'status': 'pending',
  },
]);

// Verificar os documentos inseridos na coleção "contracts"
const contracts = db.getCollection('contracts').find().toArray();

// Listar todos os contratos
db.getCollection('contracts').find({}).pretty();

// Listar todos os usuários
db.getCollection('users').find({}).pretty();


// Imprimir o número de contratos na coleção
console.log(`Total de contratos inseridos: ${contracts.length}`);

// Criar a coleção "users" e adicionar documentos
db.getCollection('users').insertOne({
  name: 'Yuri',
  email: 'yuri@example.com',
  role: 'admin',
});

// Verificar os documentos inseridos na coleção "users"
const users = db.getCollection('users').find().toArray();
console.log(`Usuários adicionados: ${users.length}`);
