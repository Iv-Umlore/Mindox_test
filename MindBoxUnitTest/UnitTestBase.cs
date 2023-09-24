using FluentAssertions;
using NUnit.Framework;
using SimpleGeometryLib.Models.Base;

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

        [Test]
        public void EdgeComparison_SetupByLength_Test_AssertEqual()
        {
            // Arrange

            Edge firstEdge = new Edge(10.0);
            Edge secondEdge = new Edge(10.0);

            // Act
            bool result = firstEdge.EqualsLength(secondEdge);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void EdgeComparison_SetupByLength_Test_AssertNotEqual()
        {
            // Arrange

            Edge firstEdge = new Edge(10.0);
            Edge secondEdge = new Edge(10.1);

            // Act
            bool result = firstEdge.EqualsLength(secondEdge);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void EdgeComparison_SetupByPoints_Test_AssertEqual_1()
        {
            // Arrange

            Edge firstEdge = new Edge(
                new Point() {X = 0.0, Y = 0.0 },
                new Point() { X = 2.0, Y = 0.0 }
            );
            Edge secondEdge = new Edge(
                new Point() { X = 0.0, Y = 0.0 },
                new Point() { X = 2.0, Y = 0.0 }
            );

            // Act
            bool result = firstEdge.EqualsLength(secondEdge);

            // Assert
            result.Should().BeTrue();
        }
        
        [Test]
        public void EdgeComparison_SetupByPoints_Test_AssertEqual_2()
        {
            // Arrange

            Edge firstEdge = new Edge(
                new Point() { X = 0.0, Y = 0.0 },
                new Point() { X = 2.0, Y = 0.0 }
            );
            Edge secondEdge = new Edge(
                new Point() { X = 0.0, Y = 0.0 },
                new Point() { X = 0.0, Y = 2.0 }
            );

            // Act
            bool result = firstEdge.EqualsLength(secondEdge);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void EdgeComparison_SetupByPoints_Test_AssertNotEqual()
        {
            // Arrange

            Edge firstEdge = new Edge(
                new Point() { X = 1.0, Y = 0.0 },
                new Point() { X = 0.0, Y = 1.0 }
            );
            Edge secondEdge = new Edge(
                new Point() { X = 0.0, Y = 0.0 },
                new Point() { X = 0.0, Y = 2.0 }
            );

            // Act
            bool result = firstEdge.EqualsLength(secondEdge);

            // Assert
            result.Should().BeFalse();
        }
    }
}