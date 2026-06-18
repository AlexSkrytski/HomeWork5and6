using HomeWork5and6.Contracts.Responses;
using HomeWork5and6.services;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork5and6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]

        public IActionResult Create([FromBody] CreateProductRequest request)
        {
            // 1. Вызов бизнес-логики из слоя Application
            var product = _productService.CreateProduct(request.Name, request.Price);

            // 2. Маппинг доменной сущности в ProductResponse (Contracts)
            var response = new ProductResponse(product.Id, product.Name, product.Price);

            // 3. Возврат HTTP-ответа
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response); //In C#, CreatedAtAction is a helper method provided by ControllerBase in ASP.NET Core
        }                                                                           //that returns an HTTP 201 Created status code. It is the standard RESTful response for a
    }                                                                          //successful POST request because it simultaneously sends back the newly created object,
                                                                               //returns the 201 code, and generates a Location header pointing to the URL where the resource can be fetched.
    // Вспомогательный Request для примера
    public record CreateProductRequest(string Name, decimal Price);
}

//{
//  "name": "Наушники",       json example
//  "price": 4999.99
//}