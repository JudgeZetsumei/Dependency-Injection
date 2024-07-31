using Dependency_Injection;
using Dependency_Injection.Players;

GameManager gm = new(new HumanPlayer(), new ComputerPlayer());

do
{
    RoundResult result = gm.PlayRound();

    if (result == RoundResult.Player1Win)
    {
        Console.WriteLine("Player 1 Wins!");
    }
    else if (result == RoundResult.Player2Win)
    {
        Console.WriteLine("Player 2 Wins!");
    }
    else
    {
        Console.WriteLine("It's a draw!");
    }

    Console.Write("Play Again (Y/N)? ");
} while (string.Equals(Console.ReadLine(), "Y", StringComparison.CurrentCultureIgnoreCase));