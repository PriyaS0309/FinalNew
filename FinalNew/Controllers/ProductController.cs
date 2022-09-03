using FinalNew.Models;
using FinalNew.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepo _productRepo;
        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult>GetProducts()
        {
            return Ok(await _productRepo.GetProducts());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetProductId(int id)
        {
            return Ok(await _productRepo.GetProductByID(id));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetProductName(string name)
        {
            return Ok(await _productRepo.GetProductByName(name));
        }

        [HttpPost]

        public async Task<ActionResult<Product>>CreateProduct(Product product)
        {
            var CreatedProduct = await _productRepo.CreateProduct(product);

            return CreatedAtAction(nameof(GetProductId), new { id = CreatedProduct.ProductID}, CreatedProduct);
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult<Product>>EditProduct(int id,Product product)
        {
            var editedpro = await _productRepo.GetProductByID(id);

            return Ok(await _productRepo.EditProduct(product));
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult>DeleteProduct(int id)
        {
            return Ok(await _productRepo.DeleteProduct(id));
        }
    }
}
