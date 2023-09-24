using SimpleGeometryLib.Models.Base;

namespace SimpleGeometryLib.Functions.Supporting
{
    public static class HelpFunc
    {
        /// <summary>
        /// Distance between 2 points
        /// </summary>
        public static double GetDistance(Point f, Point s)
        {
            return Math.Sqrt(Math.Pow(f.X - s.X, 2) + Math.Pow(f.Y - s.Y, 2));
        }

    }

}
