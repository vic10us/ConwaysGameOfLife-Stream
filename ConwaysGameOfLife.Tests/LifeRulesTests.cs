using Conway.Library;
using Xunit;

namespace ConwaysGameOfLife.Tests
{
    public class LifeRulesTests
    {
        [Theory]
        [InlineData(CellState.Alive, 0)]
        [InlineData(CellState.Alive, 1)]
        // Any live cell with fewer than two live neighbours dies, as if caused by under-population.
        public void LiveCell_LessThanTwoLiveNeighbors_Dies(CellState currentState, int liveNeighbors)
        {
            // Act
            var result = LifeRules.GetNewState(currentState, liveNeighbors);

            // Assert
            Assert.Equal(CellState.Dead, result);
        }

        // Any live cell with two or three live neighbours lives on to the next generation.
        [Theory]
        [InlineData(CellState.Alive, 2)]
        [InlineData(CellState.Alive, 3)]
        public void LiveCell_TwoOrThreeLiveNeighbors_Lives(CellState currentState, int liveNeighbors)
        {
            // Act
            var result = LifeRules.GetNewState(currentState, liveNeighbors);

            // Assert
            Assert.Equal(CellState.Alive, result);
        }

        // Any live cell with more than three live neighbours dies, as if by overcrowding.
        [Theory]
        [InlineData(CellState.Alive, 4)]
        [InlineData(CellState.Alive, 5)]
        [InlineData(CellState.Alive, 6)]
        [InlineData(CellState.Alive, 7)]
        [InlineData(CellState.Alive, 8)]
        public void LiveCell_MoreThanThreeLiveNeighbors_Dies(CellState currentState, int liveNeighbors)
        {
            // Act
            var result = LifeRules.GetNewState(currentState, liveNeighbors);

            // Assert
            Assert.Equal(CellState.Dead, result);
        }

        // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
        [Fact]
        public void DeadCell_ExactlyThreeLiveNeighbors_Lives()
        {
            // Arrange
            const CellState currentState = CellState.Dead;
            const int liveNeighbors = 3;

            // Act
            var result = LifeRules.GetNewState(currentState, liveNeighbors);

            // Assert
            Assert.Equal(CellState.Alive, result);
        }

        [Theory]
        [InlineData(CellState.Dead, 1)]
        [InlineData(CellState.Dead, 2)]
        [InlineData(CellState.Dead, 4)]
        [InlineData(CellState.Dead, 5)]
        [InlineData(CellState.Dead, 6)]
        [InlineData(CellState.Dead, 7)]
        [InlineData(CellState.Dead, 8)]
        public void DeadCell_NotExactlyThreeLiveNeighbors_Dead(CellState currentState, int liveNeighbors)
        {
            // Act
            var result = LifeRules.GetNewState(currentState, liveNeighbors);

            // Assert
            Assert.Equal(CellState.Dead, result);
        }
    }
}
