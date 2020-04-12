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
        }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
