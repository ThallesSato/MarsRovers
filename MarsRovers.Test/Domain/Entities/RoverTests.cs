using MarsRovers.Domain.Entities;
using MarsRovers.Domain.ValueObjects;

namespace Test.MarsRovers.Domain.Entities;

public class RoverTests
{
    [Theory]
    [InlineData(Direction.N, Direction.W)]
    [InlineData(Direction.W, Direction.S)]
    [InlineData(Direction.S, Direction.E)]
    [InlineData(Direction.E, Direction.N)]
    public void TurnLeft_ChangesDirectionCorrectly(Direction initial, Direction expected)
    {
        var rover = new Rover(new Position(0, 0), initial);
        rover.TurnLeft();
        Assert.Equal(expected, rover.Direction);
    }

    [Theory]
    [InlineData(Direction.N, Direction.E)]
    [InlineData(Direction.E, Direction.S)]
    [InlineData(Direction.S, Direction.W)]
    [InlineData(Direction.W, Direction.N)]
    public void TurnRight_ChangesDirectionCorrectly(Direction initial, Direction expected)
    {
        var rover = new Rover(new Position(0, 0), initial);
        rover.TurnRight();
        Assert.Equal(expected, rover.Direction);
    }

    [Theory]
    [InlineData(1, 1, Direction.N, 1, 2)]
    [InlineData(1, 1, Direction.E, 2, 1)]
    [InlineData(1, 1, Direction.S, 1, 0)]
    [InlineData(1, 1, Direction.W, 0, 1)]
    public void GetNextPosition_ReturnsCorrectPosition(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var rover = new Rover(new Position(x, y), dir);
        var next = rover.GetNextPosition();
        Assert.Equal(expectedX, next.X);
        Assert.Equal(expectedY, next.Y);
    }

    [Fact]
    public void MoveTo_UpdatesPosition()
    {
        var rover = new Rover(new Position(0, 0), Direction.N);
        var newPosition = new Position(0, 1);
        rover.MoveTo(newPosition);
        Assert.Equal(newPosition, rover.Position);
    }

    [Theory]
    [InlineData(1, 1, Direction.N, 1, 2)]
    [InlineData(1, 1, Direction.E, 2, 1)]
    [InlineData(1, 1, Direction.S, 1, 0)]
    [InlineData(1, 1, Direction.W, 0, 1)]
    public void MoveToAndNextPosition_ReturnsCorrectPosition(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var rover = new Rover(new Position(x, y), dir);
        var next = rover.GetNextPosition();
        rover.MoveTo(next);
        var newPosition = new Position(expectedX, expectedY);
        Assert.Equal(rover.Position, newPosition);
    }
}
