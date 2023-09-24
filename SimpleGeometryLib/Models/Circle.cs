using SimpleGeometryLib.Models.Base;

namespace SimpleGeometryLib.Models
{
    public class Circle : Ellipse
    {
        public Circle(double radius) :base (1.0, radius) { }

        public override double GetArea()
        {
            return base.GetArea();
        }
    }
}
