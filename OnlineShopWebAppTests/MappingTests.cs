using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OnlineShop.Db.Model;
using System.Diagnostics;
using OnlineShopWebApp3.Helpers;

namespace OnlineShopWebAppTests
{
    [TestClass]
    public class MappingTests
    {
        Guid id;
        Product productDb;
        string imagePath;
        string size;
        string category;
        decimal cost;
        string material;
        string name;

        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("TestInitialize");
            id = new Guid();

            productDb = new Product()
            {
                Id = id,
                Name = name,
                CartItems = new List<CartItem>() { new CartItem() { Id = id, Amount = 1, Product = productDb } },
                ImagePath = imagePath,
                Size = size,
                Category = category,
                Cost = cost,
                Material = material
            };
            
        }

        [TestMethod]
        public void ToProductViewMdels_ListProducts_ListProductViewModels()
        {
            //Arrange
            List<Product> products = new List<Product>() { productDb};
            List<Product> productsTest = products;
            var expected = Mapping.ToProductViewModels(products);

            //Act
            var actual = Mapping.ToProductViewModels(productsTest);

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Id, actual[i].Id, "MappingTest ToProductViewModels Id");
                Assert.AreEqual(expected[i].Name, actual[i].Name, "MappingTest ToProductVuewModels Name");
                Assert.AreEqual(expected[i].ImagePath, actual[i].ImagePath, "MappingTest ToProductVuewModels ImagePath");
                Assert.AreEqual(expected[i].Material, actual[i].Material, "MappingTest ToProductVuewModels Material");
                Assert.AreEqual(expected[i].Size, actual[i].Size, "MappingTest ToProductVuewModels Size");
                Assert.AreEqual(expected[i].Category, actual[i].Category, "MappingTest ToProductVuewModels Category");
                Assert.AreEqual(expected[i].Cost, actual[i].Cost, "MappingTest ToProductVuewModels Cost");
            }
        }
    }
}
