using ErickEspinosa.WebApiAspNetCore.JWToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErickEspinosa.WebApiAspNetCore.JWToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private List<Product> _products;
        public ProductsController()
        {
            _products = new List<Product>
            {
                new Product {
                    Guid = Guid.NewGuid().ToString(),
                    Name = "Produto Teste 1",
                    Price = 100.10m
                },
                new Product {
                    Guid = Guid.NewGuid().ToString(),
                    Name = "Produto Teste 2",
                    Price = 100.20m
                }
            };
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() => Ok(_products);

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            product.Guid = Guid.NewGuid().ToString();
            _products.Add(product);
            return Ok();
        }

        [HttpDelete]
        [Route("{guid}")]
        public IActionResult Delete(string guid)
        {
            _products = _products.Where(x => !x.Guid.Equals(guid)).ToList();
            return Ok();
        }
    }
}
