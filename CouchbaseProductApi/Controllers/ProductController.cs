using Microsoft.AspNetCore.Mvc;
using CouchbaseProductApi.Models;
using CouchbaseProductApi.Services;

namespace CouchbaseProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController()
    {
        _service = new ProductService(); // tu pourras injecter ça plus tard
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await _service.AddProduct(product);
        return Ok(product);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(string id)
    {
        var product = await _service.GetProduct(id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(string id, Product updated)
    {
        updated.Id = id;
        await _service.UpdateProduct(updated);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _service.DeleteProduct(id);
        return Ok();
    }
    [HttpGet("test")]
public IActionResult Test()
{
    return Ok("API fonctionne 🎉");
}
}



