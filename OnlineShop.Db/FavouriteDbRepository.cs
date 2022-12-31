using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{

    public class FavouriteDbRepository: IFavouriteRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public FavouriteDbRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public void Add(string userId, Product product)
        {
            var existingProduct = _dataBaseContext.FavouriteProducts
                .FirstOrDefault(x => x.UserId == userId && x.Product.Id == product.Id);
            if (existingProduct == null)
            {
                _dataBaseContext.FavouriteProducts.Add(new FavouriteProduct { Product = product, UserId = userId });
                _dataBaseContext.SaveChanges();
            }
        }

        public List<Product> GetAll(string userId)
        {
            return _dataBaseContext.FavouriteProducts.Where(x => x.UserId == userId)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();
        }
        public void Remove(Guid productId, string userId)
        {
            var favouriteProductToRemove = _dataBaseContext.FavouriteProducts.FirstOrDefault(u => u.UserId == userId && u.Product.Id == productId);
            _dataBaseContext.FavouriteProducts.Remove(favouriteProductToRemove);
            _dataBaseContext.SaveChanges();
        }
    }
}
