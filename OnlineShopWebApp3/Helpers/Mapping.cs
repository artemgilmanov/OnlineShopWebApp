using OnlineShop.Db.Model;
using OnlineShopWebApp3.Areas.Admin.Model;
using OnlineShopWebApp3.Areas.Brand.Model;
using System.Collections.Generic;

namespace OnlineShopWebApp3.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();

            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            };
            return productsViewModels;
        }
        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Cost = product.Cost,
                    Description = product.Description,
                    ImagePath=product.ImagePath
                };
        }

        public static List<CartItemViewModel> ToCartViewModels(this List<CartItem> cartItems)
        {
            var cartItemsViewModel = new List<CartItemViewModel>();

            foreach (var cartItem in cartItems)
            {
                cartItemsViewModel
                    .Add(new CartItemViewModel
                        {
                            Id = cartItem.Id,
                            Amount = cartItem.Amount,
                            Product = ToProductViewModel(cartItem.Product)
                        });
            };

            return cartItemsViewModel;
        }
        public static CartViewModel ToCartViewModel(this Cart cart)
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

        public static UserDeliveryInfo ToUserDeliveryInfo(this UserDeliveryInfoViewModel userDeliveryInfoViewModel)
        {
            return new UserDeliveryInfo
            {
                FirstName = userDeliveryInfoViewModel.FirstName,
                LastName = userDeliveryInfoViewModel.LastName,
                PhoneNumber = userDeliveryInfoViewModel.PhoneNumber,
                CountryCode = userDeliveryInfoViewModel.CountryCode,
                Address = userDeliveryInfoViewModel.Address,
                AddressOptional = userDeliveryInfoViewModel.AddressOptional,
                City = userDeliveryInfoViewModel.City,
                State = userDeliveryInfoViewModel.State,
                Postcode = userDeliveryInfoViewModel.Postcode,
                RememberAddress = userDeliveryInfoViewModel.RememberAddress
            };
        }
        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel (this UserDeliveryInfo userDeliveryInfo)
        {
            return new UserDeliveryInfoViewModel
            {
                FirstName = userDeliveryInfo.FirstName,
                LastName = userDeliveryInfo.LastName,
                PhoneNumber = userDeliveryInfo.PhoneNumber,
                CountryCode = userDeliveryInfo.CountryCode,
                Address = userDeliveryInfo.Address,
                AddressOptional = userDeliveryInfo.AddressOptional,
                City = userDeliveryInfo.City,
                State = userDeliveryInfo.State,
                Postcode = userDeliveryInfo.Postcode,
                RememberAddress = userDeliveryInfo.RememberAddress
            };
        }

        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> items)
        {
            var itemsViewModel = new List<CartItemViewModel>();

            foreach (var item in items)
            {
                itemsViewModel.Add(ToCartItemViewModel(item));
            }

            return itemsViewModel;
        }
        public static CartItemViewModel ToCartItemViewModel(this CartItem item)
        {
            return new CartItemViewModel
            {
                Id = item.Id,
                Product = ToProductViewModel(item.Product),
                Amount = item.Amount
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                UserDeliveryInfo = ToUserDeliveryInfoViewModel(order.UserDeliveryInfo),
                Items = ToCartItemViewModels(order.Items),
                Status = (OrderStatusViewModel)(int)order.Status,
                CreatedDateTime = order.CreatedDateTime,
            };
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Name = user.UserName,
                Phone = user.PhoneNumber,
                Email = user.Email
            };
        }

    }
}
