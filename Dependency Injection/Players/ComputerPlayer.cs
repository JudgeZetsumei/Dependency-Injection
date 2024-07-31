namespace Dependency_Injection.Players
{
    public class ComputerPlayer : IPlayer
    {
        private readonly Random _rng = new();

        public Choice GetChoice()
        {
            Choice choice = (Choice)_rng.Next(0, 3);
            return choice;
        }
    }
}
