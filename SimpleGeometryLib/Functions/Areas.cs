using SimpleGeometryLib.Models;
using SimpleGeometryLib.Models.Base;

namespace SimpleGeometryLib.Functions
{
    public static class Areas
    {
        public static double GetTriangleArea(Point first, Point second, Point third)
        {
            var triangle = new Triangle(first, second, third);

            return triangle.GetArea();
        }

        public static double GetTriangleArea(Edge first, Edge second, Edge third)
        {
            var triangle = new Triangle(first, second, third);

            return triangle.GetArea();
        }

        public static double GetCircleArea(double Radius)
        {
            var circle = new Circle(Radius);

            return circle.GetArea();
        }

        public static double GetEllipseArea(double coeff, double Radius)
        {
            var ellipse = new Ellipse(coeff, Radius);

            return ellipse.GetArea();
        }
    }
}
