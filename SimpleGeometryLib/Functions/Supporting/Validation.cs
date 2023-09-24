namespace SimpleGeometryLib.Functions.Supporting
{
    internal static class Validation
    {

        /// <summary>
        /// Сумма двух сторон больше длинны третьей стороны (Основное правило существования треугольника)
        /// </summary>
        public static bool IsSideSmaller(double firstEdgeLength, double secondEdgeLength, double thirdEdgeLength)
        {
            return firstEdgeLength + secondEdgeLength > thirdEdgeLength;
        }

        /// <summary>
        /// Ни одно из значений не должно быть 0
        /// </summary>
        public static bool NotZeroLength(double l1, double l2, double l3)
        {
            return !l1.Equals(0.0) && !l2.Equals(0.0) && !l3.Equals(0.0);
        }
    }
}
