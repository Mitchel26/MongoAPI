using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.Models
{
    public class Product
    {
        // Definimos el modelo
        [BsonId] // Decorador BsonId para mongoDB()
        public ObjectId Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Categoria { get; set; }
    }
}