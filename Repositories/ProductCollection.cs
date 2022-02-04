using System.Collections.Generic;
using System.Threading.Tasks;
using MongoAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoAPI.Repositories
{
    public class ProductCollection : IProductCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Product> collection;

        public ProductCollection()
        {
            collection = _repository.db.GetCollection<Product>("Products");
        }


        public async Task DeleteProduct(string id)
        {
            var productId = Builders<Product>.Filter.Eq(x => x.Id, new ObjectId(id));
            await collection.DeleteOneAsync(productId);

        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            return await collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertProduct(Product product)
        {
            await collection.InsertOneAsync(product);
        }

        public async Task UpdateProduct(Product product)
        {
            var productId = Builders<Product>.Filter.Eq(x => x.Id, product.Id);
            await collection.ReplaceOneAsync(productId, product);
        }
    }
}