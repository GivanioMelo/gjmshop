using CheckoutAPI.Domain;
using CheckoutAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutAPI.Services
{
    public class CartService
    {
        private readonly CartItemDbContext cartRepository;

        public CartService(CartItemDbContext cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        internal IEnumerable<CartItem> getCartItems(int userId)
        {
            return cartRepository.CartItems.Where(q=> q.ClientId == userId);
        }

        internal void addToCart(CartItem item)
        {
            cartRepository.Add(item);
        }

        internal void updateQuantity(int id, int newQuantity)
        {
            var item = cartRepository.CartItems.Where(q => q.Id == id).FirstOrDefault();
            if(item!= null) 
            {
                item.Quantity = newQuantity;
                cartRepository.CartItems.Update(item);
            }
        }

        internal void removeFromCart(int id)
        {
            var item = cartRepository.CartItems.Where(q => q.Id == id).FirstOrDefault();
            if (item != null)
            {
                cartRepository.CartItems.Remove(item);
            }
        }
    }
}