using NUnit.Framework;
using SimpleGeometryLib.Models;
using SimpleGeometryLib.Models.Base;
using System;

namespace MindBoxUnitTest.Tests
{
    [TestFixture]
    public class EllipseCircleTests
    {
        [Test]
        public void CreateEllipse_Base()
        {
            Assert.DoesNotThrow(() => new Ellipse(0.5, 10));
        }

        [Test]
        public void CreateEllipse_Error_BadCoeff_Test1()
        {
            string expectExcMessage = "Коэффициент сжатия должен быть положительным";
            var exception = Assert.Catch(() => new Ellipse(0.0, 10));

            Assert.AreEqual(expectExcMessage, exception.Message);
        }

        [Test]
        public void CreateEllipse_Error_BadCoeff_Test2()
        {
            string expectExcMessage = "Коэффициент сжатия должен быть положительным";
            var exception = Assert.Catch(() => new Ellipse(-1.0, 10));

            Assert.AreEqual(expectExcMessage, exception.Message);
        }

        [Test]
        public void CreateEllipse_Error_BadRadius()
        {
            string expectExcMessage = "Радиус должен быть не отрицательным";
            var exception = Assert.Catch(() => new Ellipse(0.5, -2));

            Assert.AreEqual(expectExcMessage, exception.Message);
        }

        [Test]
        public void CreateEllipse_ZeroRadius_Correctly()
        {
            Assert.DoesNotThrow(() => new Ellipse(0.5, 0.0));
        }

        [Test]
        public void CreateCircle_Base()
        {
            Assert.DoesNotThrow(() => new Circle(10));
        }

        [Test]
        public void CreateCircle_Error_BadRadius()
        {
            string expectExcMessage = "Радиус должен быть не отрицательным";
            var exception = Assert.Catch(() => new Circle(-2));

            Assert.AreEqual(expectExcMessage, exception.Message);
        }

        [Test]
        public void CreateCircle_ZeroRadius_Correctly()
        {
            Assert.DoesNotThrow(() => new Circle(0));
        }

        // Эталонными значениями взяты значения онлайн калькулятора
        // При большой необходимости можно посчитать интеграл, но не обязательно

        [Test]
        public void ValueEllipse_Test1()
        {
            double expectedRoundValue = 25.13274;
            Ellipse ellipse = new Ellipse(2.0, 4); // Элипс с радиусами 4 и 4/2 = 2.0

            var result = Math.Round(ellipse.GetArea(), 5);

            Assert.AreEqual(expectedRoundValue, result);
        }

        [Test]
        public void ValueEllipse_Test2()
        {
            double expectedRoundValue = 100.53096;
            Ellipse ellipse = new Ellipse(0.5, 4); // Элипс с радиусами 4 и 4/0.5 = 8.0

            var result = Math.Round(ellipse.GetArea(), 5);

            Assert.AreEqual(expectedRoundValue, result);
        }

        [Test]
        public void ValueEllipse_ZeroRadius_Test()
        {
            double expectedRoundValue = 0.0;
            Ellipse ellipse = new Ellipse(2.0, 0); // Элипс с радиусами 0 и 0

            var result = Math.Round(ellipse.GetArea(), 4);

            Assert.AreEqual(expectedRoundValue, result);
        }

        [Test]
        public void ValueCircle_Test1()
        {
            double expectedRoundValue = 50.26548;
            Circle circle = new Circle(4); // Радиус 4

            var result = Math.Round(circle.GetArea(), 5);

            Assert.AreEqual(expectedRoundValue, result);
        }

        [Test]
        public void ValueCircle_Test2()
        {
            double expectedRoundValue = 31.00627667;
            double delta = Math.Pow(10, -6);
            Circle circle = new Circle(Math.Round(Math.PI, 10)); // Радиус 4

            var result = Math.Round(circle.GetArea(), 8);

            Assert.AreEqual(expectedRoundValue, result, delta);
        }

        [Test]
        public void ValueCircle_ZeroRadius_Test()
        {
            double expectedRoundValue = 0.0;
            Circle circle = new Circle(0); // Радиус 4

            var result = Math.Round(circle.GetArea(), 4);

            Assert.AreEqual(expectedRoundValue, result);
        }

    }
}
