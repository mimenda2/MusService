using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusClient
{
    public enum MusState
    {
        Initial,
        Login,
        WaitingPlayers,
        MakeTeams,
        StartGame,
        NextRoundRequest,
        NextRound,
        FinishGame
    }
}
