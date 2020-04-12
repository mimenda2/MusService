using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusWinService.DTO
{
    public class MusTeam
    {
        public MusTeam(string teamName)
        {
            TeamName = teamName;
            Users = new List<MusUser>();
            CreationDate = DateTime.Now;
        }
        public long TeamId { get; set; }
        public string TeamName { get; set; }
        public List<MusUser> Users { get; set; }
        public int Puntuacion { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
