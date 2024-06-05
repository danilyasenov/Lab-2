using System;

public class Complex
{
    public double X { get; init; }
    public double Y { get; init; }

    public static readonly Complex Zero = new Complex(0, 0);
    public static readonly Complex One = new Complex(1, 0);
    public static readonly Complex ImaginaryOne = new Complex(0, 1);

    public Complex(double x, double y)
    {
        X = x;
        Y = y;
    }

    public Complex(double x) : this(x, 0) { }

    public Complex() : this(0, 0) { }

    public static Complex Re(double x)
    {
        return new Complex(x, 0);
    }

    public static Complex Im(double y)
    {
        return new Complex(0, y);
    }

    public static Complex Sqrt(double real)
    {
        if (real < 0)
        {
            return new Complex(0, Math.Sqrt(-real));
        }
        return new Complex(Math.Sqrt(real), 0);
    }

    public double Magnitude => Math.Sqrt(X * X + Y * Y);

    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.X + b.X, a.Y + b.Y);
    }

    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.X - b.X, a.Y - b.Y);
    }

    public static Complex operator *(Complex a, Complex b)
    {
        return new Complex(a.X * b.X - a.Y * b.Y, a.X * b.Y + a.Y * b.X);
    }

    public static Complex operator /(Complex a, Complex b)
    {
        if (b.Equals(Zero))
        {
            throw new DivideByZeroException();
        }

        double denom = b.X * b.X + b.Y * b.Y;
        return new Complex((a.X * b.X + a.Y * b.Y) / denom, (a.Y * b.X - a.X * b.Y) / denom);
    }

    public static Complex operator +(Complex a, double b)
    {
        return new Complex(a.X + b, a.Y);
    }

    public static Complex operator -(Complex a, double b)
    {
        return new Complex(a.X - b, a.Y);
    }

    public static Complex operator *(Complex a, double b)
    {
        return new Complex(a.X * b, a.Y * b);
    }

    public static Complex operator /(Complex a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }

        return new Complex(a.X / b, a.Y / b);
    }

    public static Complex operator +(double a, Complex b)
    {
        return b + a;
    }

    public static Complex operator -(double a, Complex b)
    {
        return new Complex(a - b.X, -b.Y);
    }

    public static Complex operator *(double a, Complex b)
    {
        return b * a;
    }

    public static Complex operator /(double a, Complex b)
    {
        return new Complex(a) / b;
    }

    public static Complex operator +(Complex a)
    {
        return a;
    }

    public static Complex operator -(Complex a)
    {
        return new Complex(-a.X, -a.Y);
    }

    public override string ToString()
    {
        if (Y == 0)
        {
            return $"{X}";
        }
        if (X == 0)
        {
            return $"{Y}i";
        }
        return $"{X} + {Y}i";
    }

    public override bool Equals(object obj)
    {
        if (obj is Complex other)
        {
            return X == other.X && Y == other.Y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
