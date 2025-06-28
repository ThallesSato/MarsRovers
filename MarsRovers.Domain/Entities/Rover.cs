using MarsRovers.Domain.ValueObjects;

namespace MarsRovers.Domain.Entities;

public class Rover {
    public Position Position { get; private set; }
    public Direction Direction { get; private set; }

    public Rover(Position position, Direction direction) {
        Position = position;
        Direction = direction;
    }
}