using MusCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusCommon
{
    public class SpecialMessages
    {
        public static MusSpecialMessages GetSpecialMessage(System.Windows.Forms.Keys letter)
        {
            MusSpecialMessages retVal = MusSpecialMessages.None;
            switch (letter)
            {
                case System.Windows.Forms.Keys.G:
                    retVal = MusSpecialMessages.Gallina;
                    break;
                case System.Windows.Forms.Keys.L:
                    retVal = MusSpecialMessages.Loser;
                    break;
                case System.Windows.Forms.Keys.Q:
                    retVal = MusSpecialMessages.Quejica;
                    break;
            }
            return retVal;
        }
    }
}
