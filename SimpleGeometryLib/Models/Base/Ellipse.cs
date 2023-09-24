namespace SimpleGeometryLib.Models.Base
{
    public class Ellipse : Figure
    {
        protected Point Center { get; set; }

        protected double Radius { get; set; }

        protected double SecondRadius { get; set; }

        /// <summary>
        /// Коэффициент сжатия (отношение известного радиуса к неизвестному)
        /// </summary>
        protected double CompressionCoefficient { get; private set; }

        /// <summary>
        /// Конструктор эллипсов
        /// </summary>
        /// <param name="compression"> Отношение известного радиуса к неизвестному </param>
        /// <param name="radius"> Известный радиус </param>
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
            SecondRadius = Radius / CompressionCoefficient;
        }

        public override double GetArea()
        {
            // Pi * a * b
            return Math.PI * Radius * SecondRadius;
        }
    }
}
