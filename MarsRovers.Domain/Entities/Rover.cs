using MarsRovers.Domain.ValueObjects;

namespace MarsRovers.Domain.Entities;

public class Rover {
    public Position Position { get; private set; }
    public Direction Direction { get; private set; }

    public Rover(Position position, Direction direction) {
        Position = position;
        Direction = direction;
    }

    public void TurnLeft() {
        this.Direction = this.Direction switch {
            Direction.N => Direction.W,
            Direction.W => Direction.S,
            Direction.S => Direction.E,
            Direction.E => Direction.N,
            _ => this.Direction
        };
    }

    public void TurnRight() {
        this.Direction = this.Direction switch {
            Direction.N => Direction.E,
            Direction.E => Direction.S,
            Direction.S => Direction.W,
            Direction.W => Direction.N,
            _ => this.Direction
        };
    }

    public Position GetNextPosition() {
        return this.Direction switch {
            Direction.N => new Position(this.Position.X, this.Position.Y + 1),
            Direction.E => new Position(this.Position.X + 1, this.Position.Y),
            Direction.S => new Position(this.Position.X, this.Position.Y - 1),
            Direction.W => new Position(this.Position.X - 1, this.Position.Y),
            _ => this.Position
        };
    }

    public void MoveTo(Position newPosition) {
        this.Position = newPosition;
    }
}