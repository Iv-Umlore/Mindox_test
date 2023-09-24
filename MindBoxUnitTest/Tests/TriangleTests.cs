using FluentAssertions;
using NUnit.Framework;
using SimpleGeometryLib.Models;
using SimpleGeometryLib.Models.Base;

namespace MindBoxUnitTest.Tests
{
    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void CreateTriangle_Test_Base_ExpectNotException()
        {
            Assert.DoesNotThrow(() => new Triangle(
                new Point() { X = 0.0, Y = 0.0 },
                new Point() { X = 0.0, Y = 1.0 },
                new Point() { X = 1.0, Y = 1.0 }
                ));
        }
        
        [Test]
        public void CreateTriangle_ByPoints_Test_OneSideZero_ExpectException()
        {
            string expectException = "Одна из сторон равна 0";

            var exception = Assert.Catch(()=>new Triangle(
                new Point() { X = 0.0, Y = 0.0 },
                new Point() { X = 0.0, Y = 0.0 },
                new Point() { X = 1.0, Y = 1.0 }
                ));

            Assert.AreEqual(expectException, exception.Message);
        }

        [Test]
        public void CreateTriangle_ByPoints_Test_OnOneLine_ExpectException()
        {
            string expectException = "Сумма сторон треугольника не удовлетворяет основному правилу (сумма любых двух сторон больше третьей)";

            // Точки лежат на одной стороне
            var exception = Assert.Catch(() => new Triangle(
                new Point() { X = 0.0, Y = 0.0 },
                new Point() { X = 3.0, Y = 0.0 },
                new Point() { X = 1.5, Y = 0.0 }
                ));

            Assert.AreEqual(expectException, exception.Message);
        }

        [Test]
        public void CreateTriangle_BySides_Correctly_Test1()
        {
            Assert.DoesNotThrow(() => new Triangle(GoodEdge_Ten, GoodEdge_Seven, GoodEdge_Five));
        }

        [Test]
        public void CreateTriangle_BySides_Correctly_Test2()
        {
            Assert.DoesNotThrow(() => new Triangle(GoodEdge_Five, GoodEdge_Five, GoodEdge_Five));
        }

        [Test]
        public void CreateTriangle_BySides_ExceptionByZeroSide()
        {
            string expectedExcMessage = "Одна или несколько из сторон меньше или равны 0.0";

            var exc = Assert.Catch(() => new Triangle(GoodEdge_Ten, GoodEdge_Seven, BadEdge_Zero));

            Assert.AreEqual(expectedExcMessage, exc.Message);
        }

        [Test]
        public void CreateTriangle_BySides_ExceptionByUnderZero()
        {
            string expectedExcMessage = "Одна или несколько из сторон меньше или равны 0.0";

            var exc = Assert.Catch(() => new Triangle(GoodEdge_Ten, GoodEdge_Seven, BadEdge_UnderZero));

            Assert.AreEqual(expectedExcMessage, exc.Message);
        }

        [Test]
        public void CreateTriangle_BySides_BadTriangleRule()
        {
            string expectedExcMessage = "Сумма сторон треугольника не удовлетворяет основному правилу (сумма любых двух сторон больше третьей)";

            var exc = Assert.Catch(() => new Triangle(GoodEdge_Ten, GoodEdge_Five, GoodEdge_Five));

            Assert.AreEqual(expectedExcMessage, exc.Message);
        }

        // Эталонным значением будет взято значение с онлайн калькуляторов

        [Test]
        public void CheckCorrect_GetArea_Test1()
        {
            double expectedValue = 54.0;
            var triangle = new Triangle(
                   new Edge(9.0),
                   new Edge(12.0),
                   new Edge(15.0)
               );

            var res = triangle.GetArea();

            Assert.AreEqual(expectedValue, res);
        }

        [Test]
        public void CheckCorrect_GetArea_Test2()
        {
            double expectRoundValue = 24.494897;
            Triangle triangle = new Triangle(GoodEdge_Ten, GoodEdge_Seven, GoodEdge_Seven);

            var resRound = Math.Round(triangle.GetArea(), 6);

            Assert.AreEqual(expectRoundValue, resRound);
        }

        [Test]
        public void CheckCorrect_GetArea_Test3()
        {
            double expectedRoundValue = 51.17067;

            Triangle triangle = new Triangle(new Edge(8.0), new Edge(13.0), new Edge(14.0));

            var resRound = Math.Round(triangle.GetArea(), 5);

            Assert.AreEqual(expectedRoundValue, resRound);
        }

        [Test]
        public void CheckCorrect_IsRightAngle_ExpectTrue()
        {
            var triangle = new Triangle(
                    new Edge(9.0),
                    new Edge(12.0),
                    new Edge(15.0)
                );

            bool IsRight = triangle.IsRightAngle();

            Assert.IsTrue(IsRight);
        }

        [Test]
        public void CheckCorrect_IsRightAngle_Test2()
        {
            var triangle = new Triangle( GoodEdge_Ten, GoodEdge_Ten, GoodEdge_Ten);

            bool IsRight = triangle.IsRightAngle();

            Assert.IsFalse(IsRight);
        }

        [Test]
        public void CheckCorrect_IsRightAngle_Test3()
        {
            var triangle = new Triangle(GoodEdge_Ten, GoodEdge_Five, GoodEdge_Seven);

            bool IsRight = triangle.IsRightAngle();

            Assert.IsFalse(IsRight);
        }

        #region DATA

        private Edge GoodEdge_Ten = new Edge(10.0);
        private Edge GoodEdge_Five = new Edge(5.0);
        private Edge GoodEdge_Seven = new Edge(7.0);
        private Edge BadEdge_Zero = new Edge(0.0);     
        
        /// <summary>
        /// Отдельно стоило бы проверить отрицательные значения, но это проверяется уровнем выше
        /// </summary>
        private Edge BadEdge_UnderZero = new Edge(-1.0);

        #endregion
    }
}
