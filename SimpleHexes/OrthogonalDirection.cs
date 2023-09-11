namespace SimpleHexes;

public enum OrthogonalDirection
{
    UpLeft,
    UpRight,
    Right,
    DownRight,
    DownLeft,
    Left
}

public static class OrthogonalDirectionExtensions
{
    public static Hex AsHex(this OrthogonalDirection direction)
    {
        return direction switch
        {
            OrthogonalDirection.UpLeft => Hex.UpLeft,
            OrthogonalDirection.UpRight => Hex.UpRight,
            OrthogonalDirection.Right => Hex.Right,
            OrthogonalDirection.DownRight => Hex.DownRight,
            OrthogonalDirection.DownLeft => Hex.DownLeft,
            OrthogonalDirection.Left => Hex.Left,
            _ => throw new ArgumentOutOfRangeException(nameof(direction)),
        };
    }
}