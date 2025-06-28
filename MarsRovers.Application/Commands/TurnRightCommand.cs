using MarsRovers.Domain.Entities;
using MarsRovers.Application.Interfaces;

namespace MarsRovers.Application.Commands;

public class TurnRightCommand : ICommand {
    public void Execute(Rover rover, Plateau plateau) {
        rover.TurnRight();
    }
}