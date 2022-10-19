using OnlineShopWebApp3.Models;

namespace OnlineShopWebApp3
{
    public interface IOrdersRepository
    {
        void Add(Cart cart);
    }
}