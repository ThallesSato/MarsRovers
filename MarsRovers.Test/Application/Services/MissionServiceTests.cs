using MarsRovers.Application.Services;
using MarsRovers.Application.Commands;
using MarsRovers.Application.Interfaces;
using MarsRovers.Domain.ValueObjects;

namespace MarsRovers.Test.Application.Services
{
    public class MissionServiceTests
    {
        [Fact]
        public void ExecuteMission_ExecutesCommandsAndReturnsRovers()
        {
            var service = new MissionService();
            string[] input =
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            var result = service.ExecuteMission(input);

            Assert.Equal(2, result.Count);
            Assert.Equal(new Position(1, 3), result[0].Position);
            Assert.Equal(Direction.N, result[0].Direction);
            Assert.Equal(new Position(5, 1), result[1].Position);
            Assert.Equal(Direction.E, result[1].Direction);
        }

        [Fact]
        public void ExecuteMission_IgnoresRoverWithInvalidInitialPosition()
        {
            var service = new MissionService();
            string[] input =
            {
                "5 5",
                "6 6 N",
                "LMLMLMLMM"
            };

            var result = service.ExecuteMission(input);
            Assert.Empty(result);
        }

        [Fact]
        public void ExecuteMission_IgnoresRoverWithOccupiedInitialPosition()
        {
            var service = new MissionService();
            string[] input =
            {
                "5 5",
                "1 2 N",
                "LMLMLMLM",
                "1 2 E",
                "MMRMMRMRRM"
            };

            var result = service.ExecuteMission(input);
            Assert.Single(result);
            Assert.Equal(new Position(1, 2), result[0].Position);
        }

        [Theory]
        [InlineData("LLLL", typeof(TurnLeftCommand))]
        [InlineData("RRRR", typeof(TurnRightCommand))]
        [InlineData("MMMM", typeof(MoveCommand))]
        public void ParseCommands_ParsesCorrectCommandTypes(string commandLine, Type expectedType)
        {
            var service = new MissionService();

            var method = typeof(MissionService)
            .GetMethod("ParseCommands", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            Assert.NotNull(method);

            var result = method!.Invoke(service, new object[] { commandLine });

            Assert.NotNull(result); 

            var commands = result as List<ICommand>;
            Assert.NotNull(commands); 

            Assert.All(commands!, c => Assert.IsType(expectedType, c));
        }

        [Fact]
        public void ExecuteMission_ThrowOnInvalidDirection()
        {
            var service = new MissionService();
            string[] input =
            {
                "5 5",
                "1 2 X",
                "LMLMLMLM"
            };

            Assert.Throws<InvalidOperationException>(() => service.ExecuteMission(input));
        } 

        [Fact]
        public void ExecuteMission_ThrowOnInvalidCommand()
        {
            var service = new MissionService();
            string[] input =
            {
                "5 5",
                "1 2 N",
                "LMLXMLM"
            };

            Assert.Throws<InvalidOperationException>(() => service.ExecuteMission(input));
        } 
    }
}
