using System.Collections.Immutable;

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

    public static ImmutableList<Hex> OrthogonalDirections { get; } = ImmutableList<Hex>.Empty
        .Add(UpLeft)
        .Add(UpRight)
        .Add(Right)
        .Add(DownRight)
        .Add(DownLeft)
        .Add(Left);

    public static ImmutableList<Hex> DiagonalDirections { get; } = ImmutableList<Hex>.Empty
        .Add(DiagonalUpLeft)
        .Add(Up)
        .Add(DiagonalUpRight)
        .Add(DiagonalDownRight)
        .Add(Down)
        .Add(DiagonalDownLeft);

    public static Hex operator +(Hex a, Hex b)
    {
        return a.Add(b);
    }

    public static Hex operator -(Hex a, Hex b)
    {
        return a.Subtract(b);
    }
}