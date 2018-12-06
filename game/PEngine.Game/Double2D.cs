namespace PEngine.Game
{
    struct Double2D
    {
        public double X, Y;

        public Double2D(double value)
        {
            X = value;
            Y = value;
        }

        public Double2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Double2D Zero()
        {
            return new Double2D(0, 0);
        }

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
