using SequentialGuid;
namespace SequentialGuidTests
{
    [TestClass]
    public class UnitTest
    {
        public UnitTest()
        {
        }

        [TestMethod]
        public void Cureent_Guid_Should_Not_Be_Null()
        {
            Assert.IsNotNull(GuidInstance.GetCurrentGuid());
        }

        [TestMethod]
        public void Next_Guid_Should_Not_Be_Null()
        {
            Assert.IsNotNull(GuidInstance.Next());
        }
        [TestMethod]
        public void Next_Guid_Should_Be_Greater()
        {
            var current = GuidInstance.GetCurrentGuid();
            var next = GuidInstance.Next();
            Assert.IsTrue(next.CompareTo(current) > 0);
        }

        [TestMethod]
        public void Check_Seed_Method()
        {
            Guid current = GuidInstance.GetCurrentGuid();
            Guid next = Guid.NewGuid();
            GuidInstance.SetSeed(next);
            Guid NewCurrnet = GuidInstance.GetCurrentGuid();
            Assert.IsNotNull(NewCurrnet);
            Assert.IsTrue(next.CompareTo(NewCurrnet) == 0);
            Assert.IsTrue(current.CompareTo(NewCurrnet) != 0);
        }
    }
}
