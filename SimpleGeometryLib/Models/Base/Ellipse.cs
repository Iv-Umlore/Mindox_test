namespace SimpleGeometryLib.Models.Base
{
    public class Ellipse : Figure
    {
        protected Point Center { get; set; }

        protected double Radius { get; set; }

        /// <summary>
        /// Коэффициент сжатия (отношение длинны к ширине эллипса)
        /// </summary>
        protected double CompressionCoefficient { get; private set; }

        public Ellipse(double compression, double radius)
        {
            Center = new Point() { X = 0, Y = 0 };

            // Очевидно что данные строки должны быть вынесены в константы, но в рамках тестового решил не делать
            if (compression <= 0.0 ) 
                throw new ArgumentException("Коэффициент сжатия должен быть положительным");
            if (radius < 0.0) 
                throw new ArgumentException("Радиус должен быть не отрицательным");

            CompressionCoefficient = compression;
            Radius = radius;
        }

        public override double GetArea()
        {
            // Pi * a * b
            // Считаем что b = a * K, или a = b/K
            return Math.PI * Math.Pow(Radius, 2) / CompressionCoefficient;
        }
    }
}
