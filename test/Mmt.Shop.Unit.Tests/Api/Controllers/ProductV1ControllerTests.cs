using Microsoft.Extensions.Logging;
using Mmt.Shop.Api.Controllers;
using Mmt.Shop.Core.DataAccess.Readers;
using Mmt.Shop.Core.Entities;
using Mmt.Shop.TestUtil.Mothers;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmt.Shop.Unit.Tests.Api.Controllers
{
    public class WhenGetFeaturedIsCalled : ProductV1ControllerTestBase
    {
        private Task<IEnumerable<Product>> _result;

        [SetUp]
        public void SetUp()
        {
            FeaturedProductReaderMock.Setup(x => x.GetFeaturedProducts())
                .Returns(Task.FromResult(ProductMother.Featured));
            Assert.DoesNotThrow(() => _result = UnderTest.GetFeatured());
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(ProductMother.Featured);
        }
    }

    public abstract class ProductV1ControllerTestBase
    {
        public Mock<ILogger<ProductV1Controller>> LoggerMock { get; private set; }
        public Mock<IFeaturedProductReader> FeaturedProductReaderMock { get; private set; }
        public ProductV1Controller UnderTest { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            LoggerMock = new Mock<ILogger<ProductV1Controller>>(); 
            FeaturedProductReaderMock = new Mock<IFeaturedProductReader>();
            UnderTest = new ProductV1Controller(LoggerMock.Object, FeaturedProductReaderMock.Object);
        }
    }
}
