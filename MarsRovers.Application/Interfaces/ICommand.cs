using MarsRovers.Domain.Entities;

namespace MarsRovers.Application.Interfaces;

public interface ICommand {
    void Execute(Rover rover, Plateau plateau);
}