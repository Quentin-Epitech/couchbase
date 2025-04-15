using Couchbase;
using Couchbase.KeyValue;
using CouchbaseProductApi.Models;

namespace CouchbaseProductApi.Services;

public class ProductService
{
    private readonly ICouchbaseCollection _collection;

    public ProductService()
    {
        var cluster = Cluster.ConnectAsync("couchbase://localhost", "Administrator", "Quentin88").Result;
        var bucket = cluster.BucketAsync("products").Result;
        _collection = bucket.DefaultCollection();
    }

    public async Task AddProduct(Product product)
    {
        product.Id = Guid.NewGuid().ToString(); // Génère un ID unique
        await _collection.InsertAsync(product.Id, product);
    }

    public async Task<Product?> GetProduct(string id)
    {
        try
        {
            var result = await _collection.GetAsync(id);
            return result.ContentAs<Product>();
        }
        catch
        {
            return null; // En cas d'erreur (ex: doc non trouvé), on retourne null
        }
    }

    public async Task UpdateProduct(Product product)
    {
        await _collection.UpsertAsync(product.Id, product);
    }

    public async Task DeleteProduct(string id)
    {
        await _collection.RemoveAsync(id);
    }
}
