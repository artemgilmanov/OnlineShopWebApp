using System;
using Xunit;

namespace OnlineShopDbTests
{
    public class HomeControllerTests
    {
        private readonly Mock<IProductsRepository> _mockRepo;
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _mockRepo = new Mock<IProductsRepository>();
            _controller = new HomeController(_mockRepo.Object);
        }

        [Fact]
        public void Index_ActionExeutesViewForIndex()
        {
            var result = _controller.Index() as ViewResult;
            Assert.IsType<ViewResult>(result);

        }
    }
}
