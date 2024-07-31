using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependency_Injection.Players;

namespace Dependency_Injection.Test
{
    internal class ForcedPlayer : IPlayer
    {
        private readonly Choice _choice;

        public ForcedPlayer(Choice choice)
        {
                _choice = choice;
        }

        public Choice GetChoice()
        {
            return _choice;
        }
    }
}
