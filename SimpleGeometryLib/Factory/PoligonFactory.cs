using SimpleGeometryLib.Models;
using SimpleGeometryLib.Models.Base;

namespace SimpleGeometryLib.Factory
{
    public static class PoligonFactory
    {
        public static Triangle CreateTriangle_ByPoints(Point first, Point second, Point third)
        {
            return new Triangle(first, second, third);
        }
        
        public static Triangle CreateTriangle_ByEdgeLength(double first, double second, double third)
        {
            return new Triangle(new Edge(first), new Edge(second), new Edge(third));
        }

        public static Triangle CreateTriangle_ByEdge(Edge first, Edge second, Edge third)
        {
            return new Triangle(first, second, third);
        }

        public static Poligon CreatePoligon_ByPoints(params Point[] points)
        {
            return new Poligon(points);
        }

        [Obsolete("Метод не является достоверным")]
        public static Poligon CreatePoligon_ByEdgesLength(params double[] lengths)
        {
            return new Poligon(lengths);
        }
    }
}
