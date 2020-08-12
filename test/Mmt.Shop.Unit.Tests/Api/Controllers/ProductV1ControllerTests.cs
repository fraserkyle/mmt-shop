using Microsoft.Extensions.Logging;
using Mmt.Shop.Api.Controllers;
using Mmt.Shop.Core.DataAccess.Readers;
using Mmt.Shop.Core.Entities;
using Mmt.Shop.TestUtil.Mothers;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mmt.Shop.Unit.Tests.Api.Controllers
{
    public class WhenProductV1ControllerGetProductsByCategoryIdIsCalled : ProductV1ControllerTestBase
    {
        private Task<IEnumerable<Product>> _result;

        [SetUp]
        public void SetUp()
        {
            ProductReaderMock.Setup(x => x.GetProductsByCategoryIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(ProductMother.OfCategory));
            Assert.DoesNotThrow(() => _result = UnderTest.GetProductsByCategoryIdAsync(1));
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(ProductMother.OfCategory);
        }                

        [Test]
        public void ShouldUseProductReader()
        {
            ProductReaderMock.Verify(x => x.GetProductsByCategoryIdAsync(It.IsAny<int>()));
        }
    }    
    
    public class WhenProductV1ControllerGetFeaturedIsCalled : ProductV1ControllerTestBase
    {
        private Task<IEnumerable<Product>> _result;

        [SetUp]
        public void SetUp()
        {
            ProductReaderMock.Setup(x => x.GetFeaturedProductsAsync())
                .Returns(Task.FromResult(ProductMother.Featured));
            Assert.DoesNotThrow(() => _result = UnderTest.GetFeaturedAsync());
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(ProductMother.Featured);
        }                

        [Test]
        public void ShouldUseProductReader()
        {
            ProductReaderMock.Verify(x => x.GetFeaturedProductsAsync());
        }
    }

    public abstract class ProductV1ControllerTestBase
    {
        public Mock<ILogger<ProductV1Controller>> LoggerMock { get; private set; }
        public Mock<IProductReader> ProductReaderMock { get; private set; }
        public ProductV1Controller UnderTest { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            LoggerMock = new Mock<ILogger<ProductV1Controller>>(); 
            ProductReaderMock = new Mock<IProductReader>();
            UnderTest = new ProductV1Controller(LoggerMock.Object, ProductReaderMock.Object);
        }
    }
}
