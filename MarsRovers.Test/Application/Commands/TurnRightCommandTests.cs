using MarsRovers.Application.Commands;
using MarsRovers.Domain.Entities;
using MarsRovers.Domain.ValueObjects;
using Xunit;

namespace MarsRovers.Test.Application.Commands;

public class TurnRightCommandTests
{
    [Theory]
    [InlineData(Direction.N, Direction.E)]
    [InlineData(Direction.E, Direction.S)]
    [InlineData(Direction.S, Direction.W)]
    [InlineData(Direction.W, Direction.N)]
    public void Execute_TurnsRoverRight(Direction initial, Direction expected)
    {
        var rover = new Rover(new Position(1, 1), initial);
        var plateau = new Plateau(5, 5);
        plateau.RegisterPosition(rover.Position);
        var command = new TurnRightCommand();

        command.Execute(rover, plateau);
 
        Assert.Equal(expected, rover.Direction);
    }
}
