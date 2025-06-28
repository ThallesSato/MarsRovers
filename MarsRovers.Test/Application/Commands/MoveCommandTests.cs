using MarsRovers.Application.Commands;
using MarsRovers.Domain.Entities;
using MarsRovers.Domain.ValueObjects;
using Xunit;

namespace MarsRovers.Test.Application.Commands;

public class MoveCommandTests
{
    [Fact]
    public void Execute_MovesRoverForward_WhenNextPositionIsValidAndUnoccupied()
    {
        var rover = new Rover(new Position(1, 1), Direction.N);
        var plateau = new Plateau(5, 5);
        plateau.RegisterPosition(rover.Position);
        var command = new MoveCommand();

        command.Execute(rover, plateau);

        Assert.Equal(new Position(1, 2), rover.Position);
        Assert.True(plateau.IsOccupied(new Position(1, 2)));
        Assert.False(plateau.IsOccupied(new Position(1, 1)));
    }

    [Fact]
    public void Execute_DoesNotMoveRover_WhenNextPositionIsInvalid()
    {
        var rover = new Rover(new Position(0, 5), Direction.N);
        var plateau = new Plateau(5, 5);
        plateau.RegisterPosition(rover.Position);
        var command = new MoveCommand();

        command.Execute(rover, plateau);

        Assert.Equal(new Position(0, 5), rover.Position);
        Assert.True(plateau.IsOccupied(new Position(0, 5)));
    }

    [Fact]
    public void Execute_DoesNotMoveRover_WhenNextPositionIsOccupied()
    {
        var rover = new Rover(new Position(1, 1), Direction.N);
        var plateau = new Plateau(5, 5);
        plateau.RegisterPosition(rover.Position);
        plateau.RegisterPosition(new Position(1, 2)); // Occupied
        var command = new MoveCommand();

        command.Execute(rover, plateau);

        Assert.Equal(new Position(1, 1), rover.Position);
        Assert.True(plateau.IsOccupied(new Position(1, 1)));
        Assert.True(plateau.IsOccupied(new Position(1, 2)));
    }
}
