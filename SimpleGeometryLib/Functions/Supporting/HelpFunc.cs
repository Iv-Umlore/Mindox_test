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
            return Math.Sqrt(f.X * s.X + f.Y * s.Y);
        }

    }

}
