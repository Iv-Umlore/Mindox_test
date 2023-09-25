using SimpleGeometryLib.Models.Base;

namespace SimpleGeometryLib.Models
{
    /// <summary>
    /// Буду считать, что стороны фигуры не пересекают друг друга ( фигура является цельной и однокомпонентной)
    /// UPD: Так же фигура является выпуклой
    /// Данный аспект возможно обработать через LinkedList и кучу костылей, но в рамках этого тестового, думаю, не обязательно
    /// </summary>
    public class Poligon : Figure
    {
        private List<Triangle> Triangles { get; set; }

        private Point[] Points { get; set; }

        /// <summary>
        /// Задача многоугольника по координатам его вершины в строгой последовательности
        /// </summary>
        public Poligon(Point[] points) {
            if (points.Length < 3)
                throw new Exception("Слишком мало точек для построения фигуры");

            Points = points;
        }

        /// <summary>
        /// Задание многоугольника через длины сторон его внутренних треугольников
        /// </summary>
        [Obsolete("Метод не является достоверным. Формирование итоговых треугольников ложится на разработчика")]
        public Poligon(double[] lengths)
        {
            if (lengths.Length < 3)
                throw new ArgumentException("Слишком мало параметров для задния многоугольника");

            if (lengths.Length % 3 != 0)
                throw new ArgumentException("Число длин сторон треугольников не кратно 3");

            Triangles = new List<Triangle>();
            for (int i = 0; i < lengths.Length; i += 3)
            {
                Triangles.Add(new Triangle(
                        new Edge(lengths[i]),
                        new Edge(lengths[i + 1]),
                        new Edge(lengths[i + 2])));
            }
        }


        public override double GetArea()
        {
            // Использую метод Гауса
            if (Points != null)
            {
                double sum = 0.0;
                double tmpSum = 0.0;

                //  Модуль(сумма всех Xi*Yi+1 + Xn*Y1 - все Xi+1 * Yi - X1 * Yn) * 1/2

                for (int i = 0; i < Points.Length - 1; i++)
                {
                    tmpSum += Points[i].X * Points[i + 1].Y;
                    tmpSum -= Points[i + 1].X * Points[i].Y;
                }
                sum = Math.Abs( tmpSum + Points[Points.Length - 1].X * Points[0].Y - Points[0].X * Points[Points.Length - 1].Y ) / 2;
                return sum;
            }

            if (Triangles != null) {
                double area = 0.0;
                foreach (var triangle in Triangles)
                {
                    area += triangle.GetArea();
                }

                return area;
            }

            throw new Exception("Достигнут недостижимый блок кода");            
        }
    }
}
