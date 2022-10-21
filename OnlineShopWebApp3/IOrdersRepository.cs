using OnlineShopWebApp3.Models;

namespace OnlineShopWebApp3
{
    public interface IOrdersRepository
    {
        void Add(Order order);
    }
}