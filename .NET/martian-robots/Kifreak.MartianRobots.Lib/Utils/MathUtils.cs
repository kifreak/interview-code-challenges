namespace Kifreak.MartianRobots.Lib.Utils
{
    public static class MathUtils
    {
        public static int Rotate(int degrees, int currentOrientation)
        {
            int nextOrientation = (currentOrientation + degrees) % 360;
            if (nextOrientation < 0) nextOrientation += 360;
            return nextOrientation;
        }
    }
}