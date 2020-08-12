using Dapper;
using Mmt.Shop.Core.Entities;
using Mmt.Shop.DataAccess.Dapper.Readers;
using Mmt.Shop.TestUtil.Mothers;
using Moq;
using Moq.Dapper;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Mmt.Shop.DataAccess.Dapper.Unit.Tests.Readers
{
    public class WhenProductReaderGetProductsByCategoryIdAsyncIsCalled : ProductReaderTestBase
    {
        private Task<IEnumerable<Product>> _result;

        [SetUp]
        public void SetUp()
        {
            ConnectionMock.SetupDapperAsync(x => x.QueryAsync<Product>(It.IsAny<string>(), It.IsAny<object>(), null, null, null))
                .ReturnsAsync(ProductMother.OfCategory);
            
            Assert.DoesNotThrow(() => _result = UnderTest.GetProductsByCategoryIdAsync(1));
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(ProductMother.OfCategory);
        }
    }

    public class WhenProductReaderGetFeaturedAsyncIsCalled : ProductReaderTestBase
    {
        private Task<IEnumerable<Product>> _result;

        [SetUp]
        public void SetUp()
        {
            ConnectionMock.SetupDapperAsync(x => x.QueryAsync<Product>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(ProductMother.Featured);
            
            Assert.DoesNotThrow(() => _result = UnderTest.GetFeaturedProductsAsync());
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(ProductMother.Featured);
        }
    }

    public abstract class ProductReaderTestBase
    {
        protected Mock<IDbConnection> ConnectionMock { get; private set; }

        protected ProductReader UnderTest { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ConnectionMock = new Mock<IDbConnection>();
            UnderTest = new ProductReader(ConnectionMock.Object);
        }
    }
}
