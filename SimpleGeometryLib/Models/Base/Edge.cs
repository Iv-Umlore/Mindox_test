using SimpleGeometryLib.Functions.HelpFunc;

namespace SimpleGeometryLib.Models.Base
{
    /// <summary>
    /// Сторона
    /// </summary>
    public class Edge
    {
        private Point _firstPoint;
        private Point _secondPoint;

        public Point FPoint {
            get
            {
                if (_firstPoint == null)
                    throw new ArgumentNullException("Не задана первая точка");
                return _firstPoint;
            }
            private set { 
                if (value == null)
                    throw new ArgumentNullException("Попытка присвоить NULL первой точке");
                _firstPoint = value;
            }
        }

        public Point SPoint
        {
            get { 
                if (_secondPoint == null)
                    throw new ArgumentNullException("Не задана вторая точка");
                    return _secondPoint;
            }
            private set {
                if (value == null)
                    throw new ArgumentNullException("Попытка присвоить NULL второй точке");
                _secondPoint = value; 
            }
        }

        public double Length { get; private set; }

        public Edge(Point first, Point second) {

            FPoint = first;
            SPoint = second;

            Length = HelpFunc.GetDistance(first, second);
        }

        public Edge(double length) {
            Length = length;
        }

        public void SetUpPoints(Point first, Point second)
        {
            FPoint = first;
            SPoint = second;
        }
    }
}
