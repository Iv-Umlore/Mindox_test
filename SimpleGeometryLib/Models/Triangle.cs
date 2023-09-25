using SimpleGeometryLib.Models.Base;
using static SimpleGeometryLib.Functions.Supporting.Validation;

namespace SimpleGeometryLib.Models
{
    public class Triangle : Figure
    {
        protected List<Edge> _edgesList = null;

        public Triangle(Edge f, Edge s, Edge t) {
            if ( UpperZeroLength(f.Length, s.Length, t.Length) &&
                IsSideSmaller(f.Length, s.Length, t.Length) &&
                IsSideSmaller(t.Length, s.Length, f.Length) &&
                IsSideSmaller(f.Length, t.Length, s.Length)
                )
            {
                _edgesList = new List<Edge>() { f, s, t };
            }
            else
            {
                // Очевидно что данные строки должны быть вынесены в константы, но в рамках тестового решил не делать
                if (!UpperZeroLength(f.Length, s.Length, t.Length))
                    throw new ArgumentException("Одна или несколько из сторон меньше или равны 0.0");
                throw new ArgumentException("Сумма сторон треугольника не удовлетворяет основному правилу (сумма любых двух сторон больше третьей)");
            }
        }

        public Triangle(Point f, Point s, Point t)
        {
            // проверка не лежат ли они на одной прямой
            // по сути неравенство точек и удовлетворение главному правилу существования
            Edge first = new Edge(f, s);
            Edge second = new Edge(s, t);
            Edge third = new Edge(t, f);

            if (UpperZeroLength(first.Length, second.Length, third.Length) &&
                IsSideSmaller(first.Length, second.Length, third.Length) &&            
                IsSideSmaller(third.Length, first.Length, second.Length) &&
                IsSideSmaller(second.Length, third.Length, first.Length)
            )
            {
                _edgesList = new List<Edge>() { first, second, third };
            }
            else
            {
                // Очевидно что данные строки должны быть вынесены в константы, но в рамках тестового решил не делать
                if (!UpperZeroLength(first.Length, second.Length, third.Length))
                    throw new ArgumentException("Одна из сторон равна 0");
                throw new ArgumentException("Сумма сторон треугольника не удовлетворяет основному правилу (сумма любых двух сторон больше третьей)");
            }
        }

        /// <summary>
        /// Является ли треугольника прямоугольным
        /// </summary>
        public bool IsRightAngle()
        {
            // Находим самую длинную сторону
            Edge bestSide = _edgesList[0];

            _edgesList.ForEach(edge => {
                if (bestSide < edge)
                    bestSide = edge;
                });

            double summ = 0.0;

            _edgesList.ForEach(edge => { 
                if (edge != bestSide) {
                    summ += Math.Pow(edge.Length, 2); 
                } 
            });

            return summ.Equals(Math.Pow(bestSide.Length, 2));
        }

        public override double GetArea()
        {
            /*
                формула Герона
                S = SQRT( p*(p−a)*(p−b)*(p−c) )
                p = (a+b+c) / 2  // Полупериметр
             */

            double halfPerimeter = _edgesList.Sum(it => it.Length) / 2;
            double area = Math.Sqrt(
                halfPerimeter *
                (halfPerimeter - _edgesList[0].Length) *
                (halfPerimeter - _edgesList[1].Length) *
                (halfPerimeter - _edgesList[2].Length)
            );

            return area;
        }
    }
}
