namespace PEngine.Game
{
    struct Double2D
    {
        internal double X, Y;

        internal Double2D(double value)
        {
            X = value;
            Y = value;
        }

        internal Double2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        internal static Double2D Zero => new Double2D(0, 0);

        public static Double2D operator +(Double2D left, Double2D right)
        {
            return new Double2D(left.X + right.X, left.Y + right.Y);
        }

        public static Double2D operator -(Double2D left, Double2D right)
        {
            return new Double2D(left.X - right.X, left.Y - right.Y);
        }

        public static Double2D operator *(Double2D d2d, double d)
        {
            return new Double2D(d2d.X * d, d2d.Y * d);
        }

        public static Double2D operator /(Double2D d2d, double d)
        {
            return new Double2D(d2d.X / d, d2d.Y / d);
        }
    }
}
