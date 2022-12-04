﻿using OnlineShopWebApp3.Areas.User.Model;
using OnlineShopWebApp3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp3.Model
{
    public class CartsRepositoryInMemory : ICartsRepository
    {
        private static List<Cart> Carts { get; } = new List<Cart>();

        public Cart TryGetByUserId(string userId)
        {
            var cart = Carts.FirstOrDefault(x => x.UserId == userId);
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

                Carts.Add(newCart);
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

        public void RemoveItem(Guid itemId)
        {
            var existingCart = TryGetByUserId(Constants.UserId);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Id == itemId);
            existingCartItem.Amount--;

            if (existingCartItem.Amount <= 0)
            {
                existingCart.Items.Remove(existingCartItem);
            }

            if (existingCart.Items.Count <= 0)
            {
                Carts.Remove(existingCart);
            }
        }

        public void Clear(string UserId)
        {
            var existingCart = TryGetByUserId(Constants.UserId);
            Carts.Remove(existingCart);
        }

        public void AddOrder(Order order, string userId)
        {
            var existingCart = TryGetByUserId(Constants.UserId);
            existingCart.Orders.Add(order);
        }
    }
}