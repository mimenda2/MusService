using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusWinService.DTO
{
    public class MusCards
    {
        public MusCards()
        {
            foreach (MusCard c in Enum.GetValues(typeof(MusCard)))
            {
                if (c != MusCard.Empty && c != MusCard.Back)
                    CardsToPlay.Add(c);
            }
        }
        public List<MusCard> CardsToPlay = new List<MusCard>();
        public List<MusCard> CardsDiscarded = new List<MusCard>();
    }

}
