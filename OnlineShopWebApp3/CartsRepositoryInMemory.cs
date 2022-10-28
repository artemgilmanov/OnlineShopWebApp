using OnlineShopWebApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3
{
    public class CartsRepositoryInMemory : ICartsRepository
    {
        private static List<Cart> carts { get; } = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            var cart = carts.FirstOrDefault(x => x.UserId == userId);
            return cart;
        }

        public void AddProduct(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart == null)
            {
                var newCart = new Cart()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<CartItem>()
                    {
                        new CartItem()
                        {
                            Id=Guid.NewGuid(),
                            Product = product,
                            Amount =1
                        }
                    }
                };

                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Product.Id == product.Id);

                if (existingCartItem != null)
                {
                    existingCartItem.Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem()
                    {
                        Id = Guid.NewGuid(),
                        Product = product,
                        Amount = 1
                    });
                }
            }

        }

        public void RemoveFromCart(Guid itemId)
        {
            var existingCart = TryGetByUserId(Constants.UserId);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Id == itemId);
            existingCartItem.Amount--;

            if (existingCartItem.Amount <= 0)
            {
                existingCart.Items.Remove(existingCartItem);
            }

            if (existingCart.Items.Count<=0)
            {
                carts.Remove(existingCart);
            }
        }

        public void Clear(string UserId)
        {
            var existingCart = TryGetByUserId(Constants.UserId);
            carts.Remove(existingCart);
        }

        public void AddOrder(Order order, string userId)
        {
            var existingCart = TryGetByUserId(Constants.UserId);
            existingCart.Orders.Add(order);
        }
    }
}
