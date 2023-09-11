namespace SimpleHexes;

public enum DiagonalDirection
{
    UpLeft,
    Up,
    UpRight,
    DownRight,
    Down,
    DownLeft,
}

public static class DiagonalDirectionExtensions
{
    public static Hex AsHex(this DiagonalDirection direction)
    {
        return direction switch
        {
            DiagonalDirection.UpLeft => Hex.DiagonalUpLeft,
            DiagonalDirection.Up => Hex.Up,
            DiagonalDirection.UpRight => Hex.DiagonalUpRight,
            DiagonalDirection.DownRight => Hex.DownRight,
            DiagonalDirection.Down => Hex.Down,
            DiagonalDirection.DownLeft => Hex.DownLeft,
            _ => throw new ArgumentOutOfRangeException(nameof(direction)),
        };
    }
}