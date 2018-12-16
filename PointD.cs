namespace PolylineSmooth
{
    public class PointD
    {
        public PointD()
        {
        }

        public PointD(double nx, double ny)
        {
            X = nx;
            Y = ny;
        }

        public PointD(PointD p)
        {
            X = p.X;
            Y = p.Y;
        }

        public double X = 0;
        public double Y = 0;

        public static PointD operator +(PointD p1, PointD p2)
        {
            return new PointD(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static PointD operator +(PointD p, double d)
        {
            return new PointD(p.X + d, p.Y + d);
        }

        public static PointD operator +(double d, PointD p)
        {
            return p + d;
        }

        public static PointD operator -(PointD p1, PointD p2)
        {
            return new PointD(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static PointD operator -(PointD p, double d)
        {
            return new PointD(p.X - d, p.Y - d);
        }

        public static PointD operator -(double d, PointD p)
        {
            return p - d;
        }

        public static PointD operator *(PointD p1, PointD p2)
        {
            return new PointD(p1.X * p2.X, p1.Y * p2.Y);
        }

        public static PointD operator *(PointD p, double d)
        {
            return new PointD(p.X * d, p.Y * d);
        }

        public static PointD operator *(double d, PointD p)
        {
            return p * d;
        }

        public static PointD operator /(PointD p1, PointD p2)
        {
            return new PointD(p1.X / p2.X, p1.Y / p2.Y);
        }

        public static PointD operator /(PointD p, double d)
        {
            return new PointD(p.X / d, p.Y / d);
        }

        public static PointD operator /(double d, PointD p)
        {
            return new PointD(d / p.X, d / p.Y);
        }
    }
}
