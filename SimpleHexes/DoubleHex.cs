namespace SimpleHexes;

internal record DoubleHex(double Q, double R)
{
    public static DoubleHex Episilon { get; } = new DoubleHex(1e-6, 2e-6);

    public DoubleHex(Hex hex) : this(hex.Q, hex.R) { }

    public double S => -(Q + R);

    public Hex Round()
    {
        var q = (int)Math.Round(Q);
        var r = (int)Math.Round(R);
        var s = (int)Math.Round(S);

        var qDiff = Math.Abs(q - Q);
        var rDiff = Math.Abs(r - R);
        var sDiff = Math.Abs(s - S);

        if (qDiff > rDiff && qDiff > sDiff)
        {
            q = -(r + s);
        }
        else if (rDiff > sDiff)
        {
            r = -(q + s);
        }

        return new Hex(q, r);
    }

    public static implicit operator DoubleHex(Hex hex)
    {
        return new DoubleHex(hex);
    }

    public static DoubleHex operator +(DoubleHex a, DoubleHex b)
    {
        return new DoubleHex(a.Q + b.Q, a.R + b.R);
    }

    public static DoubleHex operator -(DoubleHex a, DoubleHex b)
    {
        return new DoubleHex(a.Q - b.Q, a.R - b.R);
    }

    public static DoubleHex operator -(DoubleHex a)
    {
        return new DoubleHex(-a.Q, -a.R);
    }
}
