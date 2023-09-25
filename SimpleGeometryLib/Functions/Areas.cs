using SimpleGeometryLib.Factory;
using SimpleGeometryLib.Functions.Supporting;
using SimpleGeometryLib.Models.Base;

namespace SimpleGeometryLib.Functions
{
    public static class Areas
    {
        #region Мы знаем тип фигуры

        /// <summary>
        /// Получить площать треугольника по координатам вершины
        /// </summary>
        public static double GetTriangleArea(Point first, Point second, Point third)
        {
            var triangle = PoligonFactory.CreateTriangle_ByPoints(first, second, third);

            return triangle.GetArea();
        }

        /// <summary>
        /// Получить площать треугольника по его ребрам
        /// </summary>
        public static double GetTriangleArea(Edge first, Edge second, Edge third)
        {
            var triangle = PoligonFactory.CreateTriangle_ByEdge(first, second, third);

            return triangle.GetArea();
        }

        /// <summary>
        /// Получить площать треугольника по длинне его ребер
        /// </summary>
        public static double GetTriangleArea(double first, double second, double third)
        {
            var triangle = PoligonFactory.CreateTriangle_ByEdgeLength(first, second, third);
            return triangle.GetArea();
        }

        /// <summary>
        /// Получить площать круга по радиусу
        /// </summary>
        public static double GetCircleArea(double Radius)
        {
            var circle = CircleFactory.CreateCircle(Radius);

            return circle.GetArea();
        }

        /// <summary>
        /// Получить площать эллипса по его радиусу и коэфициенту сжатия
        /// </summary>
        public static double GetEllipseArea(double coeff, double Radius)
        {
            var ellipse = CircleFactory.CreateEllipse_ByRadiusAndCoeff(coeff, Radius);

            return ellipse.GetArea();
        }

        /// <summary>
        /// Получить площать эллипса по двум радиусам
        /// </summary>
        public static double GetEllipseArea_ByTwoRadius(double Radius1, double Radius2)
        {
            var ellipse = CircleFactory.CreateEllipse_ByTwoRadius(Radius1, Radius2);

            return ellipse.GetArea();
        }

        #endregion

        #region Мы не знаем тип фигуры

        /// <summary>
        /// В зависимости от числа параметров возвращает площадь полученной фигуры 1 - круг(радиус), 2 - эллипс (2 радиуса), 3 - стороны треугольника, 4 и более - многоугольник (необходимо задавать параметры змейкой - разбиение многоугольника на треугольники проводит сам пользователь)
        /// </summary>
        /// <returns> Прощадь фигуры </returns>
        [Obsolete("Метод не является достоверным")]        
        public static double GetUniversalArea_ByLength(params double[] values)
        {
            if (values == null || values.Length <= 0)
                throw new ArgumentException("Необходимо указать хотя бы одно значение");

            switch(values.Length)
            {
                case 1:
                    return CircleFactory.CreateCircle(values[0]).GetArea();

                case 2:
                    return CircleFactory.CreateEllipse_ByTwoRadius(values[0], values[1]).GetArea();

                case 3:
                    return PoligonFactory.CreateTriangle_ByEdgeLength(values[0], values[1], values[2]).GetArea();

                default:
                    if (values.Length % 3 != 0)
                        throw new ArgumentException("Число длинн ребер для многоугольника должно быть кратно 3, при использовании метода GetUniversalArea_ByLength. Советую использовать метод GetUniversalArea_ByPoints");
                    return PoligonFactory.CreatePoligon_ByEdgesLength(values).GetArea();
            }
        }

        /// <summary>
        /// В зависимости от числа параметров возвращает площадь полученной фигуры 1 - круг((0;0) - Point - радиус), 2 - эллипс (2 радиуса), 3 - стороны треугольника, 4 и более - многоугольник
        /// </summary>
        /// <returns> Прощадь фигуры </returns>
        public static double GetUniversalArea(params Point[] values)
        {
            if (values == null || values.Length <= 0)
                throw new ArgumentException("Необходимо указать хотя бы одно значение");

            switch (values.Length)
            {
                case 1:
                    return CircleFactory.CreateCircle(HelpFunc.GetDistance(
                        new Point() { X = 0, Y = 0},
                        values[0])).GetArea();

                case 2:
                    if (
                        values[0].X > 0 && values[1].X != 0 ||
                        values[0].Y > 0 && values[1].Y != 0
                        )
                        throw new ArgumentException("Точки для задания радиусов элипса должны располагаться разных координатных осях");
                    return CircleFactory.CreateEllipse_ByTwoRadius(
                        HelpFunc.GetDistance( new Point() { X = 0, Y = 0 }, values[0]), 
                        HelpFunc.GetDistance( new Point() { X = 0, Y = 0 }, values[1])
                    ).GetArea();

                case 3:
                    return PoligonFactory.CreateTriangle_ByPoints(values[0], values[1], values[2]).GetArea();

                default:
                    return PoligonFactory.CreatePoligon_ByPoints(values).GetArea();
            }
        }

        #endregion
    }
}
