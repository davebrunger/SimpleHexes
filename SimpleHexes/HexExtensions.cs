namespace SimpleHexes;

public static class HexExtensions
{
    public static Hex GetNeighbour(this Hex hex, OrthogonalDirection direction)
    {
        return hex + direction.AsHex();
    }

    public static IEnumerable<Hex> GetNeighbours(this Hex hex, OrthogonalDirection direction)
    {
        return Hex.OrthogonalDirections.Select(d => d + hex);
    }

    public static Hex Add(this Hex a, Hex b)
    {
        return new Hex(a.Q + b.Q, a.R + b.R);
    }

    public static Hex Subtract(this Hex a, Hex b)
    {
        return new Hex(a.Q - b.Q, a.R - b.R);
    }

    public static int GetDistanceTo(this Hex source, Hex target)
    {
        var vector = target - source;
        return Math.Max(Math.Max(Math.Abs(vector.Q), Math.Abs(vector.R)), Math.Abs(vector.S));    
    }

    private static IEnumerable<Hex> GetLineTo(this Hex source, Hex target, DoubleHex epsilon)
    {
        var n = source.GetDistanceTo(target);
        if (n == 0)
        {
            return new[] { source };
        }
        var adjustedSource = source + epsilon;
        return Enumerable.Range(0, n + 1)
            .Select(i =>
            {
                var t = (double)i / n;
                return new DoubleHex(
                    adjustedSource.Q + ((target.Q - adjustedSource.Q) * t),
                    adjustedSource.R + ((target.R - adjustedSource.R) * t)
                ).Round();
            });
    }

    public static IEnumerable<Hex> GetLineTo(this Hex source, Hex target)
    {
        return source.GetLineTo(target, DoubleHex.Episilon);
    }

    public static IEnumerable<IEnumerable<Hex>> GetAllLinesTo(this Hex source, Hex target)
    {
        if (source == target)
        {
            return new[] { new[] { source } };
        }
        if (source.IsOnDiagonalFrom(target))
        {
            return new[]
            {
                source.GetLineTo(target, DoubleHex.Episilon),
                source.GetLineTo(target, -DoubleHex.Episilon)
            };
        }
        return new[] { source.GetLineTo(target) };
    }

    public static bool IsOnDiagonalFrom(this Hex source, Hex target)
    {
        var vector = source - target;
        return vector.Q == vector.R || vector.Q * -2 == vector.R || vector.Q == vector.R * -2;
    }
}
