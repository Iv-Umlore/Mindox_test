using NUnit.Framework;
using SimpleGeometryLib.Factory;
using SimpleGeometryLib.Functions.Supporting;
using SimpleGeometryLib.Models.Base;
using SimpleGeometryLib.Models;
using SimpleGeometryLib.Functions;

namespace MindBoxUnitTest.Tests
{
    [TestFixture]
    public class StaticAreaTest
    {
        private const double delta = 0.0001;

        #region Get_area_known_figure

        [Test]
        public void GetTriangleArea_Test1_ByPoints()
        {
            Triangle expected = new Triangle(Zero, First, Second);
            double expectedArea = expected.GetArea();
            double expectedValue = 8.0;

            double res = Areas.GetTriangleArea(Zero, First, Second);

            Assert.AreEqual(expectedArea, res, delta);
            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetTriangleArea_Test2_ByEdges()
        {
            Triangle expected = new Triangle(
                new Edge(Zero, First),
                new Edge(Zero, Second),
                new Edge(Second, First));
            double expectedArea = expected.GetArea();
            double expectedValue = 8.0;

            double res = Areas.GetTriangleArea(
                new Edge(Zero, First),
                new Edge(Zero, Second),
                new Edge(Second, First));

            Assert.AreEqual(expectedArea, res, delta);
            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetTriangleArea_Test3_ByEdgeLengths()
        {
            Triangle expected = new Triangle(Zero, First, Second);
            double expectedArea = expected.GetArea();
            double expectedValue = 8.0;

            double res = Areas.GetTriangleArea(4, 4, HelpFunc.GetDistance(First, Second));

            Assert.AreEqual(expectedArea, res, delta);
            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetCircleArea_Test()
        {
            double radius = 2.0;
            Circle circ = new Circle(radius);
            double expectedArea = circ.GetArea();
            double expectedRoundValue = 12.56637;

            double res = Math.Round(Areas.GetCircleArea(radius), 5);

            Assert.AreEqual(expectedArea, res, delta);
            Assert.AreEqual(expectedRoundValue, res, delta);
        }

        [Test]
        public void GetEllipseArea_Test_ByCoeff()
        {
            double radius2 = 4.0;
            double coeff = 2;
            Ellipse circ = new Ellipse(coeff, radius2);
            double expectedArea = circ.GetArea();
            double expectedRoundValue = 25.13274;

            double res = Math.Round(Areas.GetEllipseArea(coeff, radius2), 5);

            Assert.AreEqual(expectedArea, res, delta);
            Assert.AreEqual(expectedRoundValue, res, delta);
        }

        [Test]
        public void GetEllipseArea_Test_ByTwoRadius()
        {
            double radius1 = 2.0, radius2 = 4.0;
            Ellipse circ = new Ellipse(radius1, radius2);
            double expectedArea = circ.GetArea();
            double expectedRoundValue = 25.13274;

            double res = Math.Round(Areas.GetEllipseArea_ByTwoRadius(radius1, radius2), 5);

            Assert.AreEqual(expectedArea, res, delta);
            Assert.AreEqual(expectedRoundValue, res, delta);
        }

        #endregion

        #region Get_area_unknown_figure_by_length

        [Test]
        public void GetUniversalArea_ByLength_Test_Circle()
        {
            double radius = 2.0;
            double expectedValue = new Circle(radius).GetArea();

            double res = Areas.GetUniversalArea_ByLength(radius);

            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetUniversalArea_ByLength_Test_Ellipse()
        {
            double radius1 = 2.0, radius2 = 4.0;
            double expectedValue = new Ellipse(radius1, radius2).GetArea();

            double res = Areas.GetUniversalArea_ByLength(radius1, radius2);

            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetUniversalArea_ByLength_Test_Triangle()
        {
            var expectedValue = 54.0;
            double l1 = 9.0, l2 = 12.0, l3 = 15.0;

            double res = Areas.GetUniversalArea_ByLength(l1, l2, l3);

            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetUniversalArea_ByLength_Poligon_Test_1()
        {
            var expectedValue = 16;
            double tri1_Len1 = 4.0, tri1_Len2 = 4.0, tri1_Len3 = Math.Sqrt(16.0 + 16.0); // Половина квадрата
            double tri2_Len1 = 4.0, tri2_Len2 = 4.0, tri2_Len3 = Math.Sqrt(16.0 + 16.0); // Вторая половина квадрата

            double res = Areas.GetUniversalArea_ByLength(
                tri1_Len1, tri1_Len2, tri1_Len3,
                tri2_Len1, tri2_Len2, tri2_Len3);

            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetUniversalArea_ByLength_Poligon_Test_2()
        {
            double tri1_Len1 = 4.0;
            double tri1_Len2 = 4.0;
            double tri1_Len3 = HelpFunc.GetDistance(First, Second);

            double tri2_Len1 = HelpFunc.GetDistance(First, Fourth);
            double tri2_Len2 = HelpFunc.GetDistance(Fourth, Second);
            double tri2_Len3 = HelpFunc.GetDistance(First, Second);

            double expectedValue =
                new Triangle(new Edge(tri1_Len1), new Edge(tri1_Len2), new Edge(tri1_Len3)).GetArea() +
                new Triangle(new Edge(tri2_Len1), new Edge(tri2_Len2), new Edge(tri2_Len3)).GetArea();

            double res = Areas.GetUniversalArea_ByLength(
                tri1_Len1, tri1_Len2, tri1_Len3,
                tri2_Len1, tri2_Len2, tri2_Len3);

            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void CheckException_UniversalByLength_NoneParameters()
        {
            var exceptMessageExpect = "Необходимо указать хотя бы одно значение";

            var except = Assert.Catch(() => Areas.GetUniversalArea_ByLength(null));

            Assert.AreEqual(exceptMessageExpect, except.Message);
        }

        [Test]
        public void CheckException_UniversalByLength_BadCountParameters()
        {
            var exceptMessageExpect = "Число длинн ребер для многоугольника должно быть кратно 3, при использовании метода GetUniversalArea_ByLength. Советую использовать метод GetUniversalArea_ByPoints";

            var except = Assert.Catch(() => Areas.GetUniversalArea_ByLength(1.0, 2.0, 3.0, 4.0));

            Assert.AreEqual(exceptMessageExpect, except.Message);
        }

        #endregion

        #region Get_area_unknown_figure_by_points

        [Test]
        public void GetUniversalArea_ByPoints_Test_Circle()
        {
            double expectedValue = new Circle(First.X).GetArea();

            var res = Areas.GetUniversalArea(First);

            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetUniversalArea_ByPoints_Test_Ellipse()
        {
            double expectedValue = CircleFactory.CreateEllipse_ByTwoRadius(2.0, 4.0).GetArea();

            var res = Areas.GetUniversalArea(First, new Point() { X = 0, Y = 2 });

            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetUniversalArea_ByPoints_Test_Triangle()
        {
            double expectedValue = 8.0;

            var res = Areas.GetUniversalArea(Zero, First, Second);

            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetUniversalArea_ByPoints_Poligon_Test_1()
        {
            double expectedValue = 16.0;

            var res = Areas.GetUniversalArea(Zero, First, Third, Second);

            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void GetUniversalArea_ByPoints_Poligon_Test_2()
        {
            double expectedValue =
                PoligonFactory.CreateTriangle_ByPoints(First, Third, Second).GetArea() +
                PoligonFactory.CreateTriangle_ByPoints(First, Fives, Second).GetArea() +
                PoligonFactory.CreateTriangle_ByPoints(Fourth, Fives, Second).GetArea();

            // (0:4) - (4:4) - (4:0) - (-2:-2) - (-4:0)
            var res = Areas.GetUniversalArea(Second, Third, First, Fourth, Fives);

            Assert.AreEqual(expectedValue, res, delta);
        }

        [Test]
        public void CheckException_UniversalByPoints_NoneParameters()
        {
            var exceptMessageExpect = "Необходимо указать хотя бы одно значение";

            var except = Assert.Catch(() => Areas.GetUniversalArea(null));

            Assert.AreEqual(exceptMessageExpect, except.Message);
        }

        [Test]
        public void CheckException_UniversalByPoints_BadPointsForEllipse()
        {
            var exceptMessageExpect = "Точки для задания радиусов элипса должны располагаться разных координатных осях";

            var except = Assert.Catch(() => Areas.GetUniversalArea(First, Third));

            Assert.AreEqual(exceptMessageExpect, except.Message);
        }

        #endregion

        #region Data

        private Point Zero = new Point() { X = 0, Y = 0 };
        private Point First = new Point() { X = 4, Y = 0 };
        private Point Second = new Point() { X = 0, Y = 4 };
        private Point Third = new Point() { X = 4, Y = 4 };
        private Point Fourth = new Point() { X = -2, Y = -2 };
        private Point Fives = new Point() { X = -4, Y = 0 };

        #endregion
    }
}
