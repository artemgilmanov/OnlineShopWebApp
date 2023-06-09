using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShop.Db;
using OnlineShopWebApp3.Areas.Brand.Controllers;
using Xunit;

namespace OnlineShopDbTests
{
    public class HomeControllerTests
    {
        private readonly Mock<IProductsRepository> _mockRepo;
        private readonly HomeController _homeController;

        public HomeControllerTests()
        {
            _mockRepo = new Mock<IProductsRepository>();
            _homeController = new HomeController(_mockRepo.Object);
        }

        [Fact]
        public void Index_ActionExecutes_ViewForIndex()
        {
            var result = _homeController.View() as ViewResult;      
            Assert.IsType<ViewResult>(result);
        }
    }
}
