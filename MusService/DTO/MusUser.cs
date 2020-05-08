using MusCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusWinService.DTO
{
    public class MusUser
    {
        public MusUser(string userName)
        {
            UserName = userName;
            CreationDate = DateTime.Now;
            Cards = new List<MusCard>();
        }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public MusSpecialMessages SpecialMessage { get; set; } = MusSpecialMessages.None;
        public int CurrentRound { get; set; } = 0;
        public int ShowCardsRound { get; set; } = 0;
        public DateTime CreationDate { get; set; }
        public List<MusCard> Cards { get; set; }
    }
}
