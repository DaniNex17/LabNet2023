using Moq;

namespace RegionLogicTest
{
    public class RegionLogicTests
    {
        private Mock<IABMLogic<Region>> _regionLogicMock;
        private List<Region> _regionList;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}