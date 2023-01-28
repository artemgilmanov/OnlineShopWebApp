using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IFavouriteRepository
    {
        public void Add(string userId, Product product);
        public List<Product> GetAll(string userId);
        public void Remove(Guid productId, string userId);
    }
}