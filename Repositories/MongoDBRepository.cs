using MongoDB.Driver;

namespace MongoAPI.Repositories
{
    public class MongoDBRepository
    {
        // Conexión a la base de datos mongo
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb://127.0.0.1:27017");
            db = client.GetDatabase("Iventory");
        }



    }
}