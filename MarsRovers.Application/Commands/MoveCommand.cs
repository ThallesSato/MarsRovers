using MarsRovers.Domain.Entities;
using MarsRovers.Application.Interfaces;

namespace MarsRovers.Application.Commands;

public class MoveCommand : ICommand {
    public void Execute(Rover rover, Plateau plateau) {
        var next = rover.GetNextPosition();

        if (!plateau.IsValidPosition(next)) {
            Console.WriteLine($"Invalid move: {next} is outside the plateau boundaries. -> move ignored.");
            return;
        };
        if (plateau.IsOccupied(next)) {
            Console.WriteLine($"Invalid move: {next} is already occupied by another rover. -> move ignored.");
            return;
        };

        plateau.UpdatePosition(rover.Position, next);
        rover.MoveTo(next);
    }
}