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
    public class WhenCategoryReaderGetAllAsyncIsCalled : CategoryReaderTestBase
    {
        private Task<IEnumerable<Category>> _result;

        [SetUp]
        public void SetUp()
        {
            ConnectionMock.SetupDapperAsync(x => x.QueryAsync<Category>(It.IsAny<string>(), null, null, null, null))
                .ReturnsAsync(CategoryMother.All);
            
            Assert.DoesNotThrow(() => _result = UnderTest.GetAllAsync());
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(CategoryMother.All);
        }
    }

    public abstract class CategoryReaderTestBase
    {
        protected Mock<IDbConnection> ConnectionMock { get; private set; }

        protected CategoryReader UnderTest { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ConnectionMock = new Mock<IDbConnection>();
            UnderTest = new CategoryReader(ConnectionMock.Object);
        }
    }
}
