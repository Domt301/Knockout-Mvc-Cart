using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShoppingCart.Services
{
    public class CartService : IDisposable
    {
        private ShoppingCartContext _db = new ShoppingCartContext();

        public Cart GetBySessionId(string sessionId)
        {
            var cart = _db.Carts.Include("CartItems").SingleOrDefault(c => c.SessionId == sessionId);
            cart = CreateCartIfItDoesntExist(sessionId, cart);
            return cart;

        }

        private Cart CreateCartIfItDoesntExist(string sessionId, Cart cart)
        {
            if (null == cart)
            {
                cart = new Cart
                {
                    SessionId = sessionId,
                    CartItems = new List<CartItem>()
                };

                _db.Carts.Add(cart);
                _db.SaveChanges();
            }
            return cart;
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}