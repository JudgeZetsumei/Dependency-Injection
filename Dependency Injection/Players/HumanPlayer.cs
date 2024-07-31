namespace Dependency_Injection.Players
{
    public class HumanPlayer : IPlayer
    {
        public Choice GetChoice()
        {
            Choice choice;
            while (true)
            {
                Console.Write("Enter Choice: (R)ock, (P)aper, or (S)cissors: ");
                string input;

                input = Console.ReadLine()?.ToUpper() ?? string.Empty;

                if (input == "R")
                {
                    choice = Choice.Rock;
                    break;
                }
                else if (input == "P")
                {
                    choice = Choice.Paper;
                    break;
                }
                else if (input == "S")
                {
                    choice = Choice.Scissors;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again!");
                }
            }

            return choice;
        }
    }
}
