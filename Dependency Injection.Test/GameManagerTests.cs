using Dependency_Injection.Players;

namespace Dependency_Injection.Test
{
    public class GameManagerTests
    {
        [Fact]
        public void PlayRound_ReturnsValidRoundResult()
        {
            // Arrange            
            var player1 = new ComputerPlayer();
            var player2 = new ComputerPlayer();
            var gm      = new GameManager(player1, player2);

            // Act
            var result = gm.PlayRound();

            // Assert
            Assert.True(Enum.IsDefined(typeof(RoundResult), result));
        }

        [Fact]
        public void RockBeatsScissors()
        {
            GameManager gm = new(
                new ForcedPlayer(Choice.Rock),
                new ForcedPlayer(Choice.Scissors));

            Assert.Equal(RoundResult.Player1Win, gm.PlayRound());
        }

        [Fact]
        public void PaperBeatsRock()
        {
            GameManager gm = new(
                new ForcedPlayer(Choice.Paper),
                new ForcedPlayer(Choice.Rock));

            Assert.Equal(RoundResult.Player1Win, gm.PlayRound());
        }

        [Fact]
        public void ScissorsBeatsPaper()
        {
            GameManager gm = new(
                new ForcedPlayer(Choice.Scissors),
                new ForcedPlayer(Choice.Paper));

            Assert.Equal(RoundResult.Player1Win, gm.PlayRound());
        }

        [Theory]
        [InlineData(Choice.Rock, Choice.Rock)]
        [InlineData(Choice.Paper, Choice.Paper)]
        [InlineData(Choice.Scissors, Choice.Scissors)]
        public void Draw(Choice player1Choice, Choice player2Choice)
        {
            GameManager gm = new(
                new ForcedPlayer(player1Choice),
                new ForcedPlayer(player2Choice));

            Assert.Equal(RoundResult.Draw, gm.PlayRound());
        }

        [Theory]
        [InlineData(Choice.Rock, Choice.Scissors)]
        [InlineData(Choice.Paper, Choice.Rock)]
        [InlineData(Choice.Scissors, Choice.Paper)]
        public void Player1Wins(Choice p1Choice, Choice p2Choice)
        {
            // Arrange
            GameManager gm = new(
                new ForcedPlayer(p1Choice),
                new ForcedPlayer(p2Choice));

            // Act
            var result = gm.PlayRound();

            // Assert
            Assert.Equal(RoundResult.Player1Win, result);
        }

        [Theory]
        [InlineData(Choice.Paper, Choice.Scissors)]
        [InlineData(Choice.Scissors, Choice.Rock)]
        [InlineData(Choice.Rock, Choice.Paper)]
        public void Player2Wins(Choice p1Choice, Choice p2Choice)
        {
            // Arrange
            GameManager gm = new(
                new ForcedPlayer(p1Choice),
                new ForcedPlayer(p2Choice));

            // Act
            var result = gm.PlayRound();

            // Assert
            Assert.Equal(RoundResult.Player2Win, result);
        }
    }
}