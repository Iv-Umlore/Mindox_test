using FluentAssertions;
using NUnit.Framework;

namespace MindBoxUnitTest
{
    [TestFixture]
    public class FunctionalTests
    {
        [Test]
        public void IsWorks_Test()
        {
            Console.WriteLine("Test");
            var o = true;
            o.Should().BeTrue();
        }

        [Test]
        public void IsWorks_Test2()
        {
            Assert.IsTrue(true);
        }
    }
}