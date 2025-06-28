using Xunit;
using MarsRovers.Domain.Entities;
using MarsRovers.Domain.ValueObjects;

namespace MarsRovers.Test.Domain.Entities
{
    public class PlateauTest
    {
        [Fact]
        public void IsValidPosition_ReturnsTrue_ForPositionWithinBounds()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(3, 3);
            Assert.True(plateau.IsValidPosition(position));
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(6, 0)]
        [InlineData(0, 6)]
        [InlineData(6, 6)]
        public void IsValidPosition_ReturnsFalse_ForPositionOutOfBounds(int x, int y)
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(x, y);
            Assert.False(plateau.IsValidPosition(position));
        }

        [Fact]
        public void IsOccupied_ReturnsFalse_WhenPositionNotRegistered()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(1, 1);
            Assert.False(plateau.IsOccupied(position));
        }

        [Fact]
        public void RegisterPosition_MakesPositionOccupied()
        {
            var plateau = new Plateau(5, 5);
            var position = new Position(2, 2);
            plateau.RegisterPosition(position);
            Assert.True(plateau.IsOccupied(position));
        }

        [Fact]
        public void UpdatePosition_UpdatesOccupiedPositions()
        {
            var plateau = new Plateau(5, 5);
            var oldPos = new Position(1, 1);
            var newPos = new Position(2, 2);

            plateau.RegisterPosition(oldPos);
            plateau.UpdatePosition(oldPos, newPos);

            Assert.False(plateau.IsOccupied(oldPos));
            Assert.True(plateau.IsOccupied(newPos));
        }

        [Fact]
        public void UpdatePosition_UpdatesOccupiedPositionsAndValidPosition()
        {
            var plateau = new Plateau(5, 5);
            var oldPos = new Position(1, 1);
            var newPos = new Position(2, 2);
            
            Assert.True(plateau.IsValidPosition(oldPos));

            plateau.RegisterPosition(oldPos);
            plateau.UpdatePosition(oldPos, newPos);

            Assert.False(plateau.IsOccupied(oldPos));
            Assert.True(plateau.IsOccupied(newPos));
        }
    }
}