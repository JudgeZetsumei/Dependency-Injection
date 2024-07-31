using Dependency_Injection.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection.Test
{
    public class HumanPlayerTests
    {
        [Theory]
        [InlineData("R", Choice.Rock)]
        [InlineData("P", Choice.Paper)]
        [InlineData("S", Choice.Scissors)]
        public void GetChoice_ValidInput_ReturnsExpectedChoice(string input, Choice expectedChoice)
        {
            // Arrange
            var humanPlayer = new HumanPlayer();
            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // Act
            var choice = humanPlayer.GetChoice();

            // Assert
            Assert.Equal(expectedChoice, choice);
        }

        [Fact]
        public void GetChoice_InvalidInput_ShowsErrorMessage()
        {
            // Arrange
            var humanPlayer = new HumanPlayer();
            var stringReader = new StringReader("X\nR");
            var stringWriter = new StringWriter();
            Console.SetIn(stringReader);
            Console.SetOut(stringWriter);

            // Act
            var choice = humanPlayer.GetChoice();
            var output = stringWriter.ToString();

            // Assert
            Assert.Equal(Choice.Rock, choice);
            Assert.Contains("Invalid choice, try again!", output);
        }
    }
}
