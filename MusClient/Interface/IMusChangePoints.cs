using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusClient.Interface
{
    public interface IMusChangePoints
    {
        int UserPointsChanged { get; set; }
        DateTime ChangePointsDate { get; set; }
        int MusValor { get; set; }
        bool MusEnabled { get; set; }
    }
}
