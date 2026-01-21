namespace SimpleHexes;

public record Hex(int Q, int R)
{
    public int S => -(Q + R);

    // Othogonal Hexes
    public static Hex UpLeft { get; } = new Hex(0, -1);
    public static Hex UpRight { get; } = new Hex(1, -1);
    public static Hex Right { get; } = new Hex(1, 0);
    public static Hex DownRight { get; } = new Hex(0, 1);
    public static Hex DownLeft { get; } = new Hex(-1, 1);
    public static Hex Left { get; } = new Hex(-1, 0);

    // Diagonal Hexes
    public static Hex DiagonalUpLeft { get; } = new Hex(-1, -1);
    public static Hex Up { get; } = new Hex(1, -2);
    public static Hex DiagonalUpRight { get; } = new Hex(2, -1);
    public static Hex DiagonalDownRight { get; } = new Hex(1, 1);
    public static Hex Down { get; } = new Hex(-1, 2);
    public static Hex DiagonalDownLeft { get; } = new Hex(-2, 1);

    private static Hex[] orthogonalDirections { get; } = [
        UpLeft,
        UpRight,
        Right,
        DownRight,
        DownLeft,
        Left
    ];

#if NETSTANDARD2_1_OR_GREATER
    public static ReadOnlySpan<Hex> OrthogonalDirections => orthogonalDirections;
#else
    public static IReadOnlyList<Hex> OrthogonalDirections => [.. orthogonalDirections];
#endif

    private static Hex[] diagonalDirections { get; } = [
        DiagonalUpLeft,
        Up,
        DiagonalUpRight,
        DiagonalDownRight,
        Down,
        DiagonalDownLeft
    ];

#if NETSTANDARD2_1_OR_GREATER
    public static ReadOnlySpan<Hex> DiagonalDirections => DiagonalDirections;
#else
    public static IReadOnlyList<Hex> DiagonalDirections => [.. diagonalDirections];
#endif

    public static Hex operator +(Hex a, Hex b)
    {
        return a.Add(b);
    }

    public static Hex operator -(Hex a, Hex b)
    {
        return a.Subtract(b);
    }
}