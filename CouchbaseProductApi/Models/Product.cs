namespace CouchbaseProductApi.Models;

public class Product
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public double Price { get; set; }
}
