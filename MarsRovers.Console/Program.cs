using MarsRovers.Application.Services;

Console.WriteLine();
Console.WriteLine();
try{
    var input = File.ReadAllLines("input.txt");
    var service = new MissionService();
    var result = service.ExecuteMission(input);
    Console.WriteLine("Rovers final positions:");
    foreach (var rover in result)
    {
        Console.WriteLine($"{rover.Position.X} {rover.Position.Y} {rover.Direction}");
    }
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    return;
}
catch (Exception)
{
    Console.WriteLine("Missing file or invalid input format. Please follow the correct structure:");
    Console.WriteLine();
    Console.WriteLine("Example:");
    Console.WriteLine("5 5                   ← plateau upper-right coordinates (x y)");
    Console.WriteLine("1 2 N                 ← rover initial position (x y direction)");
    Console.WriteLine("LMLMLMLMM            ← command sequence (L, R, M)");
    Console.WriteLine("3 3 E");
    Console.WriteLine("MMRMMRMRRM");
    return;
}