using CheckoutAPI.Domain;
using CheckoutAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService cartService;
        public CartController(CartService cartService)
        {
            this.cartService = cartService;
        }

        // GET api/<CartController>/5
        [HttpGet("{userId}")]
        public IEnumerable<CartItem> Get(int userId)
        {
            return cartService.getCartItems(userId);
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] CartItem item)
        {
            cartService.addToCart(item);
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] int newQuantity)
        {
            cartService.updateQuantity(id, newQuantity);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cartService.removeFromCart(id);
        }
    }
}
