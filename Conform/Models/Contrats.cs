using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Conform.Models //localização do arquivo
{
    public class Contrat //Classe publica
    {
        [BsonId] //Identificador único
        [BsonRepresentation(BsonType.ObjectId)] //Representação do tipo ObjectId
        public string Id { get; set; } = string.Empty; //Inicia uma string vazia
        [BsonElement("Title")]
        public string Title { get; set; } = string.Empty;
        [BsonElement("Content")]
        public string Content { get; set; } = string.Empty;
        [BsonElement("Status")]
        public string Status { get; set; } = "pending"; //Valor padrão é declarado como pendente
        [BsonElement("UploadDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UploadDate { get; set; } = DateTime.Now; //Data de upload é a data atual

        //Construtor padrão
        public Contrat() { }
    }
};