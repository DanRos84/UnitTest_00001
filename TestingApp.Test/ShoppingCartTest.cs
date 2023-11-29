using TestingApp.Functionality;
using System;
using Xunit;
using Moq;

namespace TestingApp.Test
{

    public class ShoppingCartTest
    {
        private readonly Mock<IDbService> _dbServiceMock = new();

        
        [Fact]
        public void AddProduct_Success()
        {
            // Given
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);
        
            // When
            var product = new Product(1, "shoes", 150);
            var result = shoppingCart.AddProduct(product);
        
            // Then
            Assert.True(result);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void AddProduct_Failure_DueToInvilidPayload()
        {
            // Given
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);
        
            // When
            var result = shoppingCart.AddProduct(null);
        
            // Then
            Assert.False(result);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Never);
        }

        [Fact]
        public void RemoveProduct_Seccess()
        {
            // Given
            var shoppingCart = new ShoppingCart(_dbServiceMock.Object);
        
            // When
            var product = new Product(1, "shoes", 150);
            var result = shoppingCart.AddProduct(product);

            var deleteResult = shoppingCart.DeleteProduct(product.Id);
        
            // Then
            Assert.True(deleteResult);
            _dbServiceMock.Verify(x => x.SaveItemToShoppingCart(It.IsAny<Product>()), Times.Once);
        }
    }
    
}