using Microsoft.Extensions.Logging;
using Mmt.Shop.Api.Controllers;
using Mmt.Shop.Core.DataAccess.Readers;
using Mmt.Shop.Core.Entities;
using Mmt.Shop.TestUtil.Mothers;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Mmt.Shop.Unit.Tests.Api.Controllers
{
    public class WhenCategoryV1ControllerGetAllIsCalled : CategoryV1ControllerTestBase
    {
        private Task<IEnumerable<Category>> _result;

        [SetUp]
        public void SetUp()
        {
            CategoryReaderMock.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(CategoryMother.All));
            Assert.DoesNotThrow(() => _result = UnderTest.GetAll());
        }

        [Test]
        public void ShouldReturnExpectedResult()
        {
            _result.Result.ShouldBe(CategoryMother.All);
        }

        [Test]
        public void ShouldUseCategoryReader()
        {
            CategoryReaderMock.Verify(x => x.GetAllAsync());
        }
    }

    public abstract class CategoryV1ControllerTestBase
    {
        public Mock<ILogger<CategoryV1Controller>> LoggerMock { get; private set; }
        public Mock<ICategoryReader> CategoryReaderMock { get; private set; }
        public CategoryV1Controller UnderTest { get; private set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            LoggerMock = new Mock<ILogger<CategoryV1Controller>>(); 
            CategoryReaderMock = new Mock<ICategoryReader>();
            UnderTest = new CategoryV1Controller(LoggerMock.Object, CategoryReaderMock.Object);
        }
    }
}
