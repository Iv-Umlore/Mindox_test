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

        /// <summary>
        /// Задача многоугольника по координатам его вершины в строгой последовательности
        /// </summary>
        public Poligon(Point[] points) {
            if (points.Length < 3)
                throw new Exception("Слишком мало точек для построения фигуры");

            Point startPoint = points[0];
            Point secondHelpPoint = points[1];

            Triangles = new List<Triangle>();

            for (int i = 2; i < points.Length; i++)
            {
                Point tmpPoint = points[i];
                Triangles.Add(new Triangle(
                        startPoint, secondHelpPoint, tmpPoint ));

                secondHelpPoint = tmpPoint;
            }
        }

        [Obsolete("Метод не является достоверным. Формирование итоговых треугольников ложится на разработчика")]
        public Poligon(double[] lengths)
        {
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
            double area = 0.0;
            foreach (var triangle in Triangles)
            {
                area += triangle.GetArea();
            }

            return area;
        }
    }
}
