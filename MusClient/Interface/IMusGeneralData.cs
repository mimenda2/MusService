using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusClient.Interface
{
    public interface IMusGeneralData
    {
        string ServerIP { get; set; }
        string GameName { get; set; }
        string TeamName { get; set; }
        string UserName { get; set; }
    }
}
