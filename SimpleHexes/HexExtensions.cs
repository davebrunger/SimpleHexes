namespace SimpleHexes;

public static class HexExtensions
{
    /// <summary>
    /// Gets the neighbouring hex in the specified orthogonal direction.
    /// </summary>
    /// <param name="hex">The hex to get the neighbour for</param>
    /// <param name="direction">The direction to get the neighbour in</param>
    /// <returns>The neighbouring hex</returns>
    public static Hex GetNeighbour(this Hex hex, OrthogonalDirection direction)
    {
        return hex + direction.AsHex();
    }

#if NETSTANDARD2_1_OR_GREATER
    /// <summary>
    /// Gets the six neighbouring hexes adjacent to this hex.
    /// </summary>
    /// <returns>
    /// A read-only span of neighbouring hexes at distance 1.
    /// </returns>
    /// <remarks>
    /// This method avoids allocations and is intended for performance-sensitive code.
    /// The returned span must not be stored.
    /// </remarks>
    public static ReadOnlySpan<Hex> GetNeighbours(this Hex hex)
    {
        var result = new Hex[Hex.OrthogonalDirections.Length];
        for (int i = 0; i < Hex.OrthogonalDirections.Length; i++)
        {
            result[i] = Hex.OrthogonalDirections[i] + hex;
        }
        return result;
    }
#else
    /// <summary>
    /// Gets the six neighbouring hexes adjacent to this hex.
    /// </summary>
    /// <returns>
    /// A read-only sequence of neighbouring hexes at distance 1.
    /// </returns>
    /// <remarks>
    /// The ordering of neighbours is deterministic but should not be relied upon
    /// unless explicitly documented.
    /// </remarks>
    public static IReadOnlyList<Hex> GetNeighbours(this Hex hex)
    {
        return [.. Hex.OrthogonalDirections.Select(d => d + hex)];
    }
#endif

    public static Hex Add(this Hex a, Hex b)
    {
        return new Hex(a.Q + b.Q, a.R + b.R);
    }

    public static Hex Subtract(this Hex a, Hex b)
    {
        return new Hex(a.Q - b.Q, a.R - b.R);
    }

    /// <summary>
    /// Calculates the hex-grid distance to another hex.
    /// </summary>
    /// <param name="source">The source hex.</param>
    /// <param name="target">The target hex.</param>
    /// <returns>
    /// The number of steps required to move from <paramref name="source"/> to <paramref name="target"/>.
    /// </returns>
    /// <remarks>
    /// This is the standard hex distance for axial coordinates and is symmetric.
    /// </remarks>
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
            return [source];
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

    /// <summary>
    /// Gets all hexes on a straight line from this hex to a target hex.
    /// </summary>
    /// <param name="source">The starting hex.</param>
    /// <param name="target">The destination hex.</param>
    /// <returns>
    /// A sequence of hexes forming a straight line, including the start and end hexes.
    /// </returns>
    /// <remarks>
    /// The line is generated using standard hex interpolation.
    /// Consecutive hexes in the result are always adjacent.
    /// </remarks>

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
            return
            [
                source.GetLineTo(target, DoubleHex.Episilon),
                source.GetLineTo(target, -DoubleHex.Episilon)
            ];
        }
        return [source.GetLineTo(target)];
    }

    public static bool IsOnDiagonalFrom(this Hex source, Hex target)
    {
        var vector = source - target;
        return vector.Q == vector.R || vector.Q * -2 == vector.R || vector.Q == vector.R * -2;
    }
}
