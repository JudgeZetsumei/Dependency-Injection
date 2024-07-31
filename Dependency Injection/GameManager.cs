using Dependency_Injection.Players;

namespace Dependency_Injection
{
    public class GameManager
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public GameManager(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public RoundResult PlayRound()
        {
            // Player 1
            Choice p1Choice = _player1.GetChoice();
            Choice p2Choice = _player2.GetChoice();

            Console.WriteLine($"Player 1 picked {p1Choice.ToString()} and Player 2 picked {p2Choice.ToString()}");

            if (p1Choice == p2Choice)
            {
                return RoundResult.Draw;
            }

            if ((p1Choice == Choice.Rock      && p2Choice == Choice.Scissors) ||
                (p1Choice == Choice.Paper     && p2Choice == Choice.Rock) ||
                (p1Choice == Choice.Scissors  && p2Choice == Choice.Paper))
            {
                return RoundResult.Player1Win;
            }

            return RoundResult.Player2Win;
        }

        public IPlayer GetPlayer1() => _player1;
        public IPlayer GetPlayer2() => _player2;
    }

    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    }

    public enum RoundResult
    {
        Player1Win,
        Player2Win,
        Draw
    }
}