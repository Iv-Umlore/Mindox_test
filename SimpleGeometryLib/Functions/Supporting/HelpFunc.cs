using SimpleGeometryLib.Models.Base;

namespace SimpleGeometryLib.Functions.HelpFunc
{
    public static class HelpFunc
    {
        public static double GetDistance(Point f, Point s)
        {
            return Math.Sqrt(f.X * s.X + f.Y * s.Y);
        }
    }
}
