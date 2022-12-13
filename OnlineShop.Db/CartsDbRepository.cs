using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public CartsDbRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return _dataBaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
        }

        public void AddProduct(Product product, string userId)
        {
            var existingCart = TryGetByUserId(userId);

            if (existingCart == null)
            {
                var newCart = new Cart()
                {
                    UserId = userId
                };

                newCart.Items = new List<CartItem>()
                {
                    new CartItem()
                    {
                        Id=Guid.NewGuid(),
                        Product = product,
                        Amount =1,
                        Cart=newCart
                    }
                };

                _dataBaseContext.Carts.Add(newCart);
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
                        Product = product,
                        Amount = 1,
                        Cart = existingCart
                    });
                }
            }

            _dataBaseContext.SaveChanges();
        }

        public void RemoveItem(Guid itemId, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Id == itemId);
            existingCartItem.Amount--;

            if (existingCartItem.Amount <= 0)
            {
                existingCart.Items.Remove(existingCartItem);
            }

            if (existingCart.Items.Count <= 0)
            {
                _dataBaseContext.Carts.Remove(existingCart);
            }

            _dataBaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetByUserId(userId);
            _dataBaseContext.Carts.Remove(existingCart);
            _dataBaseContext.SaveChanges();

        }

        public void AddOrder(Order order, string userId)
        {
            var existingCart = TryGetByUserId(userId);
            existingCart.Orders.Add(order);
            _dataBaseContext.SaveChanges();

        }
    }
}
