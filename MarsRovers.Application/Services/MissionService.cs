using MarsRovers.Domain.Entities;
using MarsRovers.Domain.ValueObjects;
using MarsRovers.Application.Commands;
using MarsRovers.Application.Interfaces;

namespace MarsRovers.Application.Services;

public class MissionService
{
    public List<Rover> ExecuteMission(string[] inputLines){
        var plateauSize = inputLines[0].Split(' ').Select(int.Parse).ToArray();
        var plateau = new Plateau(plateauSize[0], plateauSize[1]);
        var rovers = new List<Rover>();
        for (int i = 1; i < inputLines.Length; i += 2)
        {
            var roverPosition = inputLines[i].Split(' ');
            var x = int.Parse(roverPosition[0]);
            var y = int.Parse(roverPosition[1]);
            var direction = roverPosition[2] switch
            {
                "N" => Direction.N,
                "E" => Direction.E,
                "S" => Direction.S,
                "W" => Direction.W,
                _ => throw new InvalidOperationException($"Invalid direction: {roverPosition[2]}. Valid directions are N, E, S, W.")
            };
            var rover = new Rover(new Position(x, y), direction);
            
            if (plateau.IsOccupied(rover.Position) || !plateau.IsValidPosition(rover.Position))
            {
                Console.WriteLine($"Invalid initial position for rover at {rover.Position}. Position is either occupied or out of bounds. -> Rover ignored.");
                continue;
            }

            plateau.RegisterPosition(rover.Position);

            var commands = ParseCommands(inputLines[i + 1]);
            foreach (var command in commands)
                command.Execute(rover, plateau);

            rovers.Add(rover);
            
        }
        return rovers;
    }

    private static List<ICommand> ParseCommands(string sequence) =>
        sequence.Select(c => (ICommand)(c switch {
            'L' => new TurnLeftCommand(),
            'R' => new TurnRightCommand(),
            'M' => new MoveCommand(),
            _ => throw new InvalidOperationException($"Invalid command: {c}. It must be one of 'L', 'R', or 'M'.")
        })).ToList();
}
