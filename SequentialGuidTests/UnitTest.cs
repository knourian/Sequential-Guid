using SequentialGuid;

namespace SequentialGuidTests
{
    [TestClass]
    public class UnitTest
    {
        private readonly ISequentialGuid _sequenctialGuid;
        public UnitTest()
        {
            var services = new ServiceCollection();
            services.AddSequentialGuid();
            var serviceProvider = services.BuildServiceProvider();
            _sequenctialGuid = serviceProvider.GetService<ISequentialGuid>();
        }
        [TestMethod]
        public void Sequential_Guid_Should_Not_Be_Null()
        {
            Assert.IsNotNull(_sequenctialGuid);
        }
        [TestMethod]
        public void Cureent_Guid_Should_Not_Be_Null()
        {
            Assert.IsNotNull(_sequenctialGuid.GetCurrentGuid());
        }

        [TestMethod]
        public void Next_Guid_Should_Not_Be_Null()
        {
            Assert.IsNotNull(_sequenctialGuid.Next());
        }
        [TestMethod]
        public void Next_Guid_Should_Be_Greater()
        {
            var current = _sequenctialGuid.GetCurrentGuid();
            var next = _sequenctialGuid.Next();
            Assert.IsTrue(next.CompareTo(current) > 0);
        }
    }
}