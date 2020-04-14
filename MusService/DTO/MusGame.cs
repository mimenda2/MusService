using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusWinService.DTO
{
    public class MusGame
    {
        public MusGame(string gameName)
        {
            GameId = -1;
            GameName = gameName;
            Users = new List<MusUser>();
            Teams = new List<MusTeam>();
            Traces = new List<string>();
            Cards = new MusCards();
            CreationDate = DateTime.Now;
        }
        public long GameId { get; set; }
        public string GameName { get; set; }
        public string HandUser { get; set; }
        public List<MusUser> Users { get; set; }
        public List<MusTeam> Teams { get; set; }
        public List<string> Traces { get; set; }
        public MusCards Cards { get; set; }
        public DateTime CreationDate { get; set; }
        public long PointsToWin { get; set; }
        public int Round { get; set; } = -1;
        public void ChangeRound(int newRound)
        {
            if (Round != newRound)
            {
                Round = newRound;
                NextMano();
            }
        }
        MusUser NextMano()
        {
            if (mano == null)
                mano = Teams[0].Users[0];
            else
            {
                if (mano == Teams[0].Users[0])
                    mano = Teams[1].Users[0];
                else if (mano == Teams[1].Users[0])
                    mano = Teams[0].Users[1];
                else if (mano == Teams[0].Users[1])
                    mano = Teams[1].Users[1];
                else
                    mano = Teams[0].Users[0];
            }
            return mano;
        }
        MusUser mano;
    }
}
