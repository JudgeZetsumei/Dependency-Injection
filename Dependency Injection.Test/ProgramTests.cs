using Dependency_Injection.Players;
using System;

namespace Dependency_Injection.Test
{
    public class ProgramTests
    {
        [Fact]
        public void GameManager_ShouldInitializeWithPlayers()
        {
            // Arrange
            var humanPlayer = new HumanPlayer();
            var computerPlayer = new ComputerPlayer();

            // Act
            var gm = new GameManager(humanPlayer, computerPlayer);

            // Assert
            Assert.NotNull(gm);
            Assert.Equal(humanPlayer, gm.GetPlayer1());
            Assert.Equal(computerPlayer, gm.GetPlayer2());
        }
        
    }
}