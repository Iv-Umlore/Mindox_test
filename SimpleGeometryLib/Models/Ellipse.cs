using SimpleGeometryLib.Models.Base;

namespace SimpleGeometryLib.Models
{
    public class Ellipse : Figure
    {
        protected Point Center { get; set; }

        /// <summary>
        /// Коэффициент сжатия (отношение длинны к ширине эллипса)
        /// </summary>
        protected double CompressionCoefficient { get; private set; }

        public Ellipse(double compression)
        {
            Center = new Point() { X = 0, Y = 0 };
            CompressionCoefficient = compression;
        }

        public override double GetArea()
        {
            throw new NotImplementedException();
            return base.GetArea();
        }
    }
}
