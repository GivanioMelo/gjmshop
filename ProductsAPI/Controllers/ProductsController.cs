using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Domain;
using ProductsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ProductService productService;
        public ProductsController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("Filters")]
        public FilterLimits Get()
        {
            return productService.getFilterLimits();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductResume> Get([FromBody] ProductFilter filter)
        {
            return productService.ListProducts(filter);
            //return new string[] { "value1", "value2" };
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(string id)
        {
            return productService.GetProductDetails(id);
            //return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            productService.CreateProduct(value);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Product value)
        {
            productService.UpdateProduct(id, value);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            productService.DeleteProduct(id);
        }
    }
}
