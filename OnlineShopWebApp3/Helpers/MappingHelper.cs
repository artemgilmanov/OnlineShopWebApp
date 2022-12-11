using OnlineShop.Db.Model;
using OnlineShopWebApp3.Areas.User.Model;
using System.Collections.Generic;

namespace OnlineShopWebApp3.Helpers
{
    public static class MappingHelper
    {
        public static List<Areas.User.Model.ProductViewModel> ToProductViewModels(List<OnlineShop.Db.Model.ProductViewModel> products)
        {
            var productsViewModels = new List<Areas.User.Model.ProductViewModel>();

            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            };
            return productsViewModels;
        }

        public static Areas.User.Model.ProductViewModel ToProductViewModel(OnlineShop.Db.Model.ProductViewModel product)
        {
            return  new Areas.User.Model.ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description
                };
        }

        public static List<CartItemViewModel> ToCartViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };

                cartItems.Add(cartItem);
            };

            return cartItems;
        }

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart==null)
            {
                return null;
            }

            return new CartViewModel()
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartViewModels(cart.Items)
                
            };
        }
    }
}
