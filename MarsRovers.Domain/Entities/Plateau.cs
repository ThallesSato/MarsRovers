using MarsRovers.Domain.ValueObjects;

namespace MarsRovers.Domain.Entities;

public class Plateau
{
    public int Width { get; }
    public int Height { get; }
    private List<Position> _hasRover = new();

    public Plateau(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public bool IsValidPosition(Position position) =>
        position.X >= 0 && position.X <= Width && position.Y >= 0 && position.Y <= Height;

    public bool IsOccupied(Position position) => _hasRover.Contains(position);

    public void RegisterPosition(Position position) => _hasRover.Add(position);

    public void UpdatePosition(Position oldPos, Position newPos)
    {
        _hasRover.Remove(oldPos);
        _hasRover.Add(newPos);
    }
}