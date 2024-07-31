using Dependency_Injection.Players;
using System;

namespace Dependency_Injection.Test
{
    public class ComputerPlayerTests
    {
        [Fact]
        public void GetChoice_ReturnsValidChoice()
        {
            // Arrange
            var player = new ComputerPlayer();

            // Act
            var choice = player.GetChoice();

            // Assert
            Assert.True(Enum.IsDefined(typeof(Choice), choice));
        }

        [Fact]
        public void GetChoice_ReturnsAllChoices()
        {
            // Arrange
            var player = new ComputerPlayer();
            var choices = new HashSet<Choice>();

            var numberOfChoices = Enum.GetNames(typeof(Choice)).Length;

            // Act
            for (int i = 0; i < 100; i++)
            {
                if (choices.Count == numberOfChoices) break;
                choices.Add(player.GetChoice());
            }

            // Assert
            Assert.Contains(Choice.Rock, choices);
            Assert.Contains(Choice.Paper, choices);
            Assert.Contains(Choice.Scissors, choices);
        }
    }
}
