using OnlineShopWebApp3.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3
{
    public static class CartsRepository
    {
        private static List<Cart> Carts { get; } = new List<Cart>();

        public static Cart TryGetByUserId(string userId)
        {
            var cart = Carts.FirstOrDefault(x => x.UserId == userId);
            return cart;
        }

        public static void Add(Guid productId, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart==null)
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
                            Product = ProductsRepository.TryGetById(productId),
                            Amount =1
                        }
                    }
                };

                Carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == productId);

                if (existingCartItem!=null)
                {
                    existingCart.TryGetByProductId(productId).Amount += 1;
                }
                else
                {
                    existingCart.Items.Add(new CartItem()
                    {
                        Id = Guid.NewGuid(),
                        Product = ProductsRepository.TryGetById(productId),
                        Amount = 1
                    });
                }
            }

        }
    }
}
