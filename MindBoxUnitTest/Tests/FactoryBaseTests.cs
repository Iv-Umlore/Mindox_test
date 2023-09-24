using NUnit.Framework;
using SimpleGeometryLib.Factory;
using SimpleGeometryLib.Models;
using SimpleGeometryLib.Models.Base;

namespace MindBoxUnitTest.Tests
{
    [TestFixture]
    public class FactoryBaseTests
    {
        [Test]
        public void CheckCreateEllipce_TestBase()
        {
            double radius = 2.0;
            double coeff = 0.5;

            Ellipse expected = new Ellipse(coeff, radius);
            Ellipse ellipseFactoryRes = CircleFactory.CreateEllipse_ByRadiusAndCoeff(coeff, radius);

            double expectedArea = expected.GetArea();

            double resArea = ellipseFactoryRes.GetArea();

            Assert.AreEqual(expectedArea, resArea);
        }

        [Test]
        public void CheckCreateEllipce_TestSecond()
        {
            double radius = 4.0;
            double coeff = 0.5;

            // coeff = radius1 / radius2
            // coeff > 0
            // radius1 = coeff * radius2
            // radius2 = radius1 / coeff

            Ellipse expected = new Ellipse(coeff, radius);
            Ellipse ellipseFactoryRes = CircleFactory.CreateEllipse_ByTwoRadius(radius / coeff, radius);

            double expectedArea = expected.GetArea();

            double resArea = ellipseFactoryRes.GetArea();

            Assert.AreEqual(expectedArea, resArea);
        }

        [Test]
        public void CheckCreateEllipce_TestThird()
        {
            double radius = 4.0;
            double coeff = 0.5;

            Ellipse expected = new Ellipse(coeff, radius);
            Ellipse ellipseFactoryRes = CircleFactory.CreateEllipse_ByTwoRadius(radius, radius / coeff);

            double expectedArea = expected.GetArea();

            double resArea = ellipseFactoryRes.GetArea();

            Assert.AreEqual(expectedArea, resArea);
        }

        [Test]
        public void CheckCreateCircle_TestBase()
        {
            Circle circle = new Circle(4.0);
            var second = CircleFactory.CreateCircle(4.0);

            Assert.AreEqual(circle.GetArea(), second.GetArea());
        }
    }
}
