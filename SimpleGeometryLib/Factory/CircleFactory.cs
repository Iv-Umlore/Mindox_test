using SimpleGeometryLib.Models;
using SimpleGeometryLib.Models.Base;

namespace SimpleGeometryLib.Factory
{
    public static class CircleFactory
    {
        /// <summary>
        /// Получить готовый эллипс по двум радиусам. Порядок значения не имеет
        /// </summary>
        /// <param name="radFirst"> Первый радиус Эллипса </param>
        /// <param name="radSecond"> Второй радиус эллипса </param>
        /// <returns> Объект Эллипса с заданными радиусами </returns>
        public static Ellipse CreateEllipse_ByTwoRadius(double radFirst, double radSecond)
        {
            return new Ellipse(radFirst / radSecond, radFirst);
        }

        /// <summary>
        /// Получить готовый эллипс по радиусу и коэффициенту сжатия
        /// </summary>
        /// <param name="coeff"> Отношение неизвестного радиуса к радиусу, который передаётся </param>
        /// <param name="radius"> Радиус эллипса </param>
        /// <returns> Объект Эллипса с заданными радиусами </returns>
        public static Ellipse CreateEllipse_ByRadiusAndCoeff(double coeff, double radius)
        {
            return new Ellipse(coeff, radius);
        }

        /// <summary>
        /// Получить готовый круг по радиусу
        /// </summary>
        /// <param name="radius"> Радиус окружности </param>
        /// <returns> Объект круга с заданными радиусами </returns>
        public static Circle CreateCircle(double radius)
        {
            return new Circle(radius);
        }
    }
}
